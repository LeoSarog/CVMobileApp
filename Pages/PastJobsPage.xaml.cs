using System.Collections.ObjectModel;
using System.Text.Json;

namespace CVMobileApp.Pages;

public class PastJob
{
  public string Company { get; set; }
  public string Location { get; set; }
  public string Duration { get; set; }
  public string Description { get; set; }
}

public partial class PastJobsPage : ContentPage
{
  public ObservableCollection<PastJob> PastJobsCollection { get; set; }
  public PastJobsPage()
	{
		InitializeComponent();
    LoadJsonData();
  }

  private async void LoadJsonData()
  {
    // Read the JSON file from the app's resources
    using var stream = await FileSystem.OpenAppPackageFileAsync("past_jobs.json");
    using var reader = new StreamReader(stream);
    var json_content = await reader.ReadToEndAsync();

    // Deserialize JSON data to a list of coding langueages objects
    PastJobsCollection = JsonSerializer.Deserialize<ObservableCollection<PastJob>>(json_content);
    // Set the BindingContext to self
    BindingContext = this;
  }

  private async void onBackToBasicMenuBtnClicked(object sender, EventArgs e)
  {
    await Navigation.PopAsync();
  }
}