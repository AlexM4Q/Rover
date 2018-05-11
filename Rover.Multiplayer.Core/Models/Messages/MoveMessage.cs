using System;
using Rover.Platform.Data;

namespace Rover.Multiplayer.Core.Models.Messages {

    [Serializable]
    public class MoveMessage : AdressedMessage {

        public Vector Direction { get; set; }

    }

}