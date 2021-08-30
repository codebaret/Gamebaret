using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gamecstatic.Models
{
    public class AdditionalFile
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string GetPath { get; set; }
        [Required]
        public string ContentType { get; set; }
        [Required]
        public byte[] Content { get; set; }
    }
}
