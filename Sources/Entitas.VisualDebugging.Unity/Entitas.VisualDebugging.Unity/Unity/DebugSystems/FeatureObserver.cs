using UnityEngine;

namespace Entitas.VisualDebugging.Unity
{
	public class FeatureWithObserver : DebugSystems
	{
		public FeatureWithObserver(IContext content, string name) : base(content,FeatureHelper.GetUnnamed(name))
		{
			FeatureHelper.CollectSystems(this.name, this);
			Object.DontDestroyOnLoad(this.gameObject);
		}
	}

	public static class FeatureObserverHelper
	{
		public static Systems CreateFeature(IContext content, string name)
		{
			if (!Application.isPlaying || !Application.isEditor)
				return new Feature(content,name);

			return new FeatureWithObserver(content,name);
		}

		public static void ClearAll()
		{
			if (!Application.isPlaying || !Application.isEditor)
				return;

			var behaviours = Object.FindObjectsOfType<DebugSystemsBehaviour>();
			if (behaviours != null && behaviours.Length > 0)
			{
				foreach (var behaviour in behaviours)
				{
					Object.Destroy(behaviour.gameObject);
				}
			}
		}
	}
}
