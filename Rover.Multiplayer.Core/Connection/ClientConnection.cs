using System;
using System.Net.Sockets;
using Rover.Multiplayer.Core.Models.Messages;

namespace Rover.Multiplayer.Core.Connection {

    /// <summary>
    /// Клиент подключение
    /// </summary>
    public abstract class ClientConnection : IDisposable {

        /// <summary>
        /// TCP соединение
        /// </summary>
        protected readonly TcpConnection TcpConnection;

        /// <summary>
        /// Статус соединения
        /// </summary>
        protected Status Status { get; set; }

        public TcpClient TcpClient => TcpConnection.TcpClient;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="client">TCP клиент</param>
        /// <param name="udpReceivePort">порт UDP приема</param>
        /// <param name="udpSendPort">порт UDP отправки</param>
        protected ClientConnection(TcpClient client, int udpReceivePort, int udpSendPort) {
            TcpConnection = new TcpConnection(client) {
                OnMessage = OnTcpMessageReceived,
                GetStatus = () => Status
            };
        }   

        /// <summary>
        /// Запуск соединений
        /// </summary>
        protected void Start() {
            TcpConnection.Start();
        }

        /// <summary>
        /// Завершение соединений
        /// </summary>
        public void Dispose() {
            Status = Status.Disconnected;
            TcpConnection.Dispose();
        }

        /// <summary>
        /// Отправка по TCP
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void SendViaTcp(MessageBase message) => TcpConnection.Send(message);

        /// <summary>
        /// Получение сообщения по TCP
        /// </summary>
        /// <param name="message">Сообщение</param>
        protected abstract void OnTcpMessageReceived(MessageBase message);

    }

}