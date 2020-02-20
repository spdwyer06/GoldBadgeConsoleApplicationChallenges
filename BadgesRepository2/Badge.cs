using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> Access { get; set; }

        public Badge() { }
        public Badge(int badgeID, List<string> access)
        {
            BadgeID = badgeID;
            Access = access; 
        }
    }
}
