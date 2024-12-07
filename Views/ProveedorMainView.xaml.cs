using Proveedores_CRUD_MVVM_Q42024.ViewModels;
namespace Proveedores_CRUD_MVVM_Q42024.Views;

public partial class ProveedorMainView : ContentPage
{
	private ProveedorMainViewModel viewModel;
	public ProveedorMainView()
	{
		InitializeComponent();
		viewModel = new ProveedorMainViewModel();
		BindingContext=viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetAll();
    }

}