using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IJWTHandler
    {
        string GenerateToken(User userLoggedIn, string key, string issuer);
        string GetClaim(string token, string claimName);
    }
}
