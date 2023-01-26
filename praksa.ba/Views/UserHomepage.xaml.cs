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
        Routing.RegisterRoute(nameof(NewPage1), typeof(NewPage1));
        NavigationPage.SetHasNavigationBar(this, false);
    }
	private void handleSearch(object o, EventArgs e)
	{
        DisplayAlert("Info", "Alo", "OK");
    }

}
