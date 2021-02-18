using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepository
{
    public class BadgeRepo
    {
        //private readonly List<Badge> _directory = new List<Badge>();
        public readonly Dictionary<double, List<Door>> _badgeDictionary = new Dictionary<double, List<Door>>();
        
        // CREATE method
        public bool AddBadgeToDictionary(double newBadge, List<Door> newDoors)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary.Add(newBadge, newDoors);
            bool wasAdded = _badgeDictionary.Count > startingCount;
            return wasAdded;
        }



        // READ methodss
        public Dictionary<double, List<Door>> GetAllBadges()
        {
            return _badgeDictionary;
        }

        public List<Door> GetBadgeByID(double badgeID)
        {
            List<Door> result = new List<Door>();
            if (_badgeDictionary.TryGetValue(badgeID, out result))
                {
                    return result;
                }
            return null;
        }

        // UPDATE method

        public bool removeRoomFromBadge(double badgeID, Door removeDoor)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary[badgeID].Remove(removeDoor);
            bool wasRemoved = _badgeDictionary.Count < startingCount;
            return wasRemoved;
        }

        // DELETE - no delete method needed for console app
    }
}
