


using Microsoft.AspNetCore.Identity;

namespace RoomService.Domain.Entities
{
    public class UserModel: IdentityUser
    { 
        public  new string Id { get; set; } = Guid.NewGuid().ToString();  
        public new string Email {  get; set; } = string.Empty;
        public string BiddingId { get; set; } = string.Empty;
        public string Password { get; set; } = null!;
        
    }
}
