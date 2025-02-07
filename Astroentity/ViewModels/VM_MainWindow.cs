using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Data;

namespace Astroentity.ViewModels
{
    public partial class VM_MainWindow : ViewModelBase
    {
		/////////////////////////////////////////////////////////
		#region Commands

		[RelayCommand]
		void TogglePane()
		{
			IsPaneOpen = !IsPaneOpen;
		}

		[RelayCommand]
		void NavigateHome()
		{
            Navigate("home");	
		}

        [RelayCommand]
        void NavigateGalaxies()
        {
            Navigate("galaxies");
        }

        [RelayCommand]
        void NavigateNebulae()
        {
            Navigate("nebulae");
        }

        [RelayCommand]
        void NavigateStars()
        {
            Navigate("stars");
        }

        [RelayCommand]
        void NavigateSettings()
        {
            Navigate("settings");
        }

        #endregion Commands
        /////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////
        #region Properties

        [ObservableProperty]
		bool isPaneOpen = true;

		[ObservableProperty]
		UserControl? activeContent;

		[ObservableProperty]
		Dictionary<string, UserControl> views = [];

		#endregion Properties
		/////////////////////////////////////////////////////////
		

        public VM_MainWindow()
        {
            views.Add("home", new V_Home());
            views.Add("galaxies", new V_Galaxies());
            views.Add("nebulae", new V_Nebulae());
            views.Add("stars", new V_Stars());
            views.Add("settings", new V_Settings());

            NavigateHome();
        }

        private void Navigate(string key)
        {
            key = key.ToLower();
            if (Views.ContainsKey(key))
            {
                ActiveContent = Views[key];
            }
            else
            {
                sbdotnet.Logger.Warning($"View {key} not found");
            }
        }
	}
}
