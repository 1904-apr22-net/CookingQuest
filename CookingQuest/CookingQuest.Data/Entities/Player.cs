using System;
using System.Collections.Generic;

namespace CookingQuest.Data.Entities
{
    public partial class Player
    {
        public Player()
        {
            Account = new HashSet<Account>();
            PlayerEquipment = new HashSet<PlayerEquipment>();
            PlayerLocation = new HashSet<PlayerLocation>();
            PlayerLoot = new HashSet<PlayerLoot>();
        }

        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<PlayerEquipment> PlayerEquipment { get; set; }
        public virtual ICollection<PlayerLocation> PlayerLocation { get; set; }
        public virtual ICollection<PlayerLoot> PlayerLoot { get; set; }
    }
}
