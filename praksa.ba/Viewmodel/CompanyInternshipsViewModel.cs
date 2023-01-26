using Android.Database;
using Android.OS;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using praksa.ba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static praksa.ba.Views.LoginPage;
using Debug = System.Diagnostics.Debug;
using praksa.ba.Views;
using System.Windows.Input;

namespace praksa.ba.Viewmodel
{
    public partial class CompanyInternshipsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Internship> internships = new ObservableCollection<Internship>();

        [ObservableProperty]
        bool isRefreshing;

        User currentUser = new User();

        public CompanyInternshipsViewModel()
        {
            currentUser = JsonConvert.DeserializeObject<User>(SharedData.jsonString);
            GetInternships();
        }

        [RelayCommand]
        private async void Display(Internship selectedInternship)
        {
            await Shell.Current.GoToAsync($"{nameof(SingleInternship)}",
                new Dictionary<string, object>
                {
                    ["Internship"] = selectedInternship
                });
        }

        [RelayCommand]
        private async void DeleteInternship(Internship selectedInternship)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"https://praksa.onrender.com/api/v1/posts/{selectedInternship.id}");

            if (response.IsSuccessStatusCode)
            {
                Application.Current.MainPage.DisplayAlert("Info", "Uspješno ste uklonili praksu.", "OK");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Info", "Greška prilikom uklanjanja prakse.", "OK");
            }
        }

        [RelayCommand]
        public async void GetInternships()
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://praksa.onrender.com/api/v1/posts/my-posts/{currentUser._id}");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Internships = JsonConvert.DeserializeObject<ObservableCollection<Internship>>(responseString);

                IsRefreshing = false;
            }
        }
    }
}
