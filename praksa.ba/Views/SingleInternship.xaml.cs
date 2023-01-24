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
}