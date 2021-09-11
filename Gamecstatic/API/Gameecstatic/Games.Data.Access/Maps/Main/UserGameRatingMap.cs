using Games.Data.Access.Maps.Common;
using Games.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Data.Access.Maps.Main
{
    public class UserGameRatingMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {

            builder.Entity<UserGameRating>()
                .ToTable("UserGameRatings")
                .HasKey(x => x.Id);
        }
    }
}