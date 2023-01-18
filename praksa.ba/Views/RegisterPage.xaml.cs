namespace praksa.ba.Views;
using System.Text.RegularExpressions;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

	private void registerUser(object o, EventArgs e)
	{
		string fullName = fullNameInput.Text;
        string email = emailInput.Text;
        string password = passwordInput.Text;
        bool praktikant = praktikantInput.IsChecked;
        bool company = companyInput.IsChecked;

        if (fullName == null || email == null || password == null || (!praktikant && !company))
        {
            DisplayAlert("Greška", "Niste unijeli potrebne podatke", "Ok");
        }
        else
        {
            string emailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            string passwordPattern = "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$";

            if (Regex.IsMatch(email, emailPattern) && Regex.IsMatch(password, passwordPattern))
            {
                DisplayAlert("Registracija", "Uspješno ste se registrovali", "OK");
            }
            else
            {
                DisplayAlert("Greška",
                    "Pogrešan format maila ili šifre",
                "Ok");
            }
        }
    }
}