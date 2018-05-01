using System.Net.Sockets;
using Rover.Multiplayer.Core.Connection;
using Rover.Multiplayer.Core.Models.Messages;

namespace Rover.Multiplayer.Server {

    public sealed class RoverConnection : ClientConnection {

        public RoverConnection(TcpClient client) : base(client) {
            Status = Status.Connected;

            Start();
        }

        protected override void OnTcpMessageReceived(MessageBase message) {
            switch (message) {
                case MoveMessage moveMessage:
                    ServerContext.Instance.OnMoveMessage(moveMessage);
                    break;
            }
        }

    }

}