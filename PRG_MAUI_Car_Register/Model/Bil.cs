using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    public class Bil : Vehicle
    {
        public int doors;
        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        public Bil(Type vehicleType)
        {
            this.vehicleType = vehicleType;
        }

        //public override void GetDescription() { 
        
        //}




    }
}
