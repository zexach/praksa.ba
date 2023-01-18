namespace praksa.ba.Views;

public partial class UserPanel : ContentPage
{
	public UserPanel()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
	private void handleSearch(object o, EventArgs e)
	{
		DisplayAlert("Error", "Work in progress", "OK");
	}
}
