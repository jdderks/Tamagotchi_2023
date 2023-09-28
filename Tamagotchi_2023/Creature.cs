using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Tamagotchi_2023
{
    public class Creature : INotifyPropertyChanged
    {
        private string name = "Gremlin";
        private float hunger = 0.5f;
        private float thirst = 0.3f;
        private float loneliness = 0.3f;
        private float boredom = 0.3f;
        private float stimulation = 0.5f;
        private float tiredness = 0.4f;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public float Hunger
        {
            get { return hunger; }
            set
            {
                if (hunger != value)
                {
                    hunger = value;
                    hunger = Math.Clamp(hunger, 0, 1);
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
                    thirst = Math.Clamp(thirst, 0, 1);
                    OnPropertyChanged(nameof(Thirst));
                }
            }
        }

        public float Boredom
        {
            get { return boredom; }
            set
            {
                if (boredom != value)
                {
                    boredom = value;
                    boredom = Math.Clamp(boredom, 0, 1);
                    OnPropertyChanged(nameof(Boredom));
                }
            }
        }

        public float Loneliness
        {
            get { return loneliness; }
            set
            {
                if (loneliness != value)
                {
                    loneliness = value;
                    loneliness = Math.Clamp(loneliness, 0, 1);
                    OnPropertyChanged(nameof(Loneliness));
                }
            }
        }

        public float Stimulation
        {
            get { return stimulation; }
            set
            {
                if (stimulation != value)
                {
                    stimulation = value;
                    stimulation = Math.Clamp(stimulation, 0, 1);
                    OnPropertyChanged(nameof(Stimulation));
                }
            }
        }

        public float Tiredness
        {
            get { return tiredness; }
            set
            {
                if (tiredness != value)
                {
                    tiredness = value;
                    tiredness = Math.Clamp(tiredness, 0, 1);
                    OnPropertyChanged(nameof(Tiredness));
                }
            }
        }

        //public float Boredom { get; set; } = 0.5f;
        //public float Loneliness { get; set; } = 0.5f;
        //public float Stimulation { get; set; } = 0.5f;
        //public float Tiredness { get; set; } = 0.5f;


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

