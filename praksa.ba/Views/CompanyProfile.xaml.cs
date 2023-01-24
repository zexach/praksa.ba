using Newtonsoft.Json;
using praksa.ba.Models;
using System.Text;
using System.Text.RegularExpressions;
using static praksa.ba.Views.LoginPage;

namespace praksa.ba.Views;

public partial class CompanyProfile : ContentPage
{
    User currentUser = new User();
    public CompanyProfile()
	{
		InitializeComponent();
        currentUser = JsonConvert.DeserializeObject<User>(SharedData.jsonString);
        fullNameField.Text = currentUser.fullName;
        usernameField.Text = currentUser.username;
        typeField.Text = currentUser.typeOfUser;
    }

    public class Password
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }

    }

    private async void resetPassword(object o, EventArgs e)
    {
        string oldPassword = oldPasswordInput.Text;
        string newPassword = newPasswordInput.Text;
        string confirmPassword = newPassword2Input.Text;

        if (oldPassword == null || newPassword == null || confirmPassword == null)
        {
            DisplayAlert("Greška", "Morate popuniti sva polja.", "OK");
        }
        else if (!oldPassword.Equals(currentUser.password))
        {
            DisplayAlert("Greška", "Stara šifra koju ste unijeli nije ispravna.", "OK");
        }
        else
        {
            if (!newPassword.Equals(confirmPassword))
            {
                DisplayAlert("Greška", "Potvrđena šifra se ne poklapa sa novom šifrom.", "OK");
            }
            else if (newPassword.Equals(oldPassword))
            {
                DisplayAlert("Greška", "Nova šifra ne može biti ista kao stara šifra", "OK");
            }
            else
            {
                string passwordPattern = "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$";
                if (!Regex.IsMatch(newPassword, passwordPattern))
                {
                    DisplayAlert("Greška", "Neispravan format šifre.", "OK");
                }
                else
                {
                    Password tempPassword = new Password()
                    {
                        oldPassword = oldPassword,
                        newPassword = newPassword
                    };

                    string loginInfoJsonString = System.Text.Json.JsonSerializer.Serialize(tempPassword);
                    StringContent content = new StringContent(loginInfoJsonString, Encoding.UTF8, "application/json");

                    HttpClient client = new HttpClient();

                    HttpResponseMessage response = await client.PutAsync($"https://praksa.onrender.com/api/v1/users/reset-password/{currentUser._id}", content);
                    string responseString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        DisplayAlert("Registracija", "Uspješno ste promijenili šifru", "OK");
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        DisplayAlert("Registracija", "Greška prilikom mijenjanja šifre. Probajte ponovo.", "OK");
                    }
                }
            }
        }

    }
}