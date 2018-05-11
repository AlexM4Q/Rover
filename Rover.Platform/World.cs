using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Rover.Platform.Entities.Base;
using Rover.Platform.Services.Base;

namespace Rover.Platform {

    public class World : IDisposable {

        private static World _instance;

        public static World Instance => _instance ?? (_instance = new World());

        private readonly ConcurrentBag<IService> _services;

        public IReadOnlyCollection<IService> Services => _services;

        private readonly ConcurrentBag<IEntity> _entities;

        public IReadOnlyCollection<IEntity> Entities => _entities;

        private readonly Thread _process;

        public Action OnUpdate { get; set; }

        public int UpdateDelay { get; set; } = 10;

        private Status _status;

        private World() {
            _services = new ConcurrentBag<IService>();
            _entities = new ConcurrentBag<IEntity>();

            _status = Status.Stopped;
            _process = new Thread(() => {
                while (_status == Status.Working) {
                    foreach (var service in _services) {
                        service.Update(Entities);
                    }

                    OnUpdate?.Invoke();

                    Thread.Sleep(UpdateDelay);
                }
            });
        }

        public void Start() {
            _status = Status.Working;
            _process.Start();
        }

        public void Dispose() {
            _status = Status.Stopped;
        }

        public T GetService<T>() where T : IService => (T) _services.FirstOrDefault(s => s is T);

        public void AddEntity(IEntity entity) {
            _entities.Add(entity);
        }

        public void AddService(IService service) {
            _services.Add(service);
        }

        private enum Status {

            Stopped,
            Working

        }

    }

}