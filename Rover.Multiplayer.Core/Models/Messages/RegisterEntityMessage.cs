using System;

namespace Rover.Multiplayer.Core.Models.Messages {

    [Serializable]
    public class RegisterEntityMessage : MessageBase {

        public Guid EntityId { get; set; }

    }

}