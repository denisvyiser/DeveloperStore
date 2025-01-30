using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Core.Authentication.Config
{
    public class SigningConfig
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }
        public SigningConfig(string certificateKey)
        {
            byte[] privateKey = GetBytesFromCertFile(certificateKey, PemStringType.RsaPrivateKey);

            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(privateKey, out _);
            rsa.ExportParameters(true);
            Key = new RsaSecurityKey(rsa);

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
        private enum PemStringType
        {
            Certificate,
            RsaPrivateKey
        }
        private static byte[] GetBytesFromCertFile(string pemString, PemStringType type)
        {
            string header; string footer;
            switch (type)
            {
                case PemStringType.Certificate:
                    header = "-----BEGIN CERTIFICATE-----";
                    footer = "-----END CERTIFICATE-----";
                    break;
                case PemStringType.RsaPrivateKey:
                    header = "-----BEGIN RSA PRIVATE KEY-----";
                    footer = "-----END RSA PRIVATE KEY-----";
                    break;
                default:
                    return null;
            }
            int start = pemString.IndexOf(header) + header.Length;
            int end = pemString.IndexOf(footer, start) - start;
            return Convert.FromBase64String(pemString.Substring(start, end));
        }
    }
}
