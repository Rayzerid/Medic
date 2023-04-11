using Medic.ViewModel;

namespace Medic.View;

public partial class NewPage1 : ContentPage
{
    //Приветствующие окно при первом запуске
	public NewPage1()
	{
        InitializeComponent();

        this.BindingContext = new FirstonBoardVM();

        if (!VersionTracking.IsFirstLaunchEver)
        {
            Navigation.PushModalAsync(new DashboardView());
        }

        if (Preferences.Get("UserMail", null) != null)
        {
            Navigation.PushModalAsync(new SecurityView());
        }
    }
}