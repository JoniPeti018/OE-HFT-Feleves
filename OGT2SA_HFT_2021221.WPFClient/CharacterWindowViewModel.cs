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
    public class CharacterWindowViewModel : ObservableRecipient
    {
        public RestCollection<Character> CharacterCollection { get; set; }
        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set
            {
                if (value != null)
                {
                    selectedCharacter = new Character()
                    {
                        anime_id = value.anime_id,
                        character_id = value.character_id,
                        main_character = value.main_character,
                        main_voice = value.main_voice,
                        studio_id = value.studio_id,
                        support_character = value.support_character,
                        support_voice = value.support_voice,
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
        public CharacterWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                CharacterCollection = new RestCollection<Character>("http://localhost:9346/", "character", "hub");

                CreateCommand = new RelayCommand(() =>
                {
                    CharacterCollection.Add(new Character()
                    {
                        anime_id = selectedCharacter.anime_id,
                        main_character = selectedCharacter.main_character,
                        main_voice = selectedCharacter.main_voice,
                        studio_id = selectedCharacter.studio_id,
                        support_character = selectedCharacter.support_character,
                        support_voice = selectedCharacter.support_voice,
                    });
                    System.Threading.Thread.Sleep(200);
                    CharacterCollection.Update(SelectedCharacter);
                });

                UpdateCommand = new RelayCommand(() =>
                {
                    try
                    {
                        CharacterCollection.Update(SelectedCharacter);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });

                DeleteCommand = new RelayCommand(() =>
                {
                    CharacterCollection.Delete(selectedCharacter.character_id);
                },
                () =>
                {
                    return selectedCharacter != null;
                });
                selectedCharacter = new Character();
            }
        }
    }
}
