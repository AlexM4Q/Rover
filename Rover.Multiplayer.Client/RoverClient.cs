using System;
using System.Net.Sockets;
using System.Threading;
using Rover.Multiplayer.Core.Connection;
using Rover.Multiplayer.Core.Models.Messages;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;
using Rover.Platform.Services;

namespace Rover.Multiplayer.Client {

    /// <summary>
    /// Клиент
    /// </summary>
    public sealed class RoverClient : ClientConnection, IMoveable {

        public IControllerService ControllerService { get; set; }

        public Action<MapMessage> OnMapMessage { get; set; }

        /// <summary>
        /// Поток отправки сообщений
        /// </summary>
        private readonly Thread _gameThread;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="adress">IP сервера</param>
        /// <param name="tcpPort">потр TCP клиента</param>
        public RoverClient(string adress, int tcpPort) : base(new TcpClient()) {
            TcpClient.Connect(adress, tcpPort);
            Status = Status.Connected;

            _gameThread = new Thread(() => {
                while (Status == Status.Connected) {
                    ControllerService.Update();
                }
            });

            Start();
        }

        protected override void Start() {
            base.Start();

            _gameThread.Start();
        }

        protected override void OnTcpMessageReceived(MessageBase message) {
            switch (message) {
                case MapMessage mapMessage:
                    OnMapMessage?.Invoke(mapMessage);
                    break;
            }
        }

        public void Move(Vector direction) {
            SendViaTcp(new MoveMessage {Direction = direction});
        }

    }

}