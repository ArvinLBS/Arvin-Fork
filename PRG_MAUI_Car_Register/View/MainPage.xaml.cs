using PRG_MAUI_Car_Register.Model;

namespace PRG_MAUI_Car_Register
{
    public partial class MainPage : ContentPage
    {
        List<Vehicle> vehicleList = new List<Vehicle>();

        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;
        }


        private void CheckEmptyRegister()
        {
            if (string.IsNullOrEmpty(entryRegistrationNumber.Text))
            {

                throw new ArgumentException("Inkorret registreringsnummer: De första tre tecknen måste vara bokstäver och de tre andra siffror.");

            }

            if (string.IsNullOrEmpty(entryManufacturer.Text))
            {
                throw new ArgumentException("Inkorrekt Tillverkare: Måste innehålla bokstäver av tillverkare");
            }

            if (string.IsNullOrEmpty(entryModel.Text))
            {
                throw new ArgumentException("Inkorrekt Modell: Måste innehålla bokstäver av modellen och får inte ha orelevanta symboler");
            }

            if (string.IsNullOrEmpty(EntryYearModel.Text))
            {
                throw new ArgumentException("Inkorrekt Årsmodell: Måste ha exakt 4 siffror");
            }


        }

      

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {

                var Picked = pickerType.SelectedIndex;

                if (pickerType.SelectedItem.ToString() == "Bil") {

                    Bil vehicle = new Bil((Bil.Type)pickerType.SelectedIndex);
                    CheckEmptyRegister();

                    string regNr = entryRegistrationNumber.Text;
                    vehicle.RegistrationNumber = regNr;
                    vehicle.Manufacturer = entryManufacturer.Text;
                    vehicle.Model = entryModel.Text;
                    vehicle.YearModel = EntryYearModel.Text;

                    vehicleList.Add(vehicle);
                }

                if (pickerType.SelectedItem.ToString() == "MC")
                {
                    MC vehicle = new MC((MC.Type)pickerType.SelectedIndex);
                    CheckEmptyRegister();


                    string regNr = entryRegistrationNumber.Text;
                    vehicle.RegistrationNumber = regNr;
                    vehicle.Manufacturer = entryManufacturer.Text;
                    vehicle.Model = entryModel.Text;
                    vehicle.YearModel = EntryYearModel.Text;

                    vehicleList.Add(vehicle);
                }

                if (pickerType.SelectedItem.ToString() == "Lastbil")
                {
                    Lastbil vehicle = new Lastbil((Lastbil.Type)pickerType.SelectedIndex);
                    CheckEmptyRegister();


                    string regNr = entryRegistrationNumber.Text;
                    vehicle.RegistrationNumber = regNr;
                    vehicle.Manufacturer = entryManufacturer.Text;
                    vehicle.Model = entryModel.Text;
                    vehicle.YearModel = EntryYearModel.Text;

                    vehicleList.Add(vehicle);
                }



                listViewVehicles.ItemsSource = null;
                listViewVehicles.ItemsSource = vehicleList;

                entryRegistrationNumber.Text = string.Empty;
                entryManufacturer.Text = string.Empty;
                entryModel.Text = string.Empty;
                EntryYearModel.Text = string.Empty;




            }
            catch (ArgumentException ex)
            {
                DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value != true) return;

            // Skapa en filtrerad lista baserat på vilken radioknapp som är vald
            List<Vehicle> filteredList;

            if (radioCar.IsChecked)
            {
                filteredList = vehicleList.OfType<Bil>().Cast<Vehicle>().ToList();
            }
            else if (radioMC.IsChecked)
            {
                filteredList = vehicleList.OfType<MC>().Cast<Vehicle>().ToList();
            }
            else if (radioTruck.IsChecked)
            {
                filteredList = vehicleList.OfType<Lastbil>().Cast<Vehicle>().ToList();
            }
            else
            {
                // Om "Alla" är vald, visa hela listan
                filteredList = vehicleList;
            }

            listViewVehicles.ItemsSource = filteredList;
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string searchReg = entrySearchRegistrationNumber.Text?.ToLower();
            string searchManufactor = entryManufacturer.Text?.ToLower();
            string searchModel = entryModel.Text?.ToLower();
            string searchÅrmodel = EntryYearModel.Text?.ToLower();

            if (string.IsNullOrEmpty(searchReg) || string.IsNullOrEmpty(searchManufactor) || string.IsNullOrEmpty(searchModel))
            {
                entrySearchRegistrationNumber.Placeholder = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchReg);

            if (foundVehicle != null)
            {
                labelSearchResult.Text = $"Fordon hittat:\n" +
                                         $"Registreringsnummer: {foundVehicle.RegistrationNumber}\n" +
                                         $"Tillverkare: {foundVehicle.Manufacturer}\n" +
                                         $"Modell: {foundVehicle.Model}\n" +
                                         $"Typ: {foundVehicle.VehicleType}";

            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }
        }

    }
}
