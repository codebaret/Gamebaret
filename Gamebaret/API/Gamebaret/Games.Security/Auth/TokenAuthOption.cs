﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Security.Auth
{
    public class TokenAuthOption
    {
        public static string Audience { get; } = "GamesAudience";
        public static string Issuer { get; } = "GamesIssuer";
        public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);

        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(300);
        public static string TokenType { get; } = "Bearer";
    }
}
