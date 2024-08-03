using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Diagnostics;

namespace CVMobileApp.Pages;

public class CodingLanguage
{
  public string Name { get; set; }
  public string Description { get; set; }
}

public partial class BasicMenu : ContentPage
{
  public BasicMenu()
	{
		InitializeComponent();
	}

  private async void onCodingSkillsBtnClicked(object sender, EventArgs e)
	{
		Console.WriteLine("CodingSkills sections was selected.");
    await Navigation.PushAsync(new CVMobileApp.Pages.CodingLanguagesPage());
  }

  private async void onPastJobsBtnClicked(object sender, EventArgs e)
  {
    Console.WriteLine("Past jobs sections was selected.");
  }

  private async void OnPublicationsBtnClicked(object sender, EventArgs e)
  {
    Console.WriteLine("Publications sections was selected.");
  }
}