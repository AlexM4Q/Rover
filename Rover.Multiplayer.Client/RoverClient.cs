using System;
using System.Net.Sockets;
using System.Threading;
using Rover.Multiplayer.Core.Connection;
using Rover.Multiplayer.Core.Models.Messages;
using Rover.Platform.Adapters;
using Rover.Platform.Data;
using Rover.Platform.Entities;
using Rover.Platform.Services.Base;

namespace Rover.Multiplayer.Client {

    /// <summary>
    /// Клиент
    /// </summary>
    public sealed class RoverClient : ClientConnection, IHeroAdaptable {

        /// <summary>
        /// Идентификатор
        /// </summary>
        private readonly Hero _hero;

        /// <summary>
        /// Поток отправки сообщений
        /// </summary>
        private readonly Thread _gameThread;

        public IControllerService ControllerService { get; set; }

        public Action<MapMessage> OnMapMessage { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="adress">IP сервера</param>
        /// <param name="tcpPort">потр TCP клиента</param>
        public RoverClient(string adress, int tcpPort) : base(new TcpClient()) {
            TcpClient.Connect(adress, tcpPort);
            Status = Status.Connected;

            _hero = new Hero(Guid.NewGuid());
            _gameThread = new Thread(() => {
                while (Status == Status.Connected) {
                    ControllerService?.Update();
                }
            });

            Start();
        }

        protected override void Start() {
            base.Start();

            _gameThread.Start();

            SendViaTcp(new RegisterHeroMessage {
                EntityId = _hero.Id,
                Velocity = _hero.Velocity
            });
        }

        protected override void OnTcpMessageReceived(MessageBase message) {
            switch (message) {
                case MapMessage mapMessage:
                    OnMapMessage?.Invoke(mapMessage);
                    break;
            }
        }

        public void Move(Vector direction) {
            SendViaTcp(new MoveMessage {
                EntityId = _hero.Id,
                Direction = direction
            });
        }

        public void Fire(bool isFire) {
            SendViaTcp(new FireMessage {
                EntityId = _hero.Id,
                ShellType = _hero.ShellType,
                IsFire = isFire
            });
        }

    }

}