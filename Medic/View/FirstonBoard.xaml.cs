using Medic.ViewModel;

namespace Medic.View;

public partial class NewPage1 : ContentPage
{
    //Приветствующие окно при первом запуске
	public NewPage1()
	{
        InitializeComponent();

        this.BindingContext = new FirstonBoardVM();
    }
}