using System.Collections.Generic;
using Rover.Platform.Entities.Base;
using Rover.Platform.Entities.Data;

namespace Rover.Platform.Entities.Components {

    public class DrawerComponent : IWorldComponent {

        public DrawableBytes DrawableBytes { get; set; }

        private ICollection<IDrawable> _drawables;

        public void Init(int widht, int height, ICollection<IDrawable> drawables = null) {
            DrawableBytes = new DrawableBytes(widht, height);
            _drawables = drawables ?? new List<IDrawable>();
        }

        public void Add(IDrawable drawable) => _drawables.Add(drawable);

        public void Update() {
            if (_drawables == null) return;

            foreach (var drawable in _drawables) {
                drawable.Draw(DrawableBytes);
            }
        }

    }

}