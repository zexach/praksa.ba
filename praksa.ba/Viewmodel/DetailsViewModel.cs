using CommunityToolkit.Mvvm.ComponentModel;
using praksa.ba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praksa.ba.Viewmodel
{
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Internship internship;

        public DetailsViewModel()
        {

        }
    }
}
