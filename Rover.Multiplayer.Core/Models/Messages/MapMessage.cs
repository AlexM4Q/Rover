using System;
using Rover.Platform.Data;

namespace Rover.Multiplayer.Core.Models.Messages {

    [Serializable]
    public class MapMessage : MessageBase {

        public DrawableBytes DrawableBytes { get; set; }

    }

}