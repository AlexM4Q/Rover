using System;
using System.Windows;
using Rover.Game.Entities;
using Rover.Platform.Logic;
using Rover.Platform.Logic.Entities;
using Rover.Platform.View.Services;
using Rover.Ui.Components;
using Rover.Ui.Extensions;

namespace Rover.Ui {

    public partial class MainWindow {

        private World _world;

        public MainWindow() {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e) {
            base.OnInitialized(e);

            var hero = new Hero();

            var drawerService = new DrawerService();
            drawerService.Init((int) Width, (int) Height);

            var contrllerService = new KeyboardControllerService {Moveable = hero};

            _world = new World {
                OnUpdate = () => Application.Current.Dispatcher.Invoke(() => MainScreen.Source = drawerService.DrawableBytes.ToBitmapSource())
            };

            _world.Services.Add(drawerService);
            _world.Services.Add(contrllerService);
            _world.Entities.Add(hero);
            _world.Start();
        }

    }

}