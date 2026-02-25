using System.Text.RegularExpressions;

namespace PRG_MAUI_Car_Register
{
    public class Vehicle
    {

        // Medlemsvariabler


        private string registrationNumber = string.Empty;
        private string vehicleTypeName;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private string yearModel = string.Empty;
        public string vehicletype = string.Empty;
        public Type vehicleType;
        public bool RegisterOk = false;

        // Konstruktor (en metod med samma namn som klassen, som returnerar ett objekt)
        public Vehicle()
        {
            vehicleType = typeof(Vehicle);
            vehicleTypeName = this.GetType().Name;
        }



        // Get-Set för att hålla variablerna privata, och för att validera inkommande värden från UI (user interface, användargränssnittet)
        //public string VehicleType
        // {
        //get { return vehicleType; }

        //   set { vehicleType = value; }

        // }

        public string VehicleType
        {
            get { return vehicletype; }

            set
            {
                if (value == null) { }
                else
                {


                    vehicletype = value;
                }
            }
        }

        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                if (value == null) { }
                else
                {
            

                    registrationNumber = value.ToUpper();
                }
            }
        }


        public string Model
        {
            get { return model; }
            set
            {
                if (value == null) { }
                else
                {
                    if (value.Length >= 1)
                    {
                        
                            model = value;
                        
                     

                    }



                    else

                    {
                        return;
                    }
                }

            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (value == null) { }
                else
                {
                    if (value.Length >= 1) { manufacturer = value; }
                  
                }

            }

        }


        public string YearModel
        {
            get { return yearModel; }

            set
            {
                if (value == null) { }
                else
                {
                  

                                    yearModel = value;
                                    RegisterOk = true;
                         
                     


                    
                }
            }
        }


        //public abstract void GetDescription();

        public override string ToString()
        {

            if (RegisterOk = true)
            {
               //return "test";
                return registrationNumber + "\t" + vehicletype + "\t" + model + "\t" + manufacturer + "\t" + yearModel;

            }
            else
            {

                return null;
            }

        }


    }


}
