﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wanderlust.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPageView : ContentPage
    {
        public LoginPageView()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.LoginViewModel;
        }
    }
}