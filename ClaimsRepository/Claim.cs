using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepository
{
    public class Claim
    {
        public enum TypeOfClaim { Car, Home, Theft }

        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncindent { get; set; }
        public DateTime DateOfClaim { get; set; }
        public int DaysSinceClamed
        {
            get
            {
                TimeSpan daysBeforeClaimed = DateOfClaim - DateOfIncindent;
                double totalAmountOfDays = Math.Floor(daysBeforeClaimed.TotalDays);
                int daysSinceClaimed = Convert.ToInt32(totalAmountOfDays);
                return daysSinceClaimed;
            }
        }
        public bool IsValid
        {
            get
            {
                if (DaysSinceClamed <= 30)
                {
                    return true;
                }
                else
                {
                    return false; 
                }

            }
        }

        public Claim() { }
        /*
        public Claim(int claimID, TypeOfClaim claimType, string description, decimal claimAmmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmmount;
            DateOfIncindent = dateOfIncident;
            DateOfClaim = dateOfClaim;
            //IsValid = isValid;
        }
        */





    }
        
}
