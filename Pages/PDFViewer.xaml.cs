#if ANDROID
using Android.Hardware;
#endif
using System.IO.Enumeration;
using System.Net;

namespace CVMobileApp.Pages;

public partial class PDFViewer : ContentPage
{
	public PDFViewer(string filename)
	{
    InitializeComponent();

#if ANDROID
            Microsoft.Maui.Handlers.WebViewHandler.Mapper.AppendToMapping("pdfviewer", (handler, View) =>
            {
                handler.PlatformView.Settings.AllowFileAccess = true;
                handler.PlatformView.Settings.AllowFileAccessFromFileURLs = true;
                handler.PlatformView.Settings.AllowUniversalAccessFromFileURLs = true;
            });

            pdfview.Source = $"file:///android_asset/pdfjs/web/viewer.html?file=file:///android_asset/{WebUtility.UrlEncode(filename)}";
#else
    pdfview.Source = filename;
#endif
  }

  private async void OnBackButtonClicked(object sender, EventArgs e)
  {
    // Pop to the target page
    await Navigation.PopAsync(); // or use PopAsync until you reach the target page
  }
}