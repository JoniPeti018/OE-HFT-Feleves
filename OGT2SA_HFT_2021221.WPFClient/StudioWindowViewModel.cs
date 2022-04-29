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
    public class StudioWindowViewModel : ObservableRecipient
    {
        public RestCollection<Studio> StudioCollection { get; set; }
        private Studio selectedStudio;
        public Studio SelectedStudio
        {
            get { return selectedStudio; }
            set
            {
                if (value != null)
                {
                    selectedStudio = new Studio()
                    {
                        studio_id = value.studio_id,
                        studio_name = value.studio_name,
                        founded = value.founded,
                        founder = value.founder,
                        headquarters = value.headquarters,
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
        public StudioWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                StudioCollection = new RestCollection<Studio>("http://localhost:9346/", "studio", "hub");

                CreateCommand = new RelayCommand(() =>
                {
                    StudioCollection.Add(new Studio()
                    {
                       studio_name = selectedStudio.studio_name,
                       founded = selectedStudio.founded,
                       founder = selectedStudio.founder,
                       headquarters = selectedStudio.headquarters,
                    });
                    System.Threading.Thread.Sleep(200);
                    StudioCollection.Update(SelectedStudio);
                });

                UpdateCommand = new RelayCommand(() =>
                {
                    try
                    {
                        StudioCollection.Update(SelectedStudio);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });

                DeleteCommand = new RelayCommand(() =>
                {
                    StudioCollection.Delete(selectedStudio.studio_id);
                },
                () =>
                {
                    return selectedStudio != null;
                });
                selectedStudio = new Studio();
            }
        }

    }
}
