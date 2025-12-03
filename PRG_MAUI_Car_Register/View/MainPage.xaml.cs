using PRG_MAUI_Car_Register.Model;
using System.Collections.ObjectModel;
using  PRG_MAUI_Car_Register.ModelView;

namespace PRG_MAUI_Car_Register.View
{
    public partial class MainPage : ContentPage
    {

        //public ObservableCollection<Vehicle> Vehicles { get; set; } = new()
        //{

        //}

        public static MainModelView viewmodelmain;

        public MainPage()
        {
            InitializeComponent();

            viewmodelmain = new MainModelView();

            BindingContext = MainPage.viewmodelmain;
        }

    }
}
