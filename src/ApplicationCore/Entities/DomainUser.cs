using ApplicationCore.Entities.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class DomainUser
    {
        public string Id { get; set; }     
        public string Email { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ProfilePictureUrl { get; set; }

        //public int InstitutionId { get; set; }
        //public Institution Institution { get; set; }
        //<-- Institution : Type (Centre, Hopital, Organisation)

        //Pour le moment un user --> Centre
        public int? CentreId { get; set; }
        public Centre? Centre { get; set; }
    }
}
