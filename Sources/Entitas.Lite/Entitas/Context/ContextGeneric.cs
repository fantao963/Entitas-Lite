
using System;

namespace Entitas
{


	public partial class Context<C> 
	{
		public int GetComponentIndex<T>() where T : IComponent
        {
			return ComponentIndex<C, T>.FindIn(this.contextInfo);
		}
        public  IGroup AllOf<T1>() where T1 : IComponent
		{ return this.GetGroup(Matcher<C, T1>.All()); }
		public  IGroup AllOf<T1, T2>() where T1 : IComponent where T2 : IComponent
		{ return this.GetGroup(Matcher<C, T1, T2>.All()); }
		public  IGroup AllOf<T1, T2, T3>() where T1 : IComponent where T2 : IComponent where T3 : IComponent
		{ return this.GetGroup(Matcher<C, T1, T2, T3>.All()); }
		public  IGroup AllOf<T1, T2, T3, T4>() where T1 : IComponent where T2 : IComponent where T3 : IComponent where T4 : IComponent
		{ return this.GetGroup(Matcher<C, T1, T2, T3, T4>.All()); }
		public  IGroup AllOf<T1, T2, T3, T4, T5>() where T1 : IComponent where T2 : IComponent where T3 : IComponent where T4 : IComponent where T5 : IComponent
		{ return this.GetGroup(Matcher<C, T1, T2, T3, T4, T5>.All()); }
		public  IGroup AllOf<T1, T2, T3, T4, T5, T6>() where T1 : IComponent where T2 : IComponent where T3 : IComponent where T4 : IComponent where T5 : IComponent where T6 : IComponent
		{ return this.GetGroup(Matcher<C, T1, T2, T3, T4, T5, T6>.All()); }

		public  IGroup AnyOf<T1>() where T1 : IComponent
		{ return this.GetGroup(Matcher<C, T1>.Any()); }
		public  IGroup AnyOf<T1, T2>() where T1 : IComponent where T2 : IComponent
		{ return this.GetGroup(Matcher<C, T1, T2>.Any()); }
		public  IGroup AnyOf<T1, T2, T3>() where T1 : IComponent where T2 : IComponent where T3 : IComponent
		{ return this.GetGroup(Matcher<C, T1, T2, T3>.Any()); }
		public  IGroup AnyOf<T1, T2, T3, T4>() where T1 : IComponent where T2 : IComponent where T3 : IComponent where T4 : IComponent
		{ return this.GetGroup(Matcher<C, T1, T2, T3, T4>.Any()); }
		public  IGroup AnyOf<T1, T2, T3, T4, T5>() where T1 : IComponent where T2 : IComponent where T3 : IComponent where T4 : IComponent where T5 : IComponent
		{ return this.GetGroup(Matcher<C, T1, T2, T3, T4, T5>.Any()); }
		public  IGroup AnyOf<T1, T2, T3, T4, T5, T6>() where T1 : IComponent where T2 : IComponent where T3 : IComponent where T4 : IComponent where T5 : IComponent where T6 : IComponent
		{ return this.GetGroup(Matcher<C, T1, T2, T3, T4, T5, T6>.Any()); }
	}

   // public class DefaultMatcher : Context<Default>
   // {
   //     public DefaultMatcher(Context Instance) : base(Instance)
   //     {
   //     }
   // }
   // public static class DefaultMatcherExtension 
   // {
   //     public static DefaultMatcher GetMatcher(this Context context)
   //     {
			//if(context.Matcher == null)
			//{
			//	context.Matcher = new DefaultMatcher(context);

   //         }
   //         return context.Matcher as DefaultMatcher;
   //     }
   // }
}
