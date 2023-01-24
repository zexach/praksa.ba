namespace praksa.ba.Views;

using praksa.ba.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;



public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void handleLogin(object o, EventArgs e)
	{
        HttpClient client = new HttpClient();

        string email = emailInput.Text;
		string password = passwordInput.Text;

		LoginRequest newLoginRequest = new LoginRequest()
		{
			username = email,
			password = password
		};

        string loginInfoJsonString = JsonSerializer.Serialize(newLoginRequest);
        StringContent content = new StringContent(loginInfoJsonString, Encoding.UTF8, "application/json");

        if (email == null || password == null)
		{
			DisplayAlert("Greška", "Niste unijeli email ili lozinku!", "OK");
		}
		else
		{
            HttpResponseMessage response = await client.PostAsync("https://praksa.onrender.com/api/v1/users/login", content);
			string responseString = await response.Content.ReadAsStringAsync();

			string jsonResponse = "{" + "\"message\":\"Ne postoji korisnik sa tim podacima\"" + "}";

            if (responseString.Equals(jsonResponse))
			{
                DisplayAlert("Login info", "Podaci za prijavu nisu ispravni", "OK");
			}
			else
			{
				App.Current.MainPage = new NavigationPage(new Panel());
            }
        }
    }
}