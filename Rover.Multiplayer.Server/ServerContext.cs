using System;
using System.Linq;
using Rover.Multiplayer.Core.Models.Messages;
using Rover.Platform;
using Rover.Platform.Entities;
using Rover.Platform.Services;

namespace Rover.Multiplayer.Server {

    public class ServerContext : IDisposable {

        private static ServerContext _instance;

        public static ServerContext Instance => _instance ?? (_instance = new ServerContext());

        public readonly World World;

        public readonly RoverServer Server;

        private ServerContext() {
            World = World.Instance;
            World.OnUpdate = Update;
            World.AddService(new MoverService());
            World.AddService(new DrawerService(500, 500));

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
            Server.Dispose();
            World.Dispose();
        }

        public void OnRegisterHeroMessage(RegisterHeroMessage message) {
            World.AddEntity(new Hero(message.EntityId) {
                Velocity = message.Velocity
            });
        }

        public void OnMoveMessage(MoveMessage message) {
            var entity = World.Entities.FirstOrDefault(e => e.Id == message.EntityId);
            if (entity is Hero hero) {
                hero.Direction = message.Direction;
            }
        }

        public void OnFireMessage(FireMessage message) {
            var entity = World.Entities.FirstOrDefault(e => e.Id == message.EntityId);
            if (entity is Hero hero) {
                hero.FireType = message.FireType;
                hero.IsFire = message.IsFire;
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