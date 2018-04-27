using System;
using ProtoBuf;

namespace Rover.Multiplayer.Core.Models.Messages {

    [Serializable]
    [ProtoContract]
    [ProtoInclude(500, typeof(MessageBase))]
    public class MessageBase {

    }

}