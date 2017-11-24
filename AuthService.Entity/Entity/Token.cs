using System;

namespace AuthService.Entity
{
    public class Token:BaseEntity
    {
        public int TokenID { get; set; }
        public string UserID { get; set; }
        public string Value { get; set; }
        public DateTime LoggedTime { get; set; }
    }
}
