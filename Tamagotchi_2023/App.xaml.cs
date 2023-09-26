namespace Tamagotchi_2023;

public partial class App : Application
{

    public App()
    {
        var datastore = new CreatureDataStore();
        DependencyService.RegisterSingleton<IDataStore<Creature>>(datastore);

        InitializeComponent();

        MainPage = new AppShell();
    }
}
