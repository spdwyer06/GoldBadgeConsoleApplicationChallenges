using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepository
{
    public class BadgesRepo 
    {
        protected readonly Dictionary<int, Badge> _badgeCollection = new Dictionary<int, Badge>();
        //Badge newBadge = new Badge(); 

        public bool IsIDTaken (Badge newBadge)
        {
            if (_badgeCollection.ContainsKey(newBadge.BadgeID))
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
        public bool AddBadgeToCollection(Badge newBadge)
        {
            int collectionLength = _badgeCollection.Count();

            /*
            if (_badgeCollection.ContainsKey(newBadge.BadgeID))
            {

            }
            */

            _badgeCollection.Add(newBadge.BadgeID, newBadge);
            bool wasAdded = collectionLength + 1 == _badgeCollection.Count();
            return wasAdded; 
        }
       
    }

}
