
namespace Entitas
{
	/// Simple Systems with automatic collections. Nested is not supported
	public class Feature : Systems
	{
		/// Constructor, name could be empty/null for noname systems
		public Feature(IContext context, string name=null):base(context)
		{
			name = FeatureHelper.GetUnnamed(name);

			FeatureHelper.CollectSystems(name, this);
		}
	}
}
