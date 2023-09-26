using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Tamagotchi_2023
{
    public class Creature : INotifyPropertyChanged
    {
        public string Name { get; set; } = "Gremlin";
        public float Hunger { get; set; } = 0.5f;
        public float Thirst { get; set; } = 0.5f;
        public float Boredom { get; set; } = 0.5f;
        public float Loneliness { get; set; } = 0.5f;
        public float Stimulation { get; set; } = 0.5f;
        public float Tiredness { get; set; } = 0.5f;


        public Creature()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

