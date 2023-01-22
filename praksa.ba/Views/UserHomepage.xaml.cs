using praksa.ba.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using static Android.Provider.Contacts;
using System.Collections.ObjectModel;
using praksa.ba.Viewmodel;

namespace praksa.ba.Views;

public partial class UserHomepage : ContentPage
{

    //ObservableCollection<Internship> internships;

    public UserHomepage()
	{
        InitializeComponent();
        BindingContext = new InternshipViewModel();
        NavigationPage.SetHasNavigationBar(this, false);
    }
	private void handleSearch(object o, EventArgs e)
	{
		DisplayAlert("Error", "Work in progress", "OK");
	}

    private void handleInternshipLoad(object o, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new SingleInternship());
    }
}
