using System.Runtime.InteropServices;
using System.Windows.Input;

namespace CVMobileApp.Pages;

public partial class ContactPage : ContentPage
{
  public string Name { get; set; }
  public string Surname { get; set; }
  public string PersonalMail { get; set; }
  public string Message { get; set; }

  public ICommand SubmitCommand { get; }

  public ContactPage()
	{
		InitializeComponent();
    // Initialize the command for the button
    SubmitCommand = new Command(OnSubmit);

    // Set the BindingContext to self
    BindingContext = this;
  }

  private async void OnSubmit()
  {
    // Compose the email
    var email = new EmailMessage
    {
      Subject = "Contact Form Submission",
      Body = $"Name: {Name}\nSurname: {Surname}\nMessage: {Message}",
      To = new List<string> { "saros1993@gmail.com" } // Leo's email, please don't spam me :) <3
    };
    // Logic to handle the form submission
    try
    {
      // Send the email
      await Email.Default.ComposeAsync(email);
      // Clear the form after submission
      Name = string.Empty;
      Surname = string.Empty;
      PersonalMail = string.Empty;
      Message = string.Empty;
      // Refresh the bindings to update the UI
      OnPropertyChanged(nameof(Name));
      OnPropertyChanged(nameof(Surname));
      OnPropertyChanged(nameof(PersonalMail));
      OnPropertyChanged(nameof(Message));
    }
    catch (FeatureNotSupportedException)
    {
      await DisplayAlert("Error", "Email is not supported on this device.", "OK");
      await Navigation.PopAsync();
      return;
    }
    catch (Exception ex)
    {
      await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
      await Navigation.PopAsync();
      return;
    }

    // For example, you can display an alert with the input data
    await DisplayAlert("Contact Form", "You are going to be redirected to your mail client!", "OK");
    await Navigation.PopAsync();
  }
}