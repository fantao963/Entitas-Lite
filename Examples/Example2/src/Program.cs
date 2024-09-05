using Entitas;
using System;
using System.Collections.Generic;
using System.Threading;

#if !CONSOLE_APP
using UnityEngine;
#endif

namespace Example
{
	public class InputComponent : IComponent, IUnique
	{
		public bool spaceKey;		
	}

	public class CollectInputSystem : IExecuteSystem
	{
        public IContext Context { get; set ; }

        public void Execute()
		{
			bool spaceKey = false;

#if CONSOLE_APP
			if (Console.KeyAvailable)
			{
				   var key = Console.ReadKey(true).Key;
				if (key == ConsoleKey.Escape)
					Environment.Exit(0);

				spaceKey = (key == ConsoleKey.Spacebar);
			}
#else
			if (Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();

			spaceKey = Input.GetKeyDown(KeyCode.Space);
#endif

			if (spaceKey)
			{
                Context.AddUnique<InputComponent>().spaceKey = true;
			}
		}
	}

	public class ProcessInputSystem : ReactiveSystem,IInitializeSystem
	{
		public ProcessInputSystem()
		{
			
		}

        public void Initialize()
        {
            monitors += Context.AllOf<InputComponent>().OnAdded(Process);
        }

        protected void Process(List<IEntity> entities)
		{
			var e = entities[0];
			var input = e.Get<InputComponent>();
		
#if CONSOLE_APP
			Console.WriteLine(
#else
			Debug.Log(
#endif
				"Entity" + e.creationIndex + ": input.spaceKey=" + input.spaceKey);

			e.Destroy();
		}
	}

#if CONSOLE_APP
	public class GameController
#else
	public class GameController : MonoBehaviour
#endif
	{
		private Systems _feature;
		private IContext _context;

		public void Start()
		{
			//var contexts = Contexts.sharedInstance;
			_context = new Context<Default>();

#if UNITY_EDITOR
			ContextObserverHelper.ObserveAll(contexts);
#endif

#if UNITY_EDITOR
			_feature = FeatureObserverHelper.CreateFeature(null);
#else
			// init systems, auto collect matched systems, no manual Systems.Add(ISystem) required
			_feature = new Feature(_context);
#endif
			_feature.Initialize();
		}

		public void Update()
		{
			_feature.Execute();
			_feature.Cleanup();
		}
	}

#if CONSOLE_APP
	public class Program
	{
		static void Main(string[] args)
		{
			var game = new GameController();

			game.Start();

			Console.WriteLine("Press ESC to exit ...");
			Console.WriteLine();

			// main lopp for game
			while (true)
			{
				game.Update();

				Thread.Yield();
				//Thread.Sleep(20);

				if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
					break;
			}
		}
	}
#else
	public class Program : GameController
	{
	}
#endif
}
