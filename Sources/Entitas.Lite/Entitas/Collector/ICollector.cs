using System.Collections.Generic;

namespace Entitas {

    public interface ICollector {

        int count { get; }

		void Activate();
		void Deactivate();
		void ClearCollectedEntities();

        IEnumerable<IEntity> GetCollectedEntities();

		HashSet<IEntity> collectedEntities { get; }
	}
}
