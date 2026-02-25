using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    public class Lastbil : Vehicle
    {

        public double loadcapacity;

        public enum Type { MC, Bil, Lastbil };
        private Type vehicleType;
        public Lastbil(Type vehicleType)
        {
            this.vehicleType = vehicleType;
        }

        //public override void GetDescription()
        //{

        //}

    }
}
