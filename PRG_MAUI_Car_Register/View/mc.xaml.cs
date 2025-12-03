using PRG_MAUI_Car_Register.ModelView;

namespace PRG_MAUI_Car_Register.View;

public partial class mc : ContentPage
{
	public mc()
	{
		InitializeComponent();
        BindingContext = MainPage.viewmodelmain;

    }
}