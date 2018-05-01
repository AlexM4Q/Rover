using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Rover.Platform.Entities.Base;
using Rover.Platform.Services;

namespace Rover.Platform {

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
                    OnUpdate?.Invoke();

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

        public T GetService<T>() where T : IService => (T) Services.FirstOrDefault(s => s is T);

        private enum Status {

            Stopped,
            Working

        }

    }

}