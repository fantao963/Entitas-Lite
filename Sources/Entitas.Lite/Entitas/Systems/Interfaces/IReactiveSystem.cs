namespace Entitas {

    public interface IReactiveSystem : IExecuteSystem , IInitializeSystem
    {

        void Activate();
        void Deactivate();
        void Clear();
    }
}
