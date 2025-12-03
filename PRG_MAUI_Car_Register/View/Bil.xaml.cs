using PRG_MAUI_Car_Register.ModelView;

namespace PRG_MAUI_Car_Register.View;

public partial class Bil : ContentPage
{
	public Bil()
	{
		InitializeComponent();
        BindingContext = MainPage.viewmodelmain;
    }
}