using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using praksa.ba.Models;
using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using praksa.ba.Views;

namespace praksa.ba.Viewmodel
{
    public partial class InternshipViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Internship> internships = new ObservableCollection<Internship>();
        
        [ObservableProperty]
        bool isRefreshing;

        //getting values from input fields
        private string _lokacijaText;
        public string location
        {
            get => _lokacijaText; set => SetProperty(ref _lokacijaText, value);
        }

        private string _pozicijaText;
        public string position
        {
            get => _pozicijaText; set => SetProperty(ref _pozicijaText, value);
        }

        private string _kompanijaText;
        public string company
        {
            get => _kompanijaText; set => SetProperty(ref _kompanijaText, value);
        }

        public InternshipViewModel()
        {
            GetInternships();
        }

        [RelayCommand]
        private async void NavigateToProduct (Internship selectedInternship)
        {
            await Shell.Current.GoToAsync($"{nameof(SingleInternship)}",
                new Dictionary<string, object>
                {
                    ["Internship"] = selectedInternship
                });
        }

        [RelayCommand]
        public async void GetInternships()
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://praksa.onrender.com/api/v1/posts");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Internships = JsonConvert.DeserializeObject<ObservableCollection<Internship>>(responseString);
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        public async void Filter()
        {
            Debug.WriteLine(location + company + position);
            if (location == null) location = "null";
            if (company == null) company = "null";
            if (position == null) position = "null";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await 
                client.GetAsync($"https://praksa.onrender.com/api/v1/posts/{location}&{company}&{position}");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Internships = JsonConvert.DeserializeObject<ObservableCollection<Internship>>(responseString);
                if (location == "null") location = "";
                if (company == "null") company = "";
                if (position == "null") position = "";
            }
        }


    }
}
