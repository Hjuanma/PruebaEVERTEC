using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PruebaEVERTEC.Views.CustomViews
{
    public partial class CustomEntryView : ContentView
    {
        #region Properties


        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomEntryView), string.Empty, BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(CustomEntryView), string.Empty);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(CustomEntryView), false, propertyChanged: OnIsPassword);


        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }

        public static readonly BindableProperty HidePasswordProperty =
            BindableProperty.Create(nameof(HidePassword), typeof(bool), typeof(CustomEntryView), false, BindingMode.TwoWay);

        public bool HidePassword
        {
            get { return (bool)GetValue(HidePasswordProperty); }
            set { SetValue(HidePasswordProperty, value); }
        }

        #endregion

        public CustomEntryView()
        {
            InitializeComponent();
        }

        private void OnImageButtonClicked(object sender, EventArgs e)
        {
            HidePassword = !HidePassword;
        }

        private static void OnIsPassword(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)newValue)
            {
                (bindable as CustomEntryView).HidePassword = true;
            }
        }
    }
}

