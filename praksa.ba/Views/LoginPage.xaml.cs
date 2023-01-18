namespace praksa.ba.Views;
using System.Text.RegularExpressions;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

	}

	private void handleLogin(object o, EventArgs e)
	{
		string email = emailInput.Text;
		string password = passwordInput.Text;
		if(email == null || password == null)
		{
			DisplayAlert("Greška", "Niste unijeli email ili lozinku!", "OK");
		}
		else
		{
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

            if (Regex.IsMatch(email, pattern))
            {
				App.Current.MainPage = new NavigationPage(new UserPanel());
            }
            else
            {
				DisplayAlert("Greška", 
					"Pogrešan unos emaila",
				"OK");
            }
        }
	}
}