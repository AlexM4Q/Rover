using System;

namespace Rover.Platform.Entities {

    [Serializable]
    public class Shell : MoveableEntity {

        protected Shell() : this(Guid.NewGuid()) {
        }

        protected Shell(Guid id) : base(id) {
        }

    }

}