using PathWay.Context;
using static PathWay.Context.AppDbContext;

namespace PathWay.Models
{
    public class User 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created_At { get; set; }
        public string MembershipType { get; set; }
        public string? CarreerPreference { get; set; }
        public string? UserImage { get; set; }

    }   
}
