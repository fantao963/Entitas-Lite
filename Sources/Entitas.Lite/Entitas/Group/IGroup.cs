using System.Collections;
using System.Collections.Generic;

namespace Entitas {

    public delegate void GroupChanged(IGroup group, IEntity entity, int index, IComponent component);
    public delegate void GroupUpdated(IGroup group, IEntity entity, int index, IComponent previousComponent, IComponent newComponent);

    public interface IGroup : IEnumerable<IEntity> {

        int count { get; }

        void RemoveAllEventHandlers();

		event GroupChanged OnEntityAdded;
		event GroupChanged OnEntityRemoved;
		event GroupUpdated OnEntityUpdated;

		IMatcher matcher { get; }

		void HandleEntitySilently(IEntity entity);
		void HandleEntity(IEntity entity, int index, IComponent component);

		GroupChanged HandleEntity(IEntity entity);

		void UpdateEntity(IEntity entity, int index, IComponent previousComponent, IComponent newComponent);

		bool ContainsEntity(IEntity entity);

        IEntity[] GetEntities();
        IEntity GetSingleEntity();
	}
}
