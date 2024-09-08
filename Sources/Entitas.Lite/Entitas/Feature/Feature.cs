
namespace Entitas
{
	/// Simple Systems with automatic collections. Nested is not supported
	public class Feature : Systems
	{
		/// Constructor, name could be empty/null for noname systems
		public Feature(IContext context, string name) : base(context)
		{
			name = FeatureHelper.GetUnnamed(name);

			FeatureHelper.CollectSystems(name, this);
		}

		public Feature(IContext context) : this(context, context.name)
		{
		}
	}
}
