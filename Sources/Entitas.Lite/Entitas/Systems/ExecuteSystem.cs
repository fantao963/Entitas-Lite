
namespace Entitas
{
	/// Execute on each entity which matches
	public abstract class ExecuteSystem : IExecuteSystem
	{
        public IContext Context { get; set; }
        protected IMatcher _matcher;
		protected IContext _context;

		public ExecuteSystem(IContext context, IMatcher matcher)
		{
			_context = context;
			_matcher = matcher;
		}

		public virtual void Execute()
		{
			var entities = _context.GetEntities(_matcher);
			foreach (var e in entities)
			{
				Execute(e);
			}
		}

		protected abstract void Execute(IEntity entity);
	}
}