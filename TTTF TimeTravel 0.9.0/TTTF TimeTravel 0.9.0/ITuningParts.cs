using GTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTF_TimeTravel_0._9._0
{
    interface ITuningParts
    {
        void AttachTurningParts();
        void EnableBands(Vehicle delorean);
        void initDisplay(Vehicle delorean, bool refilltimecurcuits, int fmonth1, int fmonth2, int fday1, int fday2, int fy1, int fy2, int fy3, int fy4, int fh1, int fh2, string fampm, int fm1, int fm2,
            int presmonth1, int presmonth2, int presday1, int presday2, int presy1, int presy2, int presy3, int presy4, int presh1, int presh2, string presampm, int presm1, int presm2,
            int pastmonth1, int pastmonth2, int pastday1, int pastday2, int pasty1, int pasty2, int pasty3, int pasty4, int pasth1, int pasth2, string pastampm, int pastm1, int pastm2, bool bug);
    }
}
