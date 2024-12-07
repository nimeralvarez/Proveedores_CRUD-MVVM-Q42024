

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proveedores_CRUD_MVVM_Q42024.Models;
using Proveedores_CRUD_MVVM_Q42024.Services;

namespace Proveedores_CRUD_MVVM_Q42024.ViewModels
{
    public partial class ProveedorFormViewModel: ObservableObject
    {
        [ObservableProperty] private int idProveedor;
        [ObservableProperty] private string nombreEmpresa;
        [ObservableProperty] private string rtn;
        [ObservableProperty] private string direccion;
        [ObservableProperty] private string telefono;

        private readonly ProveedorService service;

        public ProveedorFormViewModel()
        {
            service = new ProveedorService();
        }

        public ProveedorFormViewModel(Proveedor proveedor)
        {
            service=new ProveedorService();
            IdProveedor = proveedor.IdProveedor;
            NombreEmpresa=proveedor.NombreEmpresa;
            Rtn=proveedor.Rtn;
            Direccion=proveedor.Direccion;
            Telefono=proveedor.Telefono;
        }

        private void Alerta(string titulo, string mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async()=> await App.Current!.MainPage!.DisplayAlert(titulo, mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Proveedor proveedor = new Proveedor();
                proveedor.IdProveedor = IdProveedor;
                proveedor.NombreEmpresa = NombreEmpresa;
                proveedor.Rtn = Rtn;
                proveedor.Direccion = Direccion;
                proveedor.Telefono = Telefono;

                if (Validar(proveedor))
                {
                    if (IdProveedor == 0)
                    {
                        service.Insert(proveedor);
                    }
                    else
                    {
                        service.Update(proveedor);
                    }

                    // Regresa a la pantalla principal
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }

            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        private bool Validar(Proveedor proveedor)
        {
            if(proveedor.NombreEmpresa == null || proveedor.NombreEmpresa == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el nombre de la empresa proveedora");
                return false;
            }else if(proveedor.Rtn == null || proveedor.Rtn == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el RTN del proveedor");
                return false;
            }else if (proveedor.Direccion == null || proveedor.Direccion == "")
            {
                Alerta("ADVERTENCIA", "Ingrese la dirección del proveedor");
                return false;
            }else if (proveedor.Telefono == null || proveedor.Telefono == "") 
            {
                Alerta("ADVERTENCIA", "Ingrese el telefono del proveedor");
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
