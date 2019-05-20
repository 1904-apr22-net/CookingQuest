using System;
using System.Collections.Generic;

namespace CookingQuest.Data.Entities
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PlayerId { get; set; }
        public bool IsAdmin { get; set; }

        public virtual Player Player { get; set; }
    }
}
