using System;
using Rover.Platform.Logic;

namespace Rover.Multiplayer.Server {

    public class ServerContext : IDisposable {

        public readonly World World;

        private readonly RoverServer _server;

        public ServerContext() {
            World = new World();
            World.Start();

            _server = new RoverServer(60697);
            _server.Start();
        }

        public void Dispose() {
            _server.Stop();
            World.Stop();
        }

    }

}