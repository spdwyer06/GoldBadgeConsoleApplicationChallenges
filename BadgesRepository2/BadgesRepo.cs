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
        public bool DoesListContain(Badge badge)
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
            //Console.WriteLine($"Badge ID: {_badgeCollection[userInput].BadgeID}");
        }
        public string DisplayBadgeAccess(int userInput)
        {
            return String.Join(",", _badgeCollection[userInput].Access);
            //Console.WriteLine($"Current door access: {String.Join(",", _badgeCollection[userInput].Access)}");
        }
        public bool RemoveBadgeAccess(int userInput, string removeAccess)
        {
            int collectionLength = _badgeCollection[userInput].Access.Count();
            _badgeCollection[userInput].Access.Remove(removeAccess);
            bool wasRemoved = collectionLength - 1 == _badgeCollection[userInput].Access.Count();
            return wasRemoved;
        }
    }
}
