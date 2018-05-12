using System;
using Rover.Platform.Constants;
using Rover.Platform.Data;
using Rover.Platform.Entities;

namespace Rover.Platform.Factories {

    public static class ShellFactory {

        public static Shell CreateShell(this ShellType shellType) {
            switch (shellType) {
                case ShellType.Bullet:
                    return new Bullet();
                case ShellType.BulletBomb:
                    return new BulletBomb();
                default:
                    throw new ArgumentException(shellType.ToString());
            }
        }

        public static Shell CreateShell(this ShellType shellType, Vector position) {
            var shell = shellType.CreateShell();
            shell.Position = position;
            return shell;
        }

        public static Shell CreateShell(this ShellType shellType, Vector position, Vector direction) {
            var shell = shellType.CreateShell(position);
            shell.Direction = direction;
            return shell;
        }

    }

}