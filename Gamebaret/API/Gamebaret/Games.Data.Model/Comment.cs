using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Data.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
