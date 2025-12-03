using PRG_MAUI_Car_Register.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;


namespace PRG_MAUI_Car_Register.ModelView
{
    public class MainModelView : INotifyPropertyChanged
    {

        //List<Vehicle> vehicleList = new List<Vehicle>();


        public ObservableCollection<Vehicle> ListViewVehicles { get; set; } = new ObservableCollection<Vehicle>();
        public ObservableCollection<string> VehicleTypePicker { get; set; } = new ObservableCollection<string> { "Bil", "MC", "Lastbil" };

        //public ObservableCollection<Vehicle> ListViewBil { get; set; } = new ObservableCollection<Vehicle>();
        public ICommand RegisterCarCommand { get; }
        public bool CarRegisterOk = false;
        public bool ValidateOk = false;

        private string register;
        private string model;
        private string manufacture;
        private string yearmodel;
        private string selectedvehicle;
        private string bilList;
        private string mclist;
        private string lastbillist;

        Regex regex = new Regex("[@_!#$%^&*()<>?/|}{~:]");

        public string Register
        {
            get => register;
            set
            {
                if (register != value)
                {
                    register = value;
                    OnPropertyChanged(nameof(Register));

                }
            }

        }

        public string ModelCar
        {
            get => model;
            set
            {
                if (model != value)
                {
                    model = value;
                    OnPropertyChanged(nameof(ModelCar));

                }
            }

        }

        public string Manufacture
        {
            get => manufacture;
            set
            {
                if (manufacture != value)
                {
                    manufacture = value;
                    OnPropertyChanged(nameof(Manufacture));

                }
            }

        }

        public string Yearmodel
        {
            get => yearmodel;
            set
            {
                if (yearmodel != value)
                {
                    yearmodel = value;
                    OnPropertyChanged(nameof(Yearmodel));

                }
            }

        }

        public string VehicleSelected
        {
            get => selectedvehicle;
            set
            {
                if (selectedvehicle != value)
                {
                    selectedvehicle = value;
                    OnPropertyChanged(nameof(VehicleSelected));

                }
            }

        }

        public string ListViewBil
        {
            get => bilList;
            set
            {
                if (bilList != value)
                {
                    bilList = value;
                    OnPropertyChanged(nameof(ListViewBil));

                }
            }

        }


        public string ListViewMC
        {
            get => mclist;
            set
            {
                if (mclist != value)
                {
                    mclist = value;
                    OnPropertyChanged(nameof(ListViewMC));

                }
            }

        }


        public string ListViewLastbil
        {
            get => lastbillist;
            set
            {
                if (lastbillist != value)
                {
                    lastbillist = value;
                    OnPropertyChanged(nameof(ListViewLastbil));

                }
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public MainModelView()
        {
            RegisterCarCommand = new Command(AddCarRegister);
        }
        private void AddCarRegister()
        {
            CheckEmptyRegister();
            ValidateRegister();

            if (CarRegisterOk == true && ValidateOk == true)
            {

                if (VehicleTypePicker != null)
                {
                    Debug.WriteLine(selectedvehicle);



                    if (selectedvehicle == "Bil")
                    {

                        

                        ListViewVehicles.Add(new Bil(Bil.Type.Bil)
                        {
                            RegistrationNumber = Register,
                            Model = ModelCar,
                            Manufacturer = Manufacture,
                            YearModel = Yearmodel,

                        });

                        ListViewBil = ListViewBil + " | " + Register + "\t" + selectedvehicle + "\t" + ModelCar + "\t" + Manufacture + "\t" + Yearmodel;







                    }


                    if (selectedvehicle == "MC")
                    {

                        ListViewVehicles.Add(new MC(MC.Type.MC)
                        {
                            RegistrationNumber = Register,
                            Model = ModelCar,
                            Manufacturer = Manufacture,
                            YearModel = Yearmodel,

                        });

                        ListViewMC = ListViewMC + " | " + Register + "\t" + selectedvehicle + "\t" + ModelCar + "\t" + Manufacture + "\t" + Yearmodel;

                    }



                    if (selectedvehicle == "Lastbil")
                    {

                        ListViewVehicles.Add(new Lastbil(Lastbil.Type.Lastbil)
                        {
                            RegistrationNumber = Register,
                            Model = ModelCar,
                            Manufacturer = Manufacture,
                            YearModel = Yearmodel,

                        });

                        ListViewLastbil = ListViewLastbil + " | " + Register + "\t" + selectedvehicle + "\t" + ModelCar + "\t" + Manufacture + "\t" + Yearmodel;

                        

                    }

                }

            }

        }

        private void ValidateRegister() //Validerings logik
        {
            ValidateOk = true;
            if (Register.Length == 6)
            {


                for (int i = 0; i < 3; i++)
                {
                    if (!char.IsLetter(Register[i]))
                        ValidateOk = false;


                }


                for (int i = 3; i < 6; i++)
                {
                    if (i < 5)
                    {
                        if (!char.IsDigit(Register[i]))
                            ValidateOk = false;

                    }

                }
            }



            else if (register.Length < 6)
            {
                {
                    ValidateOk = false;

                    if (ValidateOk == false)
                    {
                        Application.Current?.MainPage?.DisplayAlert("Error", "Ett registreringsnummer måste bestå av exakt 6 tecken, med tre bokstäver följt av två siffror och en siffra eller bokstav.", "Ok");

                    }

                }

            }

            if (ModelCar.Length >= 1)
            {
                if (!regex.IsMatch(ModelCar))
                {

                }
                else

                {
                    ValidateOk = false;
                    Application.Current?.MainPage?.DisplayAlert("Error", "Modell få inte ha orelevanta symboler!", "Ok");
                }

            }




            if (Yearmodel.Length < 4)
            {
                Application.Current?.MainPage?.DisplayAlert("Error", "Årsmodel måste innehålla exakt 4 siffror!", "Ok");
                ValidateOk = false;
            }
            else
            {

                if (Yearmodel.Length == 4)
                {


                    if (Regex.IsMatch(Yearmodel, "^[0-9]*$"))
                    {
                        int parsed = int.Parse(Yearmodel);
                        if (parsed >= 1985)
                        {

                            //Ok!
                        }
                        else {
                            Application.Current?.MainPage?.DisplayAlert("Error", "Det måste vara efter 1985!", "Ok");
                            ValidateOk = false;
                        }
                    }
                   



                }



   
        }



        Debug.WriteLine("Validation check:" + ValidateOk);


        }




        private void CheckEmptyRegister()
        {
            CarRegisterOk = true;
            if (string.IsNullOrEmpty(selectedvehicle))
            {
                CarRegisterOk = false;
                Application.Current?.MainPage?.DisplayAlert("Error", "Välj en bil typ!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Register))
            {
                CarRegisterOk = false;
                Application.Current?.MainPage?.DisplayAlert("Error", "Register ska ha 3 bokstäver och 3 siffror!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Manufacture))
            {
                CarRegisterOk = false;
                Application.Current?.MainPage?.DisplayAlert("Error", "Tillverkare måste fyllas in!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(ModelCar))
            {
                CarRegisterOk = false;
                Application.Current?.MainPage?.DisplayAlert("Error", "Modellen måste fyllas in!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Yearmodel))
            {
                CarRegisterOk = false;
                Application.Current?.MainPage?.DisplayAlert("Error", "Årsmodellen ska innehålla 4 siffor!", "Ok");
                return;
            }


        }



      


    }


    }
