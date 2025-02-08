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
        string appTitle = string.Empty;

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
            AppTitle = $"{App.AppTitle} v{App.AppVersion}";

            views.Add(typeof(V_Home), new V_Home() { DataContext = new VM_Home() });
            views.Add(typeof(V_Galaxies), new V_Galaxies() { DataContext = new VM_Galaxies() });
            views.Add(typeof(V_Nebulae), new V_Nebulae() { DataContext = new VM_Nebulae() });
            views.Add(typeof(V_Stars), new V_Stars() { DataContext = new VM_Stars() });
            views.Add(typeof(V_Settings), new V_Settings() { DataContext = new VM_Settings() });

            NavigateHome();
        }

        private void Navigate(Type key)
        {
            if (Views.TryGetValue(key, out UserControl? value))
            {
                ActiveContent = value;
            }
            else
            {
                sbdotnet.Logger.Warning($"View {key} not found");
            }
        }
	}
}
