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
        /// Действие при получении сообщения с изображением экрана
        /// </summary>
        public Action<MessageBase> OnProcessScreenMessage { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="adress">IP сервера</param>
        /// <param name="tcpPort">потр TCP клиента</param>
        /// <param name="udpReceivePort">порт UDP приема</param>
        /// <param name="udpSendPort">порт UDP отправки</param>
        public RoverClient(string adress, int tcpPort, int udpReceivePort, int udpSendPort) : base(new TcpClient(), udpReceivePort, udpSendPort) {
            TcpClient.Connect(adress, tcpPort);
            Status = Status.Connected;

            Start();
        }

        protected override void OnTcpMessageReceived(MessageBase message) {
            switch (message) {
                case MessageBase processScreenMessage:
                    OnProcessScreenMessage?.Invoke(processScreenMessage);
                    break;
            }
        }

    }

}