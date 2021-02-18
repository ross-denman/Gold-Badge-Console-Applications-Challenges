using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepository
{
    public enum Door { A1, A2, A3, A4, A5, A6, A7, A8, B1, B2, B3, B4} // declared Enum for all doors. Add Door ID here to add new access doors to system
    public class Badge
    {
        public double BadgeID { get; set; }
        public List<Door> DoorName { get; set; }

        public Badge() { }

        public Badge(double badgeID, List<Door> doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }

    }
}
