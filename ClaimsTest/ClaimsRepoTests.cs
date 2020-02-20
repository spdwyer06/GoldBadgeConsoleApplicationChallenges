using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ClaimsRepository.Claim;

namespace ClaimsTest
{
    [TestClass]
    public class ClaimsRepoTests
    {
        [TestMethod]
        public void GetAllClaims_ShouldReturnNotNull()
        {
            var repo = new ClaimsRepo();
            var claim = new Claim();

            repo.Enqueue(claim); 
            List<Claim> getClaims = repo.GetAllClaims();

            Assert.IsNotNull(getClaims);
        }
        [TestMethod]
        public void ViewNextClaim_ShouldReturnNotNull()
        {
            var repo = new ClaimsRepo();
            var claim = new Claim();

            repo.Enqueue(claim);
            string isViewing = repo.ViewNextClaim();

            Assert.IsNotNull(isViewing);

        }
        
        [TestMethod]
        public void Dequeue_ShouldReturnTrue()
        {
            ClaimsRepo repo = new ClaimsRepo();
            Claim claim = new Claim();

            repo.Enqueue(claim);
            bool wasDequeued = repo.Dequeue();

            Assert.IsTrue(wasDequeued);
        }
        
        [TestMethod]
        public void Enqueue_ShouldReturnTrue()
        {
            ClaimsRepo repo = new ClaimsRepo();
            Claim claim = new Claim();

            bool wasEnqueued = repo.Enqueue(claim);

            Assert.IsTrue(wasEnqueued);
        }
    }
}
