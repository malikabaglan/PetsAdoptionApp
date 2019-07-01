using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AdoptMe.ViewModels
{
    public class ObservableObject : INotifyPropertyChanged
    {

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
        /// <param name="propVal">Backing store.</param>
        /// <param name="value">Value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <param name="onChanged">On changed.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected bool SetProperty<T>(
            ref T propVal, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(propVal, value))
                return false;

            propVal = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BusinessPlanImages
    {
        public string ImageSrc { get; set; }
        public int Position { get; set; }
    }
    class WelcomePageVM : ObservableObject
    {
        public WelcomePageVM()
        {



            WelcomeImageList = new ObservableCollection<BusinessPlanImages>{
                    new BusinessPlanImages () { ImageSrc = "product_item_1.jpg" },
                      new BusinessPlanImages () { ImageSrc = "product_item_2.jpg"},
                        new BusinessPlanImages () { ImageSrc = "product_item_3.jpg" },
                        new BusinessPlanImages () { ImageSrc = "product_item_4.jpg"},
                        new BusinessPlanImages () { ImageSrc = "product_item_5.jpg" },
                          new BusinessPlanImages () { ImageSrc = "product_item_6.jpg" } };
                         // new BusinessPlanImages () { ImageSrc = "product_item_7.jpg" }};
            InformationLabelText = "The world's largest network of on-demand Workspaces";
        }

        private INavigation _navigation;
        private string informationLabelText = "Welcome!";
        private int _carouselPlansPositionLounge = 0;
        private ObservableCollection<BusinessPlanImages> _welcomeImageList = null;

        public ObservableCollection<BusinessPlanImages> WelcomeImageList
        {
            get { return _welcomeImageList; }
            set { SetProperty(ref _welcomeImageList, value); }
        }

        public int CarouselPlansPositionLounge
        {
            get { return _carouselPlansPositionLounge; }
            set
            {
                SetProperty(ref _carouselPlansPositionLounge, value);
                if (value == 0)
                    InformationLabelText = "The world's largest network of on-demand Workspaces";
                else if (value == 1)
                    InformationLabelText = "Meeting rooms, co-working desks, business lounges or even your own private office";
                else if (value == 2)
                    InformationLabelText = "Book a space by the hour, by the day, or even for a whole month";
                else InformationLabelText = "";
            }
        }

        public string InformationLabelText
        {
            get { return informationLabelText; }
            set { SetProperty(ref informationLabelText, value); }
        }

    }

}
