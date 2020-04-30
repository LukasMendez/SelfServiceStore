using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using ZXing;

namespace SelfServiceApp.ViewModels
{
    public class ScanViewModel : BaseViewModel
    {
        //private readonly IRMAApiService _rmaApiService;
        //private readonly ISettingsService _settingsService;
        //private readonly IDialogService _dialogService;
        //private readonly INavigationService _navigationService;

        private string barcode = string.Empty;
        public string Barcode
        {
            get
            {
                return barcode;
            }
            set
            {
                barcode = value;
                this.OnPropertyChanged();
            }
        }

        private bool _isAnalyzing = true;
        public bool IsAnalyzing
        {
            get { return _isAnalyzing; }
            set
            {
                if (!Equals(_isAnalyzing, value))
                {
                    _isAnalyzing = value;
                }
            }
        }

        private bool _isScanning = true;
        public bool IsScanning
        {
            get { return _isScanning; }
            set
            {
                if (!Equals(_isScanning, value))
                {
                    _isScanning = value;
                }
            }
        }

        public Command ScanCommand
        {
            get
            {
                return new Command(() =>

                {
                    IsAnalyzing = false;
                    IsScanning = false;

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        Barcode = Result.Text;
                        await App.Current.MainPage.DisplayAlert("Scanned Item", Result.Text, "Ok");
                    });

                    IsAnalyzing = true;
                    IsScanning = true;
                });
            }
        }
        public Result Result { get; set; }
        public ScanViewModel()
        {
         //   PropertyChanged += ScanningViewModel_PropertyChanged; // TODO USE BASE VIEW MODEL 
        }

        private void ScanningViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}
