﻿
using Proveedores_CRUD_MVVM_Q42024.Views;
namespace Proveedores_CRUD_MVVM_Q42024
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new ProveedorMainView()));
        }
    }
}