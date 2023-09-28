namespace Tamagotchi_2023;

public partial class LonelinessPage : ContentPage
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

    public LonelinessPage()
    {
        BindingContext = this;
        InitializeComponent();
        creature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        ProgressBarValue = creature.Loneliness;
    }
    protected override void OnAppearing()
    {
        var loadedCreature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        creature = loadedCreature;
        ProgressBarValue = creature.Loneliness;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
        base.OnAppearing();
    }
}