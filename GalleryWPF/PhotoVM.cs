using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace GalleryWPF
{
    internal class PhotoVM : INotifyPropertyChanged
    {
        private PhotoModel? selectedPhoto;
        public PhotoModel? SelectedPhoto
        {
            get { return selectedPhoto; }
            set
            {
                selectedPhoto = value;
                OnPropertyChanged("SelectedPhoto");
            }
        }
        public int? Rate
        {
            get { return SelectedPhoto.rate; }
            set { SelectedPhoto.rate = value; }
        }
        public string? Path
        {
            get { return SelectedPhoto.Path; }
            set
            {
                SelectedPhoto.Path = value;
                OnPropertyChanged("Path");
            }
        }
        public string? Name
        {
            get { return SelectedPhoto.Name; }
            set 
            {
                SelectedPhoto.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string? Author
        {
            get { return SelectedPhoto.Author; }
            set
            {
                SelectedPhoto.Author = value;
                OnPropertyChanged("Author");
            }
        }
        public string? Date
        {
            get { return SelectedPhoto.Date; }
            set
            {
                SelectedPhoto.Date = value;
                OnPropertyChanged("Date");
            }
        }
        public ObservableCollection<PhotoModel> Photos { get; set; }
        public PhotoVM(string directoryPath)
        {
            Photos = new ObservableCollection<PhotoModel>();
            string[] imagesPaths = Directory.GetFiles(directoryPath);
            foreach(string imagePath in imagesPaths)
            {
                PhotoModel photo = new PhotoModel(imagePath);
                Photos.Add(photo);
            }
            selectedPhoto = Photos[0];
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }
    }
}
