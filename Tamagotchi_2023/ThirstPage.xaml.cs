using System.ComponentModel;

namespace Tamagotchi_2023;

public partial class ThirstPage : ContentPage
{

    private string _flavourText = "EEE";
    public string FlavourText
    {
        get { return _flavourText; }
        set
        {
            if (_flavourText != value)
            {
                _flavourText = value;
                OnPropertyChanged();
            }
        }
    }

    public ThirstPage()
	{
		InitializeComponent();
	}


    private void Button_Clicked(object sender, EventArgs e)
    {
        string[] gremlinreactions =
            {
                "nice water",
                "wow",
                "im not thirsty now",
                "thank you",
                "HOOYJAAAAA"
            };
        Random rand = new Random();
        int selection = rand.Next(0, gremlinreactions.Length);
        FlavourText = gremlinreactions[selection];
    }
}