using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
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
            Navigate(typeof(V_Home));	
		}

        [RelayCommand]
        void NavigateGalaxies()
        {
            Navigate(typeof(V_Galaxies));
        }

        [RelayCommand]
        void NavigateNebulae()
        {
            Navigate(typeof(V_Nebulae));
        }

        [RelayCommand]
        void NavigateStars()
        {
            Navigate(typeof(V_Stars));
        }

        [RelayCommand]
        void NavigateSettings()
        {
            Navigate(typeof(V_Settings));
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
		Dictionary<Type, UserControl> views = [];

		#endregion Properties
		/////////////////////////////////////////////////////////
		

        public VM_MainWindow()
        {
            views.Add(typeof(V_Home), new V_Home());
            views.Add(typeof(V_Galaxies), new V_Galaxies());
            views.Add(typeof(V_Nebulae), new V_Nebulae());
            views.Add(typeof(V_Stars), new V_Stars());
            views.Add(typeof(V_Settings), new V_Settings());

            NavigateHome();
        }

        private void Navigate(Type key)
        {
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
