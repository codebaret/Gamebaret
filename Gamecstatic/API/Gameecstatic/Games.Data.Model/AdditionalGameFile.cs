using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Data.Model
{
    public class AdditionalGameFile
    {
        public int Id { get; set; }
        public string GetPath { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
