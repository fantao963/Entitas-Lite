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

			
            var defaultContextName = ContextAttribute.GetName<Default>();
            var attrType = typeof(ContextAttribute);
            HashSet<Type> contextSet = new HashSet<Type>();
            List<Type> attrList = new List<Type>();
            attrList.Add(feature.Context.contextType);
            while (attrList.Count > 0)
            {
                var type = attrList[0];
                attrList.RemoveAt(0);
                if (contextSet.Contains(type))
                {
                    continue;
                }
                contextSet.Add(type);
                var attrs = type.GetCustomAttributes(attrType, false);
                foreach (var attr in attrs)
                {
                    var attrName = attr.GetType().Name;
                    if (attrName == defaultContextName)
                    {
                        continue;
                    }
                    attrList.Add(attr.GetType());
                }
            }


            foreach (var p in types)
			{
				var contextattrs= p.GetCustomAttributes(typeof(ContextAttribute), false);
				if(!contextattrs.Any((it)=> contextSet.Contains(it.GetType())))
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
