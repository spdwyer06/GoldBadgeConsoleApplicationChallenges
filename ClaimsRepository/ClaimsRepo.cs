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
        public void ViewNextClaim()
        {
            Claim nextClaim = _claims.Peek();
            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n" +
                $"Claim Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Claim Ammount: ${nextClaim.ClaimAmount}\n" +
                $"Date Of Incident: {nextClaim.DateOfIncindent}\n" +
                $"Date Of Claim: {nextClaim.DateOfClaim}\n" +
                $"Is Valid: {nextClaim.IsValid}");
        }
        public void Dequeue()
        {
            _claims.Dequeue();
        }
        public void Enqueue(Claim claim)
        {
            _claims.Enqueue(claim);
        }
        public void ChooseClaimType(Claim newClaim, string claimType)
        {
            switch (claimType)
            {
                case "1":
                    newClaim.ClaimType = TypeOfClaim.Car;
                    break;
                case "2":
                    newClaim.ClaimType = TypeOfClaim.Home;
                    break;
                case "3":
                    newClaim.ClaimType = TypeOfClaim.Theft;
                    break;
                default:
                    Console.WriteLine("Not a valid Claim Type\n" +
                        "Press any key to redirect...");
                    Console.ReadKey();

                    break;
            }
        }
    }
}
