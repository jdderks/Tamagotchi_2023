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
        public float hunger = 0.5f;
        public float thirst = 0.3f;

        public string Name { get; set; } = "Gremlin";

        public float Hunger
        {
            get => hunger;
            set
            {
                if (hunger != value)
                {
                    hunger = value;
                    OnPropertyChanged(nameof(Hunger));
                }
            }
        }

        public float Thirst
        {
            get { return thirst; }
            set
            {
                if (thirst != value)
                {
                    thirst = value;
                    OnPropertyChanged(nameof(Thirst));
                }
            }
        }
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

