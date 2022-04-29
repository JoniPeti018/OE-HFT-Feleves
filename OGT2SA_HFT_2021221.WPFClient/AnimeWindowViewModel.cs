using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    public class AnimeWindowViewModel : ObservableRecipient
    {
        public RestCollection<Anime> AnimeCollection { get; set; }
        private Anime selectedAnime;
        public Anime SelectedAnime
        {
            get { return selectedAnime; }
            set
            {
                if (value != null)
                {
                    selectedAnime = new Anime()
                    {
                        anime_id = value.anime_id,
                        anime_name = value.anime_name,
                        type = value.type,
                        aired = value.aired,
                        source = value.source,
                        studio_id = value.studio_id,
                    };
                    OnPropertyChanged();
                    (DeleteCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AnimeWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                AnimeCollection = new RestCollection<Anime>("http://localhost:9346/", "anime", "hub");

                CreateCommand = new RelayCommand(() =>
                {
                    AnimeCollection.Add(new Anime()
                    {
                        anime_name = selectedAnime.anime_name,
                        type = selectedAnime.type,
                        aired = selectedAnime.aired,
                        source = selectedAnime.source,
                        studio_id = selectedAnime.studio_id,
                    });
                    System.Threading.Thread.Sleep(200);
                    AnimeCollection.Update(SelectedAnime);
                });

                UpdateCommand = new RelayCommand(() =>
                {
                    try
                    {
                        AnimeCollection.Update(SelectedAnime);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });

                DeleteCommand = new RelayCommand(() =>
                {
                    AnimeCollection.Delete(selectedAnime.anime_id);
                },
                () =>
                {
                    return selectedAnime != null;
                });
                selectedAnime = new Anime();
            }
        }

    }
}
