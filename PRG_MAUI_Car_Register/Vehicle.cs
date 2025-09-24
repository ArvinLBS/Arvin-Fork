using System.Text.RegularExpressions;

namespace PRG_MAUI_Car_Register
{
    class Vehicle
    {
        // Medlemsvariabler
        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private string yearModel = string.Empty;
        public bool RegisterOk = false;
        
        // Konstruktor (en metod med samma namn som klassen, som returnerar ett objekt)
        public Vehicle(Type vehicleType) // en konstruktor kan, men måste inte, ta parametrar
        {
            this.vehicleType = vehicleType;
        }

        Regex regex = new Regex("[@_!#$%^&*()<>?/|}{~:]");

        // Get-Set för att hålla variablerna privata, och för att validera inkommande värden från UI (user interface, användargränssnittet)
        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                if (value == null) { } else { 
                if (value.Length == 6)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!char.IsLetter(value[i]))
                            throw new ArgumentException("Inkorret registreringsnummer: De första tre tecknen måste vara bokstäver.");
                    }

                    for (int i = 3; i < 6; i++)
                    {
                        if (i < 5)
                        {
                            if (!char.IsDigit(value[i]))
                                throw new ArgumentException("Inkorret registreringsnummer: Det fjärde och femte tecknet måste vara siffror.");
                        }
                        else
                        {
                            if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                                throw new ArgumentException("Inkorret registreringsnummer: Det sjätte tecknet måste vara en siffra eller en bokstav.");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken, med tre bokstäver följt av två siffror och en siffra eller bokstav.");
                }

                registrationNumber = value.ToUpper();
            }
        }
        }
        public Type VehicleType
        {
            get { return vehicleType; }
            set { this.vehicleType = value; }
        }

        public string Model
        {
            get { return model; }
            set { if (value == null) { } else
                {
                    if (value.Length >= 1) {
                        if (!regex.IsMatch(value)) {
                        this.model = value;
                        }
                     else

                    {
                        throw new ArgumentException("Modell få inte ha orelevanta symboler!");
                    }

                }



                    else

                    {
                        throw new ArgumentException("Inkorrekt model, Ange en giltig modell:"); }
                }

           }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { if (value == null) { } else
                {
                    if (value.Length >= 1) { this.manufacturer = value; }else
                    {
                        throw new ArgumentException("Inkorrekt tillverkare, Ange en giltig tillverkare:");}
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
                    if (value.Length < 4) { throw new ArgumentException("Ange exakt 4 siffror!"); } else { 

                    if (value.Length == 4)
                    {


                        if (Regex.IsMatch(value, "^[0-9]*$"))
                        {
                            this.yearModel = value;
                                RegisterOk = true;
                        }
                        else
                        {
                            throw new ArgumentException("Inkorrekt årdsmodell måste innehålla exakt 4 siffror");
                        }



                    }
                    else
                    {
                        throw new ArgumentException("Inkorrekt årdsmodell måste innehålla exakt 4 siffror");
                    }

                    
                }
            }
           }
        }

       
      

        public override string ToString()
        {

            if (RegisterOk = true)
            {

                return this.registrationNumber + "\t" + this.vehicleType + "\t" + this.model + "\t" + this.manufacturer + "\t" + this.yearModel;

            } else {

                return null;
            }

        }


    }


}
