using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace CVMobileApp.Pages;

public partial class PublicationsPage : ContentPage
{
  public string SelectedItem { get; set; }
  public string PathToSelectedPublication { get; set; }
  public PublicationsPage()
  {
    InitializeComponent();

    // Sample data
    var items = new List<string>
            {
                "Self-Supervised Deep Depth Denoising",
                "Human4D",
                "AvoidX"
            };

    // Set the data source for the ListView
    itemsListView.ItemsSource = items;
  }

  private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
  {
    // Handle item selection
    if (e.SelectedItem is string selectedItem)
    {
      if (selectedItem == PathToSelectedPublication) return;
      switch (selectedItem)
      {
        case "Self-Supervised Deep Depth Denoising":
          PathToSelectedPublication = "DDD_Paper.pdf";
          break;
        case "Human4D":
          PathToSelectedPublication = "Human4D.pdf";
          break;
        case "AvoidX":
          PathToSelectedPublication = "AvoidX.pdf";
          break;
      }
      // Optionally, clear the selection
      ((ListView)sender).SelectedItem = null;
      // Open the PDFViewer
      await Navigation.PushAsync(new CVMobileApp.Pages.PDFViewer(PathToSelectedPublication));
    }
  }

  private async void onBackToBasicMenuBtnClicked(object sender, EventArgs e)
  {
    await Navigation.PopAsync();
  }
}