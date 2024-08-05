using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace CVMobileApp.Pages;

public partial class PublicationsPage : ContentPage
{
  public string SelectedItem { get; set; }

  public PublicationsPage()
  {
    InitializeComponent();

    // Sample data
    var items = new List<string>
            {
                "Apple",
                "Banana",
                "Cherry"
            };

    // Set the data source for the ListView
    itemsListView.ItemsSource = items;
  }

  private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
  {
    // Handle item selection
    if (e.SelectedItem is string selectedItem)
    {
      DisplayAlert("Item Selected", $"You selected: {selectedItem}", "OK");

      // Optionally, clear the selection
      ((ListView)sender).SelectedItem = null;
    }
  }

  private async void onBackToBasicMenuBtnClicked(object sender, EventArgs e)
  {
    await Navigation.PopAsync();
  }
}