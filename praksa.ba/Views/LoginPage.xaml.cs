namespace praksa.ba.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

	}

	private void displayLoginInfo(object o, EventArgs e)
	{
		string email = emailInput.Text;
		string password = passwordInput.Text;
		if(email == null || password == null)
		{
			DisplayAlert("Gre�ka", "Niste unijeli email ili lozinku!", "Ok");
		}
		else
		{
            /*DisplayAlert("Va� login info: ", "Email: " + email
            + "\nPassword: " + password,
            "Ok");*/

        }
	}
}