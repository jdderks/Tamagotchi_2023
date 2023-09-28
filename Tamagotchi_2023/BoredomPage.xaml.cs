namespace Tamagotchi_2023;

public partial class BoredomPage : ContentPage
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

    public BoredomPage()
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
        ProgressBarValue = creature.Boredom;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
        base.OnAppearing();
    }

    private void PlayWithGremlinButtonClicked(object sender, EventArgs e)
    {
        creature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        creature.Boredom -= 0.1f;
        creature.Stimulation += 0.1f;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
        ProgressBarValue = creature.Boredom;
    }
}