using System.Text.Json;

namespace CVMobileApp
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
    }

    private async void OnMainPageButtonClicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new CVMobileApp.Pages.BasicMenu());
    }
  }

}
