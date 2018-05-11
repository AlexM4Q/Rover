using System;

namespace Rover.Multiplayer.Core.Models.Messages {

    [Serializable]
    public class AdressedMessage : MessageBase {

        public Guid EntityId { get; set; }

    }

}