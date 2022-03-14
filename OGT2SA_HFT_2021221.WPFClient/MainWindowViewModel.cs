using Microsoft.Toolkit.Mvvm.Input;
using OGT2SA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OGT2SA_HFT_2021221.WPFClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Anime> Animes { get; set; }
        public RestCollection<Character> Characters { get; set; }
        public RestCollection<Studio> Studios { get; set; }
        private int SelectetTable { get; set; }

        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ICommand AnimeCommand { get; set; }
        public ICommand CharacterCommand { get; set; }
        public ICommand StudioCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                SelectetTable = 0;
                AnimeCommand = new RelayCommand(() =>
                {
                    SelectetTable = 0;
                });
                CharacterCommand = new RelayCommand(() =>
                {
                    SelectetTable = 1;
                });
                StudioCommand = new RelayCommand(() =>
                {
                    SelectetTable = 2;
                });
                
                //Animes = new RestCollection<Anime>("http://localhost:9346/", "anime");
                //Characters = new RestCollection<Character>("http://localhost:9346/", "character");
                //Studios = new RestCollection<Studio>("http://localhost:9346/", "studio");
            }
        }
    }
}
