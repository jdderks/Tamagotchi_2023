namespace Tamagotchi_2023;

public partial class StimulationPage : ContentPage
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

    public StimulationPage()
    {
        BindingContext = this;
        InitializeComponent();
        creature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        ProgressBarValue = creature.Stimulation;
    }
    protected override void OnAppearing()
    {
        var loadedCreature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        creature = loadedCreature;
        ProgressBarValue = creature.Stimulation;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
        base.OnAppearing();
    }
}