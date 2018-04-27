using System;
using System.Windows;
using Rover.Platform.Entities;
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

            _world = new World {
                OnUpdate = () => { Application.Current.Dispatcher.Invoke(() => { MainScreen.Source = _world.DrawerComponent.DrawableBytes.ToBitmapSource(); }); }
            };
            _world.DrawerComponent.Init((int) Width, (int) Height);
            _world.Controller = new KeyboardController();

            var hero = new Hero();

            _world.Controller.Controllable = hero;
            _world.DrawerComponent.Add(hero);
            _world.Start();
        }

    }

}