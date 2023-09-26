using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_2023
{
    class CreatureDataStore : IDataStore<Creature>
    {
        //CRUD
        public bool CreateItem(Creature item)
        {
            if (Preferences.ContainsKey("MyCreature"))
                return false;

            string creatureString = JsonConvert.SerializeObject(item);
            Preferences.Set("MyCreature", creatureString);
            return Preferences.ContainsKey("MyCreature");
        }

        public Creature ReadItem()
        {
            string creatureString = Preferences.Get("MyCreature", "");
            if (string.IsNullOrEmpty(creatureString))
                return null;

            return JsonConvert.DeserializeObject<Creature>(creatureString);
        }

        public bool UpdateItem(Creature item)
        {
            string creatureString = JsonConvert.SerializeObject(item);
            Preferences.Set("MyCreature", creatureString);
            return Preferences.ContainsKey("MyCreature");
        }

        public bool DeleteItem(Creature item)
        {
            if (!Preferences.ContainsKey("MyCreature"))
                return false;

            Preferences.Remove("MyCreature");
            return !Preferences.ContainsKey("MyCreature");
        }

    }
}
