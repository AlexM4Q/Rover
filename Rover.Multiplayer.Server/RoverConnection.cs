using System.Net.Sockets;
using Rover.Multiplayer.Core.Connection;
using Rover.Multiplayer.Core.Models.Messages;
using Rover.Platform.Entities;

namespace Rover.Multiplayer.Server {

    public sealed class RoverConnection : ClientConnection {

        public RoverConnection(TcpClient client) : base(client) {
            Status = Status.Connected;

            Start();
        }

        protected override void OnTcpMessageReceived(MessageBase message) {
            switch (message) {
                case RegisterHeroMessage registerHeroMessage:
                    ServerContext.Instance.OnRegisterHeroMessage(registerHeroMessage);
                    break;
                case MoveMessage moveMessage:
                    ServerContext.Instance.OnMoveMessage(moveMessage);
                    break;
            }
        }

    }

}