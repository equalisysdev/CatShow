using System.Net;
using static System.Net.WebRequestMethods;

namespace CatShow;

public partial class MainPage : ContentPage
{
    string tempPath = System.IO.Path.GetTempPath();
    int i = 0;
    string catImagePath;
    string catURL;

    public MainPage()
    {
        InitializeComponent();
    }

    private void CatGenerator_Clicked(object sender, EventArgs e)
    {
        using (WebClient client = new WebClient())
        {
            catImagePath = tempPath + "cat" + i + ".jpg";
            client.DownloadFile(new Uri(catURL), catImagePath);
            i++;

            CatImage.Source = catImagePath;
        }
    }

    private void CatTypePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CatTypePicker.SelectedItem != "Cat saying something")
        {
            CatTypeURLChooser();
        }
        else
        {
            
        }
    }

    public void CatTypeURLChooser(string optionalCatText = "")
    {
        switch (CatTypePicker.SelectedItem)
        {
            case "Random cat":
                catURL = "https://cataas.com/cat";
                break;

            case "Cute cat":
                catURL = "https://cataas.com/cat/cute";
                break;

            case "Gif cat":
                catURL = "https://cataas.com/cat/gif";
                break;

            case "Cat saying something":
                catURL = $"https://cataas.com/cat/says/{optionalCatText}";
                break;

            default:
                catURL = "https://cataas.com/cat";
                break;
        }
    }


}

