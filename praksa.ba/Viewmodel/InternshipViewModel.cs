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

        public Command<string> goToProduct { get; set; }



        public InternshipViewModel()
        {
            getInternships();
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

        public async void getInternships()
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://praksa.onrender.com/api/v1/posts");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Internships = JsonConvert.DeserializeObject<ObservableCollection<Internship>>(responseString);
            }
        }


    }
}
