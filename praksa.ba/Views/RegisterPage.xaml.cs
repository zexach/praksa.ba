namespace praksa.ba.Views;
using System.Text.RegularExpressions;
using praksa.ba.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

	private async void registerUser(object o, EventArgs e)
	{
		string fullName = fullNameInput.Text;
        string email = emailInput.Text;
        string password = passwordInput.Text;
        bool praktikant = praktikantInput.IsChecked;
        bool company = companyInput.IsChecked;

        HttpClient client = new HttpClient();

        string isCompany;

        if (company) isCompany = "POSLODAVAC";
        else isCompany = "KORISNIK";

        RegisterRequest newRegisterRequest = new RegisterRequest
        {
            fullName = fullName,
            username = email,
            password = password,
            typeOfUser = isCompany
        };

        string registerInfoJsonString = JsonSerializer.Serialize(newRegisterRequest);
        StringContent content = new StringContent(registerInfoJsonString, Encoding.UTF8, "application/json");


        if (fullName == null || email == null || password == null || (!praktikant && !company))
        {
            DisplayAlert("Greška", "Niste unijeli potrebne podatke", "Ok");
        }
        else
        {
            string passwordPattern = "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$";

            if (Regex.IsMatch(password, passwordPattern))
            {
                HttpResponseMessage response = await client.PostAsync("https://praksa.onrender.com/api/v1/users/register", content);
                string responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    DisplayAlert("Registracija", "Uspješno ste se registrovali", "OK");
                }
                else
                {
                    DisplayAlert("Registracija", "Greška prilikom registracije. Probajte ponovo.", "OK");
                }
                fullNameInput.Text = "";
                emailInput.Text = "";
                passwordInput.Text = "";
                praktikantInput.IsChecked = false;
                companyInput.IsChecked = false;
            }
            else
            {
                DisplayAlert("Greška","Pogrešan format šifre","Ok");
            }
        }
    }
}