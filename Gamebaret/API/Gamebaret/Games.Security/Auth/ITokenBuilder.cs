﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Security.Auth
{
    public interface ITokenBuilder
    {
        string Build(string name, string[] roles, DateTime expireDate);
    }
}
