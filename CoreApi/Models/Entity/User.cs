using System;
using System.Collections.Generic;

namespace CoreApi.Models.Entity
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserLoginName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? Type { get; set; }
    }
}
