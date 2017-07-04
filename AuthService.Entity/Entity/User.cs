using System.Collections.Generic;

namespace AuthService.Entity
{
    public class User:BaseEntity
    {
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsADUser { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}