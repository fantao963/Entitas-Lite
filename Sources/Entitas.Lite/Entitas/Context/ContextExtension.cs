namespace Entitas {

    public static class ContextExtension {

        /// Returns all entities matching the specified matcher.
        public static IEntity[] GetEntities(this IContext context, IMatcher matcher) {
            return context.GetGroup(matcher).GetEntities();
        }

        /// Creates a new entity and adds copies of all
        /// specified components to it.
        /// If replaceExisting is true it will replace exisintg components.
        public static IEntity CloneEntity(this IContext context,
                                          IEntity entity,
                                          bool replaceExisting = false,
                                          params int[] indices)
        {
            var target = context.CreateEntity();
            entity.CopyTo(target, replaceExisting, indices);
            return target;
        }
    }
}
