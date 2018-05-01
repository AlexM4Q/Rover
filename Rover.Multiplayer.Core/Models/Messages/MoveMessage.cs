using System;
using Rover.Platform.Data;

namespace Rover.Multiplayer.Core.Models.Messages {

    public class MoveMessage : MessageBase {

        public Guid EntityId { get; set; }

        public Vector Direction { get; set; }

    }

}