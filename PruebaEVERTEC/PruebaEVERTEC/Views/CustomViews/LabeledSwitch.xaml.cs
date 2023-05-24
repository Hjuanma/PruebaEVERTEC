using System;
using System.Collections.Generic;
using PruebaEVERTEC.Helpers;
using PruebaEVERTEC.Models;
using Xamarin.Forms;

namespace PruebaEVERTEC.Views.CustomViews
{	
	public partial class LabeledSwitch : ContentView
	{
        public static readonly BindableProperty TitleProperty =
       BindableProperty.Create(nameof(Title), typeof(string), typeof(LabeledSwitch));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }


        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(LabeledSwitch));

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }


        public LabeledSwitch()
        {
            InitializeComponent();
            switch ((ThemeEnum)Settings.Theme)
            {
                case ThemeEnum.Dark:
                    IsChecked = true;
                    break;
                case ThemeEnum.Light:
                    IsChecked = false;
                    break;
            }
        }

        private void OnTapped(object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
            if (IsChecked)
            {
                Settings.Theme = (int)ThemeEnum.Dark;
            }
            else
            {
                Settings.Theme = (int)ThemeEnum.Light;
            }

            Settings.SetTheme();
        }
    }
}

