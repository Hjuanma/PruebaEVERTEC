using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Xamarin.Forms;

namespace PruebaEVERTEC.Views.CustomViews
{
    public partial class CustomBottonView : ContentView
    {

        #region Properties


        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomBottonView), string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(CustomBottonView), string.Empty);

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly BindableProperty IsBusyProperty =
            BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(CustomBottonView), false);

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set
            {
                if (value != (bool)GetValue(IsBusyProperty))
                {
                    SetValue(IsBusyProperty, value);
                }
            }
        }

        public static readonly BindableProperty IsLoadingProperty =
            BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(CustomBottonView), false, propertyChanged: OnIsLoading);

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set
            {
                if (value != (bool)GetValue(IsLoadingProperty))
                {
                    SetValue(IsLoadingProperty, value);
                }
            }
        }


        public static readonly BindableProperty BtnColorProperty =
            BindableProperty.Create(nameof(BtnColor), typeof(Color), typeof(CustomBottonView), Color.White);

        public Color BtnColor
        {
            get { return (Color)GetValue(BtnColorProperty); }
            set
            {
                if (value != (Color)GetValue(BtnColorProperty))
                {
                    SetValue(BtnColorProperty, value);
                }
            }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CustomBottonView), Color.Black);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set
            {
                if (value != (Color)GetValue(TextColorProperty))
                {
                    SetValue(TextColorProperty, value);
                }
            }
        }

        public static readonly BindableProperty IconPosProperty =
            BindableProperty.Create(nameof(IconPos), typeof(LayoutOptions), typeof(CustomBottonView), LayoutOptions.Start);

        public LayoutOptions IconPos
        {
            get { return (LayoutOptions)GetValue(IconPosProperty); }
            set
            {
                SetValue(IconPosProperty, value);

            }
        }


        #endregion

        #region Commands

        public static readonly BindableProperty BtnCommandProperty =
            BindableProperty.Create(nameof(BtnCommand), typeof(DelegateCommand<object>), typeof(CustomBottonView), null);

        public DelegateCommand<object> BtnCommand
        {
            get { return (DelegateCommand<object>)GetValue(BtnCommandProperty); }
            set { SetValue(BtnCommandProperty, value); }
        }

        public static readonly BindableProperty BtnCommandParamProperty =
            BindableProperty.Create(nameof(BtnCommandParam), typeof(object), typeof(CustomBottonView), null);


        public object BtnCommandParam
        {
            get { return (object)GetValue(BtnCommandParamProperty); }
            set { SetValue(BtnCommandParamProperty, value); }
        }

        #endregion

        public CustomBottonView()
        {
            InitializeComponent();
        }


        private async static void OnIsLoading(BindableObject bindable, object oldValue, object newValue)
        {
            var btn = bindable as CustomBottonView;

            if ((bool)newValue)
            {
                await Task.WhenAny<bool>
                (
                  btn.stack.ScaleTo(0, 300),
                  btn.InnerActivityIndicator.FadeTo(1, 500)
                );

            }
            else
            {
                await Task.WhenAny<bool>
                (
                  btn.stack.ScaleTo(1, 500),
                  btn.InnerActivityIndicator.FadeTo(0, 200)
                );
            }
            btn.InnerActivityIndicator.IsRunning = (bool)newValue;
        }

    }
}

