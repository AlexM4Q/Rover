using System;
using Rover.Platform.Constants;

namespace Rover.Multiplayer.Core.Models.Messages {

    [Serializable]
    public class FireMessage : AdressedMessage {

        public ShellType ShellType { get; set; }

        public bool IsFire { get; set; }

    }

}