using Games.API.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Games.API.Models.Comments
{
    public class GameComment : UserGameAction
    {
        public string Comment { get; set; }
    }
}
