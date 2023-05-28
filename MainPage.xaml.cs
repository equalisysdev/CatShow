using System.Net;

namespace CatShow;

public partial class MainPage : ContentPage
{
    string url = "https://cataas.com/cat/cute";
    string tempPath = System.IO.Path.GetTempPath();
    int i = 0;
    string catImagePath;

    public MainPage()
    {
        InitializeComponent();
    }

    private void CatGenerator_Clicked(object sender, EventArgs e)
    {
        using (WebClient client = new WebClient())
        {
            catImagePath = tempPath + "cat" + i + ".jpg";
            client.DownloadFile(new Uri(url), catImagePath);
            i++;

            CatImage.Source = catImagePath;
        }
    }


}

