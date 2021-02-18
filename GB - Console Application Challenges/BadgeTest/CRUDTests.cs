using BadgeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgeTest
{
    [TestClass]
    public class CRUDTests
    {
        private readonly BadgeRepo _repo =  new BadgeRepo();

        [TestInitialize]
        public void DictionarySeed()
        {
            List<Door> b12345Doors = new List<Door>();
            b12345Doors.Add(Door.A7);
            Badge badge12345 = new Badge(12345, b12345Doors);
            _repo._badgeDictionary.Add(badge12345.BadgeID, b12345Doors);

            List<Door> b22345Doors = new List<Door>();
            b22345Doors.Add(Door.A1);
            b22345Doors.Add(Door.A4);
            b22345Doors.Add(Door.B1);
            b22345Doors.Add(Door.B2);
            Badge badge22345 = new Badge(22345, b22345Doors);
            _repo._badgeDictionary.Add(badge22345.BadgeID, b22345Doors);

            List<Door> b32345Doors = new List<Door>();
            b32345Doors.Add(Door.A4);
            b32345Doors.Add(Door.A5);
            Badge badge32345 = new Badge(32345, b32345Doors);
            _repo._badgeDictionary.Add(badge32345.BadgeID, b32345Doors);
        }

        // CREATE tests
        [TestMethod]
        public void AddBadgeTest()
        {
            // ACT
            double newBadge = 11111;
            List<Door> newDoors = new List<Door> { Door.A1, Door.A2, Door.A3 };
            
            // ARRANGE
            bool wasAdded =_repo.AddBadgeToDictionary(newBadge, newDoors);

            // ASSERT
            Assert.IsTrue(wasAdded);
        }

        // READ tests
        [TestMethod]
        public void GetBadgeTest()
        {
            // ARRANGE - seeded from test initialize

            // ACT
            Dictionary<double, List<Door>> all = _repo.GetAllBadges();

            // ASSERT
            Assert.AreEqual(3, all.Count);
        }
        [TestMethod]
        public void GetBadgeByIDTest()
        {
            // ARRAMGE - seeded from test initiailize

            // ACT
            double badgeID = 12345;      // used seeded badge id
            List<Door> result = _repo.GetBadgeByID(badgeID);

            // ASSERT
            Assert.IsNotNull(result);

        }

        // UPDATE tests
        [TestMethod]
        public void RemoveRoomTest()
        {
            // AARANGE - seeded from test initialize

            // ACT
            double badgeID = 22345;     // used seeded badge id
            Door removeDoor = Door.A4;  // used seed door attached to Badge# 22345
            bool wasRemoved = _repo.removeRoomFromBadge(badgeID, removeDoor);

            // ASSERT
            Assert.IsTrue(wasRemoved);
        }


    }
}
