
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tamagotchi_2023;
public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    private float waterValue = 0.1f;

    //public static readonly BindableProperty HungerBindablyProperty = BindableProperty.Create(nameof(Hunger), typeof(float), typeof(HungerView));

    //public float HungerBindablyProperty
    //{
    //    get => GetValue();
    //}

    public Creature creature
    {
        get;
        set;
    }
    //    = new Creature
    //{
    //    Name = "Gremlin",
    //    Hunger = 0.6f,
    //    Thirst = 0.1f
    //};

    public MainPage()
    {
        BindingContext = this;
        InitializeComponent();
        var newCreatureStore = DependencyService.Get<IDataStore<Creature>>();
        newCreatureStore.CreateItem(creature);
        //if (!newCreatureStore.CreateItem(creature))
        //{
        //    creature = newCreatureStore.ReadItem();
        //}
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

    private void DebugButtonClicked(object sender, EventArgs e)
    {
        var loadedCreature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
        loadedCreature.Hunger = 1f;
        creature = loadedCreature;
        DependencyService.Get<IDataStore<Creature>>().UpdateItem(creature);

        //creature = new Creature()
        //{
        //    Name = "DebugName",
        //    Hunger = 1f,
        //    Thirst = 1f
        //};
        //creature = newCreatureStore.CreateItem<Creature>(creature);

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

