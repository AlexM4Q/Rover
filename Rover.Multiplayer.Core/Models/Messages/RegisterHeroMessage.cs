using System;
using Rover.Platform.Data;

namespace Rover.Multiplayer.Core.Models.Messages {

    [Serializable]
    public class RegisterHeroMessage : RegisterEntityMessage {

        public Vector Velocity { get; set; }

    }

}