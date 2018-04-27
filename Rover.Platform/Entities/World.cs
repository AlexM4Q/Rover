using System;
using System.Collections.Generic;
using System.Threading;
using Rover.Platform.Entities.Components;
using Rover.Platform.Entities.Controller;

namespace Rover.Platform.Entities {

    public class World {

        public List<IWorldComponent> Components { get; set; }

        public Action OnUpdate { get; set; }

        private DrawerComponent _drawerComponent;

        public DrawerComponent DrawerComponent {
            get {
                if (_drawerComponent != null) return _drawerComponent;
                Components.Add(_drawerComponent = new DrawerComponent());
                return _drawerComponent;
            }
        }

        private IController _controller;

        public IController Controller {
            get => _controller;
            set {
                Components.Remove(_controller);
                _controller = value;
                if (_controller != null) {
                    Components.Add(_controller);
                }
            }
        }

        private readonly Thread _process;

        private Status _status;

        public World() {
            Components = new List<IWorldComponent>();

            _status = Status.Stopped;
            _process = new Thread(() => {
                while (_status == Status.Working) {
                    Components.ForEach(e => e.Update());
                    OnUpdate();

                    Thread.Sleep(10);
                }
            }) {IsBackground = true};
        }

        public void Start() {
            _status = Status.Working;
            _process.Start();
        }

        public void Stop() {
            _status = Status.Stopped;
        }

        private enum Status {

            Stopped,
            Working

        }

    }

}