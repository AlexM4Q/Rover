using System;
using System.Linq;
using Rover.Multiplayer.Core.Models.Messages;
using Rover.Platform;
using Rover.Platform.Entities;
using Rover.Platform.Entities.Base;
using Rover.Platform.Services;

namespace Rover.Multiplayer.Server {

    public class ServerContext : IDisposable {

        private static ServerContext _instance;

        public static ServerContext Instance => _instance ?? (_instance = new ServerContext());

        public readonly World World;

        public readonly RoverServer Server;

        public ServerContext() {
            World = new World {
                OnUpdate = Update
            };
            World.Services.Add(new HeroService());
            World.Services.Add(new DrawerService(500, 500));

            Server = new RoverServer(12321);
        }

        private void Update() {
            BroadcastMap();
        }

        public void Start() {
            World.Start();
            Server.Start();
        }

        public void Dispose() {
            Server.Stop();
            World.Stop();
        }

        public void OnRegisterHeroMessage(RegisterHeroMessage message) {
            World.Entities.Add(new Hero(message.EntityId) {
                Velocity = message.Velocity
            });
        }

        public void OnMoveMessage(MoveMessage message) {
            var entity = World.Entities.FirstOrDefault(e => e.Id == message.EntityId);
            if (entity is Hero hero) {
                hero.Direction = message.Direction;
            }
        }

        private void BroadcastMap() {
            var map = World.GetService<DrawerService>().DrawableBytes;
            var mapMessage = new MapMessage {DrawableBytes = map};
            foreach (var connection in Server.Connections) {
                connection.SendViaTcp(mapMessage);
            }
        }

    }

}