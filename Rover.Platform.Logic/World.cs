using System;
using System.Collections.Generic;
using System.Threading;
using Rover.Platform.Logic.Entities.Base;
using Rover.Platform.Logic.Services;

namespace Rover.Platform.Logic {

    public class World {

        public readonly List<IService> Services;

        public readonly List<IEntity> Entities;

        public Action OnUpdate { get; set; }

        public int UpdateDelay { get; set; } = 10;

        private readonly Thread _process;

        private Status _status;

        public World() {
            Services = new List<IService>();
            Entities = new List<IEntity>();

            _status = Status.Stopped;
            _process = new Thread(() => {
                while (_status == Status.Working) {
                    Services.ForEach(e => e.Update(Entities));
                    OnUpdate();

                    Thread.Sleep(UpdateDelay);
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