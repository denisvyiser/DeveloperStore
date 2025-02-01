using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Core.Authentication.Config
{
    public class TokenConfig
    {
        public string Issuer { get; set; }

        public long ExpirationTime { get; set; }

    }
}
