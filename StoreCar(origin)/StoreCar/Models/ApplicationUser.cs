
using Microsoft.AspNet.Identity.EntityFramework;

namespace StoreCar.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
       
        public Address Address { get; set; }

        public Phone Phone { get; set; }
        public ApplicationUser()
        {
        }
    }

    public class Address
    {
        public int Id { get; set; }

        public string Line1 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }

    public class Phone
    {
        public int Id { get; set; }

        public int CountryCode { get; set; }

        public int OperatorCode { get; set; }

        public int Number { get; set; }
    }
}