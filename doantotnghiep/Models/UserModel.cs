namespace WebApplication2.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    namespace WebApplication2.Models
    {
        public class UserModel : IdentityUser
        {
            public string Ocupation { get; set; }
        }
    }
}
