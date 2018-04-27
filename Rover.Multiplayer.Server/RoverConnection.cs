using System;
using System.Net.Sockets;
using Rover.Multiplayer.Core.Connection;
using Rover.Multiplayer.Core.Models.Messages;

namespace Rover.Multiplayer.Server {

    public class RoverConnection : ClientConnection {

        public Action OnProcessesListRequest { get; set; }

        public RoverConnection(TcpClient client, int udpReceivePort, int udpSendPort) : base(client, udpReceivePort, udpSendPort) {
            Status = Status.Connected;

            Start();
        }

        protected override void OnTcpMessageReceived(MessageBase message) {
            switch (message) {
                case MessageBase _:
                    OnProcessesListRequest?.Invoke();
                    break;
            }
        }

    }

}