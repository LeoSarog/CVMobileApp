using System.Collections.Generic;
using System.Text.Json;

namespace CVMobileApp.Pages;

public class CodingLanguagesModel
{
	public List<Pages.CodingLanguage> coding_languages { get; set; }
}


public partial class CodingLanguagesPage : ContentPage
{
	public CodingLanguagesModel coding_languages_model;
  public CodingLanguagesPage()
	{
		InitializeComponent();
    coding_languages_model = new CodingLanguagesModel();
    coding_languages_model.coding_languages = new List<Pages.CodingLanguage>();
    LoadJsonData();
  }

  private async void LoadJsonData()
  {
    // Read the JSON file from the app's resources
    using var stream = await FileSystem.OpenAppPackageFileAsync("coding_skills.json");
    using var reader = new StreamReader(stream);
    var json_content = await reader.ReadToEndAsync();

    // Deserialize JSON data to a list of coding langueages objects
    coding_languages_model.coding_languages = JsonSerializer.Deserialize<List<Pages.CodingLanguage>>(json_content);
    // Bind the View with the list that stored the contents of the json.
    CodingLanguagesListView.ItemsSource = coding_languages_model.coding_languages;
  }

  private async void onBackToBasicMenuBtnClicked(object sender, EventArgs e)
  {
    await Navigation.PopAsync();
  }
  
}