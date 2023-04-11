namespace Medic.View;
using Medic.ViewModel;

public partial class RgistrationView : ContentPage
{
	//Форма для заполнения карточки пациента
	public RgistrationView()
	{
		InitializeComponent();
        this.BindingContext = new RigistrationVM();
    }
}