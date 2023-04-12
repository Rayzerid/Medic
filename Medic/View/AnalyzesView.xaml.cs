namespace Medic.View;
using Medic.ViewModel;
public partial class AnalyzesView : ContentPage
{
	//Форма с новостями и услугами
	public AnalyzesView()
	{
		InitializeComponent();
        this.BindingContext = new AnalyzesVM();
    }
}