using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace Tamagotchi_2023;
public partial class HungerPage : ContentPage
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
    protected override void OnAppearing()
    {
        var loadedCreature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        creature = loadedCreature;
        ProgressBarValue = creature.Hunger;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
        base.OnAppearing();
    }

    private void CroissantButtonClicked(object sender, EventArgs e)
    {
        creature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        ProgressBarValue = creature.Hunger;
        creature.Hunger -= 0.1f;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
    }
}