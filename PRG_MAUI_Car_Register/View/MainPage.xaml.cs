using PRG_MAUI_Car_Register.Model;
using System.Collections.ObjectModel;
using  PRG_MAUI_Car_Register.ModelView;

namespace PRG_MAUI_Car_Register
{
    public partial class MainPage : ContentPage
    {

        //public ObservableCollection<Vehicle> Vehicles { get; set; } = new()
        //{
           
        //}

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainModelView();
        }

    }
}
