using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using praksa.ba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

using System.Threading.Tasks;
using praksa.ba.Views;
using CommunityToolkit.Mvvm.Input;

namespace praksa.ba.Viewmodel
{
    public partial class InternshipViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Internship> internships = new ObservableCollection<Internship>();

        public InternshipViewModel()
        {
            getInternships();
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

        [RelayCommand]
        public async void loadSingleInternship(Internship internship)
        {
            await Shell.Current.GoToAsync($"{nameof(SingleInternship)}",
                new Dictionary<string, object>
                {
                    ["Internship"] = internship
                });
        }

    }
}
