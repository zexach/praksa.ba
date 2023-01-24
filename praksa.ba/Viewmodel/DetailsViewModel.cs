using Android.Graphics;
using CommunityToolkit.Mvvm.ComponentModel;
using praksa.ba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praksa.ba.Viewmodel
{
    [QueryProperty(nameof(Internship), nameof(Internship))]

    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Internship internship;

        public DetailsViewModel()
        {

        }
    }
}
