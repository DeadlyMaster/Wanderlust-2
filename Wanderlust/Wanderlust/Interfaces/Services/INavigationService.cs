using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wanderlust.Services
{
    public interface INavigationService
    {
        Page MainPage { get; }

        void Configure(string key, Type pageType);

        void GoBack();

        Task GoBackAsync();

        void NavigateTo(string pageKey, object parameter = null);

    }
}
