using System;
using System.Collections.Generic;

namespace Entitas {

    public delegate void ContextEntityChanged(IContext context, IEntity entity);
    public delegate void ContextGroupChanged(IContext context, IGroup group);

    public interface IContext {

        event ContextEntityChanged OnEntityCreated;
        event ContextEntityChanged OnEntityWillBeDestroyed;
        event ContextEntityChanged OnEntityDestroyed;

        event ContextGroupChanged OnGroupCreated;

        int totalComponents { get; }

        Stack<IComponent>[] componentPools { get; }
        ContextInfo contextInfo { get; }

        int count { get; }
        int reusableEntitiesCount { get; }
        int retainedEntitiesCount { get; }

        void DestroyAllEntities();

        void ResetCreationIndex();
        void ClearComponentPool(int index);
        void ClearComponentPools();
        void Reset();

        IEntity CreateEntity();

		bool HasEntity(IEntity entity);
        IEntity[] GetEntities();

		IGroup GetGroup(IMatcher matcher);

        IGroup AllOf<T1>() where T1 : IComponent;
        IGroup AllOf<T1, T2>()
            where T1 : IComponent
            where T2 : IComponent;
        IGroup AllOf<T1, T2, T3>()
            where T1 : IComponent
            where T2 : IComponent
            where T3 : IComponent;
        IGroup AllOf<T1, T2, T3, T4>()
            where T1 : IComponent
            where T2 : IComponent
            where T3 : IComponent
            where T4 : IComponent;
        IGroup AllOf<T1, T2, T3, T4, T5>()
            where T1 : IComponent
            where T2 : IComponent
            where T3 : IComponent
            where T4 : IComponent
            where T5 : IComponent;
        IGroup AllOf<T1, T2, T3, T4, T5, T6>()
            where T1 : IComponent
            where T2 : IComponent
            where T3 : IComponent
            where T4 : IComponent
            where T5 : IComponent
            where T6 : IComponent;
        IGroup AnyOf<T1>() where T1 : IComponent;
        IGroup AnyOf<T1, T2>()
            where T1 : IComponent
            where T2 : IComponent;
        IGroup AnyOf<T1, T2, T3>()
            where T1 : IComponent
            where T2 : IComponent
            where T3 : IComponent;
        IGroup AnyOf<T1, T2, T3, T4>()
            where T1 : IComponent
            where T2 : IComponent
            where T3 : IComponent
            where T4 : IComponent;
        IGroup AnyOf<T1, T2, T3, T4, T5>()
            where T1 : IComponent
            where T2 : IComponent
            where T3 : IComponent
            where T4 : IComponent
            where T5 : IComponent;
        IGroup AnyOf<T1, T2, T3, T4, T5, T6>()
            where T1 : IComponent
            where T2 : IComponent
            where T3 : IComponent
            where T4 : IComponent
            where T5 : IComponent
            where T6 : IComponent;
        int GetComponentIndex<T>() where T : IComponent;
        T GetUnique<T>() where T : IComponent, IUnique;
        T AddUnique<T>(bool useExisted = true) where T : IComponent, IUnique, new();
        T ModifyUnique<T>() where T : IComponent, IUnique;
        IEntity GetSingleEntity<T>() where T : IComponent, IUnique;
        IEntity GetEntity(int creationIndex);
        IEntity GetSingleEntity(int componentIndex);
    }
}
