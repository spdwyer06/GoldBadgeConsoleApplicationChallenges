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
        /*
        public bool IsIDTaken(Badge newBadge)
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
        */
        public bool DoesListContainBadgeID(Badge badge)
        {
            if (_badgeCollection.ContainsKey(badge.BadgeID))
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
            _badgeCollection.Add(newBadge.BadgeID, newBadge);
            bool wasAdded = collectionLength + 1 == _badgeCollection.Count();
            return wasAdded;
        }
        public void DisplayCollection()
        {
            foreach (KeyValuePair<int, Badge> badge in _badgeCollection)
            {
                Console.WriteLine($"Badge ID: {badge.Value.BadgeID}\n" +
                   $"Door access: {String.Join(",", badge.Value.Access)}\n" +
                   $"");
            }
        }
        public int DisplayBadgeID(int userInput)
        {
            return _badgeCollection[userInput].BadgeID;
        }
        public string DisplayBadgeAccess(int userInput)
        {
            return String.Join(",", _badgeCollection[userInput].Access);
        }
        public bool CheckAssignedBadgeAccess(int userInput, string doorAccess)
        {
            if (_badgeCollection[userInput].Access.Contains(doorAccess))
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
        public bool AddBadgeAccess(int userInput, string addAccess)
        {
            int badgeAccessLength = _badgeCollection[userInput].Access.Count();
            _badgeCollection[userInput].Access.Add(addAccess);
            bool wasAdded = badgeAccessLength + 1 == _badgeCollection[userInput].Access.Count();
            return wasAdded;
        }
        public bool RemoveBadgeAccess(int userInput, string removeAccess)
        {
            int badgeAccessLength = _badgeCollection[userInput].Access.Count();
            _badgeCollection[userInput].Access.Remove(removeAccess);
            bool wasRemoved = badgeAccessLength - 1 == _badgeCollection[userInput].Access.Count();
            return wasRemoved;
        }
        public bool DeleteAllBadgeAccess(int userInput)
        {
            int badgeAccessLength = _badgeCollection[userInput].Access.Count();
            _badgeCollection[userInput].Access.Clear();
            bool wasDeleted = badgeAccessLength == _badgeCollection[userInput].Access.Count();
            return wasDeleted;
        }
    }
}
