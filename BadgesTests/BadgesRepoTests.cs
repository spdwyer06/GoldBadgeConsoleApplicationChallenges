using System;
using System.Collections.Generic;
using BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgesTests
{
    [TestClass]
    public class BadgesRepoTests
    {
        [TestMethod]
        public void DoesListContainID_ShouldReturnFalse()
        {
            BadgesRepo repo = new BadgesRepo();
            Badge badge = new Badge();

            bool doesContain = repo.DoesListContainBadgeID(badge);

            Assert.IsFalse(doesContain);
        }
        [TestMethod]
        public void DoesListContainID_ShouldReturnTrue()
        {
            BadgesRepo repo = new BadgesRepo();
            Badge badge = new Badge();

            repo.AddBadgeToCollection(badge);
            bool doesContain = repo.DoesListContainBadgeID(badge);

            Assert.IsTrue(doesContain);
        }
        [TestMethod]
        public void AddBadgeToCollection_ShouldReturnTrue()
        {
            var repo = new BadgesRepo();
            var badge = new Badge();

            bool wasAdded = repo.AddBadgeToCollection(badge);

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void GetAllBadges_ShouldReturnNotNull ()
        {
            var repo = new BadgesRepo();
            var badge = new Badge(1, new List<string>());

            repo.AddBadgeToCollection(badge);
            Dictionary<int, Badge> getBadges = repo.GetAllBadges(); 

            Assert.IsNotNull(getBadges);
        }
        [TestMethod]
        public void DisplayBadgeID()
        {
            var repo = new BadgesRepo();
            var badge = new Badge(1, new List<string>());

            repo.AddBadgeToCollection(badge);
            int displayID = repo.DisplayBadgeID(1);

            Assert.IsNotNull(displayID);
        }
        [TestMethod]
        public void DisplayBadgeAccess()
        {
            var repo = new BadgesRepo();
            var badge = new Badge(1, new List<string>());

            repo.AddBadgeToCollection(badge);
            repo.AddBadgeAccess(1, "A1");
            string displayAccess = repo.DisplayBadgeAccess(1);

            Assert.IsNotNull(displayAccess);
        }
        [TestMethod]
        public void CheckAssignedBadgeAccess_ShouldReturnTrue()
        {
            var repo = new BadgesRepo();
            var badge = new Badge(1, new List<string>());
            string doorAccess = "A1";

            repo.AddBadgeToCollection(badge);
            repo.AddBadgeAccess(1, "A1");
            bool doesContain = repo.CheckAssignedBadgeAccess(1, doorAccess);

            Assert.IsTrue(doesContain);
        }
        [TestMethod]
        public void CheckAssignedBadgeAccess_ShouldReturnFalse()
        {
            var repo = new BadgesRepo();
            var badge = new Badge(1, new List<string>());
            string doorAccess = "A5";

            repo.AddBadgeToCollection(badge);
            repo.AddBadgeAccess(1, "A1");
            bool doesContain = repo.CheckAssignedBadgeAccess(1, doorAccess);

            Assert.IsFalse(doesContain);
        }
        [TestMethod]
        public void AddBadgeAccess_ShouldReturnTrue()
        {
            var repo = new BadgesRepo();
            var badge = new Badge(1, new List<string>());

            repo.AddBadgeToCollection(badge);
            bool wasAdded = repo.AddBadgeAccess(1, "A1");

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void RemoveBadgeAccess_ShouldReturnTrue()
        {
            var repo = new BadgesRepo();
            var badge = new Badge(1, new List<string>());

            repo.AddBadgeToCollection(badge);
            repo.AddBadgeAccess(1, "A1");
            bool wasRemoved = repo.RemoveBadgeAccess(1, "A1");

            Assert.IsTrue(wasRemoved);
        }
        [TestMethod]
        public void DeleteAllBadgeAccess_ShouldReturnTrue()
        {
            var repo = new BadgesRepo();
            var badge = new Badge(1, new List<string>());

            repo.AddBadgeToCollection(badge);
            repo.AddBadgeAccess(1, "A1");
            bool wasDeleted = repo.DeleteAllBadgeAccess(1);

            Assert.IsTrue(wasDeleted);
        }
    }
}
