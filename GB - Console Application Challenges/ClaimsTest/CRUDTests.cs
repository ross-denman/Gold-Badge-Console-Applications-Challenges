using ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClaimsTest
{
    [TestClass]
    public class CRUDTests
    {
        private readonly ClaimRepo _repo = new ClaimRepo();

        [TestInitialize]
        public void Seed()
        {
            Claim Andrew = new Claim(1, ClaimType.Car, "Ran over student at Eleven Fifty Academy", 15000.00, new DateTime(2021, 02, 14), new DateTime(2021, 02, 15), true, false);
            Claim Seth = new Claim(2, ClaimType.Theft, "Lost his marbles", 1000.00, new DateTime(2021, 02, 14), new DateTime(2021, 02, 15), true, false);

            _repo.AddClaim(Andrew);
            _repo.AddClaim(Seth);
        }
        // CREATE Method Test
        [TestMethod]
        public void AddClaimTest()
        {
            // ARRANGE
            Claim Gordon = new Claim(3, ClaimType.Home, "Hail damage", 4500.00, new DateTime(2021, 02, 15), new DateTime(2021, 02, 16), false, false);

            // ACT
            bool wasAdded = _repo.AddClaim(Gordon);

            // ASSERT
            Assert.IsTrue(wasAdded);
        }

        // READ Method Test
        [TestMethod]
        public void GetMenuItemsTest()
        {
            // ARRANGE
            //Seed();

            // ACT
            List<Claim> all = _repo.GetAllClaims();

            // ASSERT
            Assert.AreEqual(2, all.Count);
        }

        // DELETE Method Test
        [TestMethod]
        public void RemoveClaimByIDTest()
        {
            // ARRANGE
            Seed();

            // ACT
            bool wasRemoved = _repo.RemoveClaimByID(1);

            // ASSERT
            Assert.IsTrue(wasRemoved);
        }
    }
}
