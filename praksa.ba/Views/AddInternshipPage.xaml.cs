using Newtonsoft.Json;
using praksa.ba.Models;
using System.Text;
using static Android.Renderscripts.ScriptGroup;
using static praksa.ba.Views.LoginPage;

namespace praksa.ba.Views;

public partial class AddInternshipPage : ContentPage
{
    User currentUser = new User();
    public AddInternshipPage()
	{
		InitializeComponent();
        currentUser = JsonConvert.DeserializeObject<User>(SharedData.jsonString);
    }

	private async void addInternship(object o, EventArgs e)
	{
		string logo = logoInput.Text;
		string company = nazivInput.Text;
		string location = lokacijaInput.Text;
		string position = pozicijaInput.Text;
		string endDate = datumIstekaInput.Date.ToString();
		string duration = trajanjeInput.Text;
		string technologiesString = tehnologijeInput.Text;
		string companyDescription = opisKompanijeInput.Text;
		string internshipDescription = opisPrakseInput.Text;
		string link = linkInput.Text;

		if (logo == null || company == null || location == null || position == null || endDate == null || duration == null ||
			technologiesString == null || companyDescription == null || internshipDescription == null || link == null)
		{
			DisplayAlert("Greška", "Sva polja moraju biti popunjena.", "OK");
		}
		else
		{
			HttpClient client = new HttpClient();

			string[] technologies = technologiesString.Split(',');

			InternshipRequest internshipToAdd = new InternshipRequest()
			{
				postImageUrl = logo,
				position = position,
				company = company,
				location = location,
				endDate = endDate.Substring(0, 10),
				duration = duration,
				technologies = technologies,
				companyDescription = companyDescription,
				internshipDescription = internshipDescription,
				applicationLink = link,
				user = currentUser._id
			};

			string internshipToJson = System.Text.Json.JsonSerializer.Serialize(internshipToAdd);
			StringContent content = new StringContent(internshipToJson, Encoding.UTF8, "application/json");

			HttpResponseMessage response = await client.PostAsync("https://praksa.onrender.com/api/v1/posts", content);
			string responseString = await response.Content.ReadAsStringAsync();

			if (response.IsSuccessStatusCode)
			{
				DisplayAlert("Info", "Uspješno ste dodali novu praksu.", "OK");
			}
			else
			{
				DisplayAlert("Info", "Greška prilikom dodavanja nove prakse.", "OK");
			}
		}
	}
}