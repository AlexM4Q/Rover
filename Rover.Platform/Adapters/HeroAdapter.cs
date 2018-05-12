using System;
using Rover.Platform.Data;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Adapters {

    public class HeroAdapter : IControllable {

        private Vector _direction;

        public Vector Direction {
            get => _direction;
            set {
                if (_direction.Equals(value)) return;
                _direction = value;
                _heroAdaptable?.Move(value);
            }
        }

        private bool _isFire;

        public bool IsFire {
            get => _isFire;
            set {
                if (_isFire == value) return;
                _isFire = value;
                if (value) {
                    var now = DateTime.Now.Ticks;
                    if (now - _lastFireTicks < FireDelayTicks) return;

                    _lastFireTicks = now;
                    _heroAdaptable?.Fire(true);
                } else {
                    _heroAdaptable?.Fire(false);
                }
            }
        }

        private readonly IHeroAdaptable _heroAdaptable;

        public long FireDelayTicks { get; set; } = 10000000L;

        private long _lastFireTicks;

        public HeroAdapter(IHeroAdaptable heroAdaptable) {
            _heroAdaptable = heroAdaptable;
        }

    }

}