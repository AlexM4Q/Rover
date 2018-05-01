using System;
using System.Linq;
using Rover.Multiplayer.Core.Models.Messages;
using Rover.Platform;
using Rover.Platform.Entities.Base;
using Rover.Platform.Services;

namespace Rover.Multiplayer.Server {

    public class ServerContext : IDisposable {

        private static ServerContext _instance;

        public static ServerContext Instance => _instance ?? (_instance = new ServerContext());

        private readonly World _world;

        private readonly RoverServer _server;

        public ServerContext() {
            _world = new World();

            _server = new RoverServer(12321);
        }

        public void Start() {
            _world.Start();
            _server.Start();
        }

        public void Dispose() {
            _server.Stop();
            _world.Stop();
        }

        public void OnMoveMessage(MoveMessage message) {
            var entity = _world.Entities.FirstOrDefault(e => e.Id == message.EntityId);
            if (entity is IMoveable moveable) {
                moveable.Move(message.Direction);

                BroadcastMap();
            }
        }

        public void BroadcastMap() {
            var map = _world.GetService<DrawerService>().DrawableBytes;
            var mapMessage = new MapMessage {DrawableBytes = map};
            foreach (var connection in _server.Connections) {
                connection.SendViaTcp(mapMessage);
            }
        }

    }

}