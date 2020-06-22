using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Wanderlust.Models
{
    public class Landmark : BaseModel, INotifyPropertyChanged
    {
        private int _id;
        private string _landmarkName;
        private string _description;
        private string _imageUrl;
        private bool _mustSee;

        public int LandmarkId
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(LandmarkId));
            }
        }

        public string LandmarkName 
        { 
            get => _landmarkName;
            set
            {
                _landmarkName = value;
                RaisePropertyChanged(nameof(LandmarkName));
            }
        }

        public string LandmarkDescription 
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged(nameof(LandmarkDescription));
            }
        }

        public string ImageUrl 
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                RaisePropertyChanged(nameof(ImageUrl));
            }
        }

        public bool MustSee
        {
            get => _mustSee;
            set
            {
                _mustSee = value;
                RaisePropertyChanged(nameof(MustSee));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return LandmarkName;
        }
    }
}
