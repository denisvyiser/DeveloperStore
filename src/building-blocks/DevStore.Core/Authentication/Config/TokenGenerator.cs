using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace DevStore.Core.Authentication.Config
{
    public class TokenGenerator
    {
        public static ClaimsIdentity ClaimsDados(string userName, string firstName, string role, TokenConfig config, string expirationTime, string issuedAt)
        {

            List<Claim> listClaims = new List<Claim>();
            ClaimsIdentity identity = null;

            listClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, userName));
            listClaims.Add(new Claim(ClaimTypes.Role, role));
            listClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")));
            listClaims.Add(new Claim("client_id", userName));
            listClaims.Add(new Claim("issuer", config.Issuer));
            listClaims.Add(new Claim(JwtRegisteredClaimNames.Name, firstName));
            listClaims.Add(new Claim(JwtRegisteredClaimNames.Exp, expirationTime));
            listClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, issuedAt));
            listClaims.Add(new Claim(JwtRegisteredClaimNames.Aud, issuedAt));

            identity = new ClaimsIdentity(listClaims);


            return identity;
        }

        public static SecurityToken TokenKey(string issuer, SigningCredentials signingCredentials, ClaimsIdentity identity, DateTime? dataCriacao, DateTime? dataExpiracao)
        {

            var handler = new JwtSecurityTokenHandler();


            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = issuer,
                SigningCredentials = signingCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao,
            });

            return securityToken;
        }

    }
}
