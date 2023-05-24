using System;
using PruebaEVERTEC.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PruebaEVERTEC.Helpers
{
	public static class Settings
	{
		const int theme = (int)ThemeEnum.Default;
		public static int Theme
		{
			get => Preferences.Get(nameof(Theme), theme);
			set => Preferences.Set(nameof(Theme), value);
		}

		public static void SetTheme()
		{
            switch ((ThemeEnum)Settings.Theme)
            {
                case ThemeEnum.Dark:
					App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
                case ThemeEnum.Light:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
            }
        }
	}
}

