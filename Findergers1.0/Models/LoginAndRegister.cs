using System;
using System.Collections.Generic;

namespace Findergers1._0.Models
{
    public partial class LoginAndRegister
    {
        public int Id { get; set; }
        public string FristName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public int Token { get; set; }
    }
}
