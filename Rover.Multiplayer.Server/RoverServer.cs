using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Rover.Multiplayer.Server {

    public class RoverServer {

        private readonly IList<RoverConnection> _connections;

        public IReadOnlyList<RoverConnection> Connections => _connections as IReadOnlyList<RoverConnection>;

        private readonly int _tcpPort;

        private TcpListener _tcpListener;

        private bool _isStarted;

        public Action<RoverConnection> OnClientConnected { get; set; }

        public RoverServer(int tcpPort) {
            _connections = new List<RoverConnection>();

            _tcpPort = tcpPort;
        }

        public void Start() {
            if (_isStarted) return;

            _tcpListener = new TcpListener(IPAddress.Any, _tcpPort);
            _tcpListener.Start();

            _isStarted = true;

            WaitForConnection();
        }

        public void Stop() {
            if (!_isStarted) return;

            _tcpListener.Stop();
            _isStarted = false;
        }

        private void WaitForConnection() {
            _tcpListener.BeginAcceptTcpClient(ConnectionHandler, null);
        }

        private void ConnectionHandler(IAsyncResult ar) {
            lock (_connections) {
                var connection = new RoverConnection(_tcpListener.EndAcceptTcpClient(ar));
                _connections.Add(connection);
                OnClientConnected?.Invoke(connection);
            }

            WaitForConnection();
        }

    }

}