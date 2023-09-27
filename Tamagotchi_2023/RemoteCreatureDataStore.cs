using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_2023
{
    class RemoteCreatureDataStore : IDataStore<Creature>
    {
        private HttpClient httpClient = new();
        public bool CreateItem(Creature item)
        {
            string creatureString = JsonConvert.SerializeObject(item);

            string url = "https://tamagotchi.hku.nl/api/Creatures";
            httpClient.PostAsync(
                requestUri: url, 
                content: new StringContent(creatureString, 
                encoding: Encoding.UTF8, 
                mediaType: "application/json")
            );


            throw new NotImplementedException();
        }

        public Creature ReadItem()
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Creature item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(Creature item)
        {
            throw new NotImplementedException();
        }
    }
}
