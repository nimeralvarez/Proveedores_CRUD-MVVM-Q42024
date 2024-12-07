

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proveedores_CRUD_MVVM_Q42024.Models;
using Proveedores_CRUD_MVVM_Q42024.Services;
using Proveedores_CRUD_MVVM_Q42024.Views;
using System.Collections.ObjectModel;

namespace Proveedores_CRUD_MVVM_Q42024.ViewModels
{
    public partial class ProveedorMainViewModel:ObservableObject
    {
        [ObservableProperty] private ObservableCollection<Proveedor> proveedorCollection= new ObservableCollection<Proveedor>();
        private readonly ProveedorService service;

        public ProveedorMainViewModel()
        {
            service = new ProveedorService();
        }

        private void Alerta(string titulo, string mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async()=> await App.Current!.MainPage!.DisplayAlert(titulo, mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var getAll=service.GetAll();
            if (getAll.Count > 0)
            {
                ProveedorCollection.Clear();
                foreach (var proveedor in getAll)
                {
                    ProveedorCollection.Add(proveedor);
                }
            }
        }

        [RelayCommand]
        private async Task GoToProveedorFormView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new ProveedorFormView());
        }

        [RelayCommand]
        private async Task GotoEditProveedorFormView(Proveedor proveedor)
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new ProveedorFormView(proveedor));
        }

        private async Task ElmininarProveedor(Proveedor proveedor)
        {
            try
            {
                bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR PROVEEDOR", "¿Desea eliminar proveedor?", "Si", "No");
                if (respuesta)
                {
                    int del = service.Delete(proveedor);
                    if (del > 0)
                    {
                        Alerta("ELIMINAR PROVEEDOR", "Proveedor eliminado correctamente");
                        ProveedorCollection.Remove(proveedor);
                    }
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }


        [RelayCommand]
        private async Task SelectProveedor(Proveedor proveedor)
        {
            try
            {
                const string ACTUALIZAR = "Actualizar";
                const string ELIMINAR = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if(res == ACTUALIZAR)
                {
                    await GotoEditProveedorFormView(proveedor);
                }else if(res == ELIMINAR)
                {
                    await ElmininarProveedor(proveedor);
                }

            }catch(Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }
     
    }
}
