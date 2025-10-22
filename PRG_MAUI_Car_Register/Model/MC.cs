using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class MC : Vehicle
    {
        public string category;
        public enum Type { MC, Bil, Lastbil };
        private Type vehicleType;
        public MC(Type vehicleType)
        {
            this.vehicleType = vehicleType;
        }
        public override void GetDescription()
        {

        }

    }
}
