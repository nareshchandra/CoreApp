namespace AuthService.Entity
{
    public class UserRole:BaseEntity
    {
        public int UserRoleID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
