using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Rover.Multiplayer.Server {

    public class RoverServer {

        private readonly IList<RoverConnection> _connections;

        private readonly int _tcpPort;

        private readonly int _udpReceivePort;

        private readonly int _udpSendPort;

        private TcpListener _tcpListener;

        private bool _isStarted;

        public IReadOnlyList<RoverConnection> Connections => _connections as IReadOnlyList<RoverConnection>;

        public Action<RoverConnection> OnClientConnected { get; set; }

        public RoverServer(int tcpPort, int udpReceivePort, int udpSendPort) {
            _connections = new List<RoverConnection>();

            _tcpPort = tcpPort;
            _udpReceivePort = udpReceivePort;
            _udpSendPort = udpSendPort;
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
                var connection = new RoverConnection(_tcpListener.EndAcceptTcpClient(ar), _udpReceivePort, _udpSendPort);
                _connections.Add(connection);
                OnClientConnected?.Invoke(connection);
            }

            WaitForConnection();
        }

    }

}