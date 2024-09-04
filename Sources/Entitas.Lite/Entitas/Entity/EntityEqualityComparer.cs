using System.Collections.Generic;

namespace Entitas {

    public class EntityEqualityComparer : IEqualityComparer<IEntity> {

        public static readonly IEqualityComparer<IEntity> comparer = new EntityEqualityComparer();

        public bool Equals(IEntity x, IEntity y) {
            return x == y;
        }

        public int GetHashCode(IEntity obj) {
            return obj.creationIndex;
        }
    }
}
