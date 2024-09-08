using System;
using System.Collections.Generic;
using System.Linq;

namespace Entitas
{
	/// Collect all matched System in current domain, then add them to Feature ordered by priority
	public class FeatureHelper
	{
		public static string GetUnnamed(string name)
		{
			if (string.IsNullOrEmpty(name))
				return UnnamedFeature.NAME;
			else
				return name;
		}

		private class SystemProxy : IComparable<SystemProxy>
		{
			public ISystem system;
			public int priority;
			public string fullName;

			public SystemProxy(ISystem s, int prior)
			{
				system = s;
				priority = prior;
				fullName = s.GetType().FullName;
			}

			public int CompareTo(SystemProxy other)
			{
				int priorDiff = other.priority - priority;  // in descending order
				if (priorDiff != 0)
					return priorDiff;

				return string.CompareOrdinal(fullName, other.fullName);
			} 
		}

		public static void CollectSystems(string name, Systems feature)
		{
			var sysType = typeof(ISystem);

			var types = AppDomain.CurrentDomain.GetAssemblies()
								.SelectMany(s => s.GetTypes())
								.Where(p => p.IsClass 
										&& p.IsPublic 
										&& !p.IsAbstract
										&& sysType.IsAssignableFrom(p));

			var attribType = typeof(FeatureAttribute);
			var c = new List<SystemProxy>();

			foreach (var p in types)
			{
				var contextattrs= p.GetCustomAttributes(typeof(ContextAttribute), false);
				if(!contextattrs.Any((it)=>it.GetType().Name==name))
				{
					continue;
				}

				var attribs = p.GetCustomAttributes(attribType, false);
				int w = 0;

				foreach (var attr in attribs)
				{
					var attrib = (FeatureAttribute)attr;
					w = attrib.priority;
				}

				var system = (ISystem)Activator.CreateInstance(p);
				c.Add(new SystemProxy(system, w));
			}

			c.Sort();

			int count = c.Count;
			for (int i = 0; i < count; i++)
			{
				feature.Add(c[i].system);
			}
		}
	}
}
