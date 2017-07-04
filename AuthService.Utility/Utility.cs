using AuthService.Entity;
using Microsoft.Extensions.Options;

namespace AuthService.Utility
{
    public class Utility:IUtility
    {
        private readonly IOptions<ConnectionString> options;

        public Utility(IOptions<ConnectionString> options)
        {
            this.options = options;
        }

        public string GetConnectionString()
        {
            return options.Value.DefaultConnection;
        }
    }
}
