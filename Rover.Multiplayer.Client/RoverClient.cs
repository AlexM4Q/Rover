using System;
using System.Net.Sockets;
using Rover.Multiplayer.Core.Connection;
using Rover.Multiplayer.Core.Models.Messages;

namespace Rover.Multiplayer.Client {

    /// <summary>
    /// Клиент
    /// </summary>
    public class RoverClient : ClientConnection {

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="adress">IP сервера</param>
        /// <param name="tcpPort">потр TCP клиента</param>
        public RoverClient(string adress, int tcpPort) : base(new TcpClient()) {
            TcpClient.Connect(adress, tcpPort);
            Status = Status.Connected;

            Start();
        }

        protected override void OnTcpMessageReceived(MessageBase message) {
        }

    }

}