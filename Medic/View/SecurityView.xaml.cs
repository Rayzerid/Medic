using Java.Security;
using Medic.ViewModel;
namespace Medic.View;

public partial class SecurityView : ContentPage
{
    //Окно для создания пароля пользователем
    IDispatcherTimer timer;
    public SecurityView()
    {
        InitializeComponent();
        this.BindingContext = new SecurityVM();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(0.200);
        timer.Tick += (s, e) => timerCallback(sender);
        timer.Start();

        (sender as Button).BackgroundColor = Color.FromArgb("#1A6FEE");
        (sender as Button).TextColor = Color.FromArgb("#FFFFFF");
    }

    private void timerCallback(object sender)
    {
        (sender as Button).BackgroundColor = Color.FromArgb("#F5F5F9");
        (sender as Button).TextColor = Color.FromArgb("#000000");
    }
}