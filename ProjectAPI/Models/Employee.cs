using System;
using System.Collections.Generic;

namespace ProjectAPI.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Place { get; set; } = null!;
    }
}
