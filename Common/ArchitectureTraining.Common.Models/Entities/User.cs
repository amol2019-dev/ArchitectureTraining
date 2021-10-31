using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectureTraining.Common.Models.Entities
{
    class User : EntityBase<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
