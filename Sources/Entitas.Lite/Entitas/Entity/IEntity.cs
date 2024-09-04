using System;
using System.Collections.Generic;

namespace Entitas {

    public delegate void EntityComponentChanged(
        IEntity entity, int index, IComponent component
    );

    public delegate void EntityComponentReplaced(
        IEntity entity, int index, IComponent previousComponent, IComponent newComponent
    );

    public delegate void EntityEvent(IEntity entity);

    public interface IEntity : IAERC {

        event EntityComponentChanged OnComponentAdded;
        event EntityComponentChanged OnComponentRemoved;
        event EntityComponentReplaced OnComponentReplaced;
        event EntityEvent OnEntityReleased;
        event EntityEvent OnDestroyEntity;

        int totalComponents { get; }
        int creationIndex { get; }
        bool isEnabled { get; }

        Stack<IComponent>[] componentPools { get; }
        ContextInfo contextInfo { get; }
        IAERC aerc { get; }
        string name { get; set; }

        void Initialize(int creationIndex,
                        int totalComponents,
                        Stack<IComponent>[] componentPools,
                        ContextInfo contextInfo = null,
                        IAERC aerc = null);

        void Reactivate(int creationIndex);

        void AddComponent(int index, IComponent component);
        void RemoveComponent(int index);
        void ReplaceComponent(int index, IComponent component);

        IComponent GetComponent(int index);
        IComponent[] GetComponents();
        int[] GetComponentIndices();

        bool HasComponent(int index);
        bool HasComponents(int[] indices);
        bool HasAnyComponent(int[] indices);

        void RemoveAllComponents();

        Stack<IComponent> GetComponentPool(int index);
        IComponent CreateComponent(int index, Type type);
        T CreateComponent<T>(int index) where T : new();

        void Destroy();
        void InternalDestroy();
        void RemoveAllOnEntityReleasedHandlers();
        T Get<T>() where T : IComponent;
        T Add<T>(bool useExisted = true) where T : IComponent, new();
        T AddComponent<T>(bool useExisted = true) where T : IComponent, new();
        T ReplaceNew<T>() where T : IComponent, new();
        T ReplaceNewComponent<T>() where T : IComponent, new();
        void Remove<T>(bool ignoreNotFound = true) where T : IComponent;
        void RemoveComponent<T>(bool ignoreNotFound = true) where T : IComponent;
        bool Has<T>() where T : IComponent;
        bool HasComponent<T>() where T : IComponent;
        T GetComponent<T>() where T : IComponent;
        T Modify<T>() where T : IComponent;
        T ModifyComponent<T>() where T : IComponent;
        IComponent ModifyComponent(int index);
        void SetModified<T>() where T : IComponent, new();
        void SetModified(int index);
    }
}
