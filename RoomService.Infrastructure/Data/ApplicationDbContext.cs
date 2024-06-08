using BidService.API.BidService.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomService.Domain.Entities;

namespace RoomService.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<UserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
       public DbSet<BidModel> RoomBidders { get; set; }    
    }
}