using CommunityToolkit.Maui.Views;
using System.Net;
using static System.Net.WebRequestMethods;

namespace CatShow;

public partial class MainPage : ContentPage
{
    string tempPath = System.IO.Path.GetTempPath();
    int i = 0;
    string catImagePath;
    string catImageType = ".jpg";
    string catURL;


    public MainPage()
    {
        InitializeComponent();
    }

    private void CatGenerator_Clicked(object sender, EventArgs e)
    {
        using (WebClient client = new WebClient())
        {
            catImagePath = tempPath + "cat" + i + catImageType;
            try
            {
                client.DownloadFile(new Uri(catURL), catImagePath);
            }
            catch (Exception)
            {
                var popup = new ErrorPopup();
                this.ShowPopup(popup);
            }
            i++;

            CatImage.Source = catImagePath;
            
        }
    }

    private void CatTypePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CatTypePicker.SelectedItem.ToString() != "Cat saying something")
        {
            CatTypeURLChooser();
            CatText.IsReadOnly = true;
            CatText.Text = "";
        }
        else
        {  
            CatText.IsReadOnly = false;
        }
    }

    private void CatText_TextChanged(object sender, TextChangedEventArgs e)
    {
        var popup = new ErrorPopup();
        CatTypeURLChooser(CatText.Text);
    }

    public void CatTypeURLChooser(string optionalCatText = "")
    {
        var popup = new ErrorPopup();
        switch (CatTypePicker.SelectedItem)
        {
            case "Random cat":
                catURL = "https://cataas.com/cat";
                catImageType = ".jpg";
                break;

            case "Cute cat":
                catURL = "https://cataas.com/cat/cute";
                catImageType = ".jpg";
                break;

            case "Gif cat":
                catURL = "https://cataas.com/cat/gif";
                catImageType = ".gif";
                break;

            case "Cat saying something":
                catURL = $"https://cataas.com/cat/says/{optionalCatText}";
                catImageType = ".gif";
                break;

            default:
                this.ShowPopup(popup);
                break;
        }
    }


}

