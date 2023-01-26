using Newtonsoft.Json;
using praksa.ba.Models;
using praksa.ba.Viewmodel;
using static praksa.ba.Views.LoginPage;

namespace praksa.ba.Views;

public partial class CompanyHomepage : ContentPage
{
    User currentUser = new User();
    public CompanyHomepage()
	{
		InitializeComponent();
        BindingContext = new CompanyInternshipsViewModel();
        currentUser = JsonConvert.DeserializeObject<User>(SharedData.jsonString);
        companyName.Text = currentUser.fullName;
        Routing.RegisterRoute(nameof(SingleInternship), typeof(SingleInternship));
    }
}