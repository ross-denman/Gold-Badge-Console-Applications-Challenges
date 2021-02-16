using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepository
{
    public enum ClaimType { Car, Home, Theft }
    public class Claim
    {
        public double ClaimID { get; set; }
        public ClaimType Type { get; set; }
        public string Desc { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public bool Handled { get; set; }

        public Claim() { }

        public Claim(double claimID, ClaimType type, string desc, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid, bool handled)
        {
            ClaimID = claimID;
            Type = type;
            Desc = desc;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
            Handled = handled;

        }
    }
}
