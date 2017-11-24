using System.Collections.Generic;

namespace AuthService.Entity
{
    public class Role:BaseEntity
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}