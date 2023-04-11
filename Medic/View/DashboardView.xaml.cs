namespace Medic.View;
using Medic.ViewModel;

public partial class DashboardView : ContentPage
{
	//Окно для ввода mail
	public DashboardView()
	{
		InitializeComponent();
        this.BindingContext = new DashboardVM();
    }
}