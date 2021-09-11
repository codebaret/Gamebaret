using Games.Data.Access.Maps.Common;
using Games.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Data.Access.Maps.Main
{
    public class CommentMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Comment>()
                .ToTable("Comments")
                .HasKey(x => x.Id);
        }
    }
}
