using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace Tamagotchi_2023;
public partial class HungerPage : ContentPage, INotifyPropertyChanged
{
    private float progressBarValue = 0f;

    public float ProgressBarValue
    {
        get { return progressBarValue; }
        set
        {
            if (progressBarValue != value)
            {
                progressBarValue = value;
                OnPropertyChanged(nameof(progressBarValue));
            }
        }
    }

    public Creature creature;

    public HungerPage()
    {
        BindingContext = this;
        InitializeComponent();
        creature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        ProgressBarValue = creature.Hunger;
    }

    private void CroissantButtonClicked(object sender, EventArgs e)
    {
        if (creature.Hunger > 0)
        {
            creature.Hunger -= 0.1f;
            Math.Clamp(creature.Hunger, 0, 1);
        }
        progressBarValue = creature.Hunger;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
    }
}