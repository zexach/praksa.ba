using praksa.ba.Models;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using praksa.ba.Viewmodel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace praksa.ba.Views;

public partial class UserHomepage : ContentPage
{
    public UserHomepage()
	{
        InitializeComponent();
        BindingContext = new InternshipViewModel();
        Routing.RegisterRoute(nameof(SingleInternship), typeof(SingleInternship));
        NavigationPage.SetHasNavigationBar(this, false);
    }
	private void handleSearch(object o, EventArgs e)
	{
        DisplayAlert("Info", "Alo", "OK");
    }

    /*private void handleInternshipLoad(object o, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new SingleInternship());
    }*/
}
