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

        public virtual void runningCircuits(Delorean delorean, effects worm) { }
        public virtual void reentry(Vehicle car) { }
        public virtual void tickfreeze(Vehicle car) { }
    }
}
