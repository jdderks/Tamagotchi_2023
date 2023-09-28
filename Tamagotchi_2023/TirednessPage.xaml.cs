namespace Tamagotchi_2023;

public partial class TirednessPage : ContentPage
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

    public TirednessPage()
    {
        BindingContext = this;
        InitializeComponent();
        creature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        ProgressBarValue = creature.Tiredness;
    }
    protected override void OnAppearing()
    {
        var loadedCreature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        creature = loadedCreature;
        ProgressBarValue = creature.Tiredness;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
        base.OnAppearing();
    }
}