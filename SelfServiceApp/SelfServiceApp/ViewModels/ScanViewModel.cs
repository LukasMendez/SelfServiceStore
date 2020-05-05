﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SelfServiceApp.Views;
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
                    this.OnPropertyChanged();
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
                    this.OnPropertyChanged();
                }
            }
        }

        public void StartScanning()
        {
            IsAnalyzing = true;
            IsScanning = true;
        }

        public void StopScanning()
        {
            IsAnalyzing = false;
            IsScanning = false;
        }

        public Command ScanCommand
        {
            get
            {
                return new Command(() =>

                {
                    StopScanning();

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        Barcode = Result.Text;

                        // Get the product from the barcode 
                        var product = await App.WebConnection.ScanItem(Barcode);
                        // Get a reference to the orderviewmodel
                        var orderViewModel = ServiceContainer.Resolve<OrderViewModel>();
                        // Add the product to its collection (observablecollection)
                        if (product != null)
                        {
                            orderViewModel.Products.Add(product);
                            // Switch to the orderview so the user can see it
                            App.Current.MainPage = new OrderView();

                        } else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", "This item is invalid, please scan another one", "OK");
                            StartScanning();
                        }


                    });

                });
            }
        }


        public Command BackCommand
        {
            get
            {
                return new Command(() =>

                {
                    StopScanning();

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        // Get a reference to the orderviewmodel
                        var orderViewModel = ServiceContainer.Resolve<OrderViewModel>();

                        // Switch to the orderview so the user can see it
                        App.Current.MainPage = new OrderView();

                    });

                });
            }
        }

        public Result Result { get; set; }
        public ScanViewModel()
        {
         //   PropertyChanged += ScanningViewModel_PropertyChanged; // TODO USE BASE VIEW MODEL 
        }

    }
}
