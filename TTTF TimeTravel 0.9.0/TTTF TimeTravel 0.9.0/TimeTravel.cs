using GTA;
using System;

namespace TTTF_TimeTravel_0._9._0
{
    abstract class TimeTravel
    {
        public bool stoponce = false;
        public Random rand = new Random();
        public bool tickbool = false;
        public bool errorbool = false;
        public string error = "";
        public string error2 = "";
        public bool timeentry = false;
        public bool timeenter = false;
        public bool freeze = false;
        
        public void CharacterTravel(Delorean DMC)
        {
            DeloreanManagement.presmonth1 = DMC.presmonth1;
            DeloreanManagement.presmonth2 = DMC.presmonth2;
            DeloreanManagement.presday1 = DMC.presday1;
            DeloreanManagement.presday2 = DMC.presday2;
            DeloreanManagement.presy1 = DMC.presy1;
            DeloreanManagement.presy2 = DMC.presy2;
            DeloreanManagement.presy3 = DMC.presy3;
            DeloreanManagement.presy4 = DMC.presy4;
            DeloreanManagement.presampm = DMC.presampm;
        }
        public virtual void runningCircuits(Delorean delorean, effects worm) { }
        public virtual void reentry(Vehicle car) { }
        public virtual void tickfreeze(Vehicle car) { }
    }
}
