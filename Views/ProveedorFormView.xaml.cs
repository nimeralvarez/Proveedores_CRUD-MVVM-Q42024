
using Proveedores_CRUD_MVVM_Q42024.ViewModels;
using Proveedores_CRUD_MVVM_Q42024.Models;

namespace Proveedores_CRUD_MVVM_Q42024.Views;

public partial class ProveedorFormView : ContentPage
{
	ProveedorFormViewModel viewModel=new ProveedorFormViewModel();

	public ProveedorFormView()
	{
		InitializeComponent();
		viewModel=new ProveedorFormViewModel();
		BindingContext = viewModel;
	}

	public ProveedorFormView(Proveedor proveedor)
	{
		InitializeComponent();
		viewModel=new ProveedorFormViewModel(proveedor);
		BindingContext = viewModel;
	}

}