﻿using System;
using System.Windows;


namespace Aak.Shell.UI.Showcase
{
    internal class AakXamlUIResource : ResourceDictionary
    {
        private static AakXamlUIResource? instance;
        public static AakXamlUIResource Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new InvalidOperationException("The AakXamlUIResource is not loaded!");
                }
                return instance;
            }
        }

        public AakTheme Theme
        {
            get => theme;
            set => UpdateAakTheme(theme = value);
        }

        public AakXamlUIResource()
        {
            instance = this;
            theme = AakThemeCollection.AllThemes[AakThemeCollection.AllThemes.Count - 1];

            InitializeThemes();
        }

        private AakTheme theme;

        private void InitializeThemes()
        {
            MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Aak.Shell.UI;component/Themes/Generic.xaml", UriKind.Relative)
            });

            MergedDictionaries.Add(theme);
        }

        private void UpdateAakTheme(AakTheme theme)
        {
            MergedDictionaries[1] = theme;
        }
    }

}
