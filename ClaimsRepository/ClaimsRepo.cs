using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClaimsRepository.Claim;

namespace ClaimsRepository
{
    public class ClaimsRepo
    {
        private readonly Queue<Claim> _claims = new Queue<Claim>();
        
        public List<Claim> GetAllClaims()
        {
            List<Claim> claims = new List<Claim>();

            foreach(Claim claim in _claims)
            {
                claims.Add(claim);
            }

            return claims; 
        }
        /*
        public void DisplayAllClaims()
        {
            foreach (Claim claim in _claims)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Ammount: ${claim.ClaimAmount}\n" +
                    $"Date Of Incident: {claim.DateOfIncindent}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}\n" +
                    $"Is Valid: {claim.IsValid}\n" +
                    $"");
            }
        }
        */
        
        public string ViewNextClaim()
        {
            Claim nextClaim = _claims.Peek();
            string x = ($"Claim ID: {nextClaim.ClaimID}\n" +
                $"Claim Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Claim Ammount: ${nextClaim.ClaimAmount}\n" +
                $"Date Of Incident: {nextClaim.DateOfIncindent}\n" +
                $"Date Of Claim: {nextClaim.DateOfClaim}\n" +
                $"Is Valid: {nextClaim.IsValid}");
            Console.WriteLine(x);
            return x;
        }
        
        public bool Dequeue()
        {
            int claimsCount = _claims.Count();
            _claims.Dequeue();
            bool wasDequeued = claimsCount - 1 == _claims.Count();
            return wasDequeued;
        }
        
        public bool Enqueue(Claim claim)
        {
            int claimsCount = _claims.Count();
            _claims.Enqueue(claim);
            bool wasEnqueued = claimsCount + 1 == _claims.Count();
            return wasEnqueued;
        }
    }
}
