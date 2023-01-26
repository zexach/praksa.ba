using Java.Net;
using praksa.ba.Viewmodel;

namespace praksa.ba.Views;

public partial class SingleInternship : ContentPage
{
	public SingleInternship()
	{
		InitializeComponent();
		BindingContext = new DetailsViewModel();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void backClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void goToLink(object o, EventArgs e)
    {
        Launcher.OpenAsync("https://docs.google.com/forms/d/e/1FAIpQLScydo6FUl6r9Hg0E8xVlpnZMEWw_LYZ61PVUqZPtnZQ7DGW8Q/viewform?edit_requested=true");
    }
}