using System;
using Rover.Platform.Data;
using Rover.Platform.Entities;
using Rover.Platform.Entities.Base;

namespace Rover.Platform.Adapters {

    public class HeroAdapter : IControllable {

        public Vector Direction {
            get => throw new NotImplementedException();
            set => _heroAdaptable?.Move(value);
        }

        private bool _isFire;

        public bool IsFire {
            get => _isFire;
            set {
                if (_isFire == value) return;
                _isFire = value;
                if (value) {
                    var now = DateTime.Now.Ticks;
                    if (now - _lastFireTicks <= _fireDelayTicks) return;

                    _lastFireTicks = now;
                    _heroAdaptable.Fire(true);
                } else {
                    _heroAdaptable.Fire(false);
                }
            }
        }

        private long _fireDelayTicks;

        public long FireDelayMilliSeconds {
            get => _fireDelayTicks / TimeSpan.TicksPerMillisecond;
            set => _fireDelayTicks = value * TimeSpan.TicksPerMillisecond;
        }

        private long _lastFireTicks;

        private readonly IHeroAdaptable _heroAdaptable;

        public HeroAdapter(IHeroAdaptable heroAdaptable) {
            _heroAdaptable = heroAdaptable;
            FireDelayMilliSeconds = 100;
        }

    }

}