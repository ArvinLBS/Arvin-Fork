using PRG_MAUI_Car_Register.ModelView;
using PRG_MAUI_Car_Register.Service;

namespace PRG_MAUI_Car_Register.View;

public partial class Bil : ContentPage
{
	public Bil()
	{
        InitializeComponent();

        var vm = new MainModelView(new JsonCarStorageService());
        BindingContext = vm;
}
}