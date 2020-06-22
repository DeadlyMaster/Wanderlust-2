using Wanderlust.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Wanderlust.Services
{
    public class NavigationService : INavigationService
    {
        // Pages container
        private Dictionary<string, Type> pages { get; } = new Dictionary<string, Type>();
        // Link to the Main Page
        public Page MainPage => Application.Current.MainPage;

        //Add pages to dictionary
        public void Configure(string key, Type pageType) => pages[key] = pageType;

        // Move to previous page
        public void GoBack() => MainPage.Navigation.PopAsync();

        public void NavigateTo(string pageKey, object parameter = null)
        {
            if (pages.TryGetValue(pageKey, out Type pageType))
            {
                var page = (Page)Activator.CreateInstance(pageType);
                page.SetNavigationArgs(parameter);

                MainPage.Navigation.PushAsync(page);

                //access the view model from the navigation service
                (page.BindingContext as BaseViewModel).Initialize(parameter);
            }
            else
            {
                throw new ArgumentException($"This page doesn't exist: {pageKey}.", nameof(pageKey));
            }
        }

        public async Task GoBackAsync()
        {
            await MainPage.Navigation.PopAsync();
        }
    }

    public static class NavigationExtensions
    {
        private static ConditionalWeakTable<Page, object> arguments = new ConditionalWeakTable<Page, object>();

        public static object GetNavigationArgs(this Page page)
        {
            object argument;
            arguments.TryGetValue(page, out argument);

            return argument;
        }

        public static void SetNavigationArgs(this Page page, object args)
            => arguments.Add(page, args);
    }
}
