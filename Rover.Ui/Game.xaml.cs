using System.Windows;
using Rover.Multiplayer.Client;
using Rover.Platform;
using Rover.Platform.Adapters;
using Rover.Platform.Entities;
using Rover.Platform.Services;
using Rover.Ui.Components;
using Rover.Ui.Extensions;

namespace Rover.Ui {

    public partial class MainWindow {

        public MainWindow() {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
//            var hero = new Hero();
//
//            var heroService = new MoverService();
//            var drawerService = new DrawerService((int) Width, (int) Height);
//            var contrllerService = new KeyboardControllerService {Controllable = hero};
//
//            var world = World.Instance;
//
//            world.OnUpdate = () => Application.Current.Dispatcher.Invoke(() => MainScreen.Source = drawerService.DrawableBytes.ToBitmapSource());
//            world.Services.Add(heroService);
//            world.Services.Add(drawerService);
//            world.Services.Add(contrllerService);
//            world.Entities.Add(hero);
//            world.Start();

            var client = new RoverClient("localhost", 12321) {
                OnMapMessage = message => Application.Current.Dispatcher.Invoke(() => MainScreen.Source = message.DrawableBytes.ToBitmapSource())
            };

            client.ControllerService = new KeyboardControllerService {Controllable = new HeroAdapter(client)};
        }

    }

}