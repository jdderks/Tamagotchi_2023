using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tamagotchi_2023;
public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    private Timer timer;
    private int counter;

    private DateTime previousTime;
    private int hoursElapsedSinceLastOpened; //In seconds

    public Creature creature
    {
        get;
        set;
    }

    public MainPage()
    {
        //Timer that checks the time while app is closed
        var nowTime = DateTime.Now;

        var deltaTime = nowTime - previousTime;
        hoursElapsedSinceLastOpened = (int)deltaTime.TotalHours;

        for (int i = 0; i < hoursElapsedSinceLastOpened; i++)
        {
            IncreaseVitals(appOpen: false);
        }


        //Timer that checks the time while app is open
        int amountOfSecondsBetweenVitalUpdates = 10;
        timer = new Timer(TimerCallback, null, 0, amountOfSecondsBetweenVitalUpdates * 1000);

        BindingContext = this;
        InitializeComponent();
        var newCreatureStore = DependencyService.Get<IDataStore<Creature>>();
        newCreatureStore.CreateItem(creature);
        //if (!newCreatureStore.CreateItem(creature))
        //{
        //    creature = newCreatureStore.ReadItem();
        //}
    }


    protected override void OnDisappearing()
    {
        previousTime = DateTime.Now;
        base.OnDisappearing();
    }

    protected override void OnAppearing()
    {
        var loadedCreature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        creature = loadedCreature;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
        base.OnAppearing();
    }

    private void TimerCallback(Object o)
    {
        counter++;
        Console.WriteLine("Timer update");
        IncreaseVitals();
    }


    private void AddWaterButtonClicked(object sender, EventArgs e)
    {
        //if (gremlin.Thirst > 0 && gremlin.Thirst < 1)
        if (creature.Thirst > 0)
        {
            creature.Thirst -= 0.1f;
        }
        //DateTime time = DateTime.Now;
        //TimeSpan elapsed = time - dateTime;

        //Preferences.Set("LastTime", elapsed.ToString());
        //var debug = Preferences.Get("LastTime","");
        //Console.Write(debug);
    }


    private void OpenHungerPanelClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HungerPage());
    }

    private void OpenThirstPanelClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ThirstPage());
    }

    private void OpenBoredomPanelClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BoredomPage());
    }
    private void OpenTirednessPanelClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TirednessPage());
    }
    private void OpenStimulationPanelClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StimulationPage());
    }

    private void OpenLonelinessPanel(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LonelinessPage());
    }




    private void DebugButtonClicked(object sender, EventArgs e)
    {
        var loadedCreature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        loadedCreature.Name = "Gremlin";
        loadedCreature.Hunger = 1f;
        loadedCreature.Thirst = 1f;
        loadedCreature.Boredom = 1f;
        loadedCreature.Stimulation = 0f;
        loadedCreature.Loneliness = 0f;
        loadedCreature.Tiredness = 0f;
        creature = loadedCreature;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
    }

    private void IncreaseVitals(bool appOpen = true)
    {
        //In 20 minutes when the app is open the vitals will have refreshed.
        var loadedCreature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        loadedCreature.Hunger += 0.05f * .2f;
        loadedCreature.Thirst += 0.05f * .2f;
        loadedCreature.Boredom += 0.05f * .2f;
        loadedCreature.Tiredness += 0.2f * .2f;

        if (appOpen)
        {
            loadedCreature.Loneliness -= 0.2f;
        }
        creature = loadedCreature;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);
    }


    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //       waterValue += 0.1f; ;
    //}

    //   private void OnGiveWater(object sender, EventArgs e)
    //   {
    //       waterValue += 0.1f;
    //   }
}

