using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepository
{
    public class ClaimRepo
    {
        private List<Claim> _claims = new List<Claim>();

        // CREATE
        public bool AddClaim(Claim claim)
        {
            int startingCount = _claims.Count;
            _claims.Add(claim);
            bool wasAdded = _claims.Count > startingCount;
            return wasAdded;
        }

        // READ
        public List<Claim> GetAllClaims()
        {
            return _claims;
        }

        public Claim GetClaimByID(double id)
        {
            foreach (Claim claim in _claims)
            {
                if(claim.ClaimID == id)
                {
                    return claim;
                }
            }
            return null;
        }

        // UPDATE
        public bool UpdateClaimByID(double id, Claim updatedClaim)
        {
            Claim claim = GetClaimByID(id);

            if (claim == null)
            {
                return false;
            }
            else
            {
                claim.ClaimID = updatedClaim.ClaimID;
                claim.Type = updatedClaim.Type;
                claim.Desc = updatedClaim.Desc;
                claim.ClaimAmount = updatedClaim.ClaimAmount;
                claim.DateOfIncident = updatedClaim.DateOfIncident;
                claim.DateOfClaim = updatedClaim.DateOfClaim;
                claim.IsValid = updatedClaim.IsValid;
                claim.Handled = updatedClaim.Handled;

                return true;
            }
        }

        // DELETE
        public bool RemoveClaimByID(double id)
        {
            int startingCount = _claims.Count;
            Claim claim = GetClaimByID(id);
            _claims.Remove(claim);
            bool wasRemoved = _claims.Count < startingCount;
            return wasRemoved;
        }
    }
}
