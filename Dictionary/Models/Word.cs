using Dictionary.ViewModels;

namespace Dicitionary.Models
{
    public class Word : BaseViewModel
    {
        public static string DefaultImagePath = "../../Resources/NoImage.jpg";

        public Word()
        {
            Name = string.Empty;
            Category = string.Empty;
            Description = string.Empty;
            ImagePath = DefaultImagePath;
        }

        public Word(string name, string category, string description, string imagePath)
        {
            Name = name;
            Category = category;
            Description = description;
            ImagePath = imagePath;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        private string _category;

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                NotifyPropertyChanged(nameof(Category));
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }

        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                NotifyPropertyChanged(nameof(ImagePath));
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Word word &&
                   Name == word.Name &&
                   Category == word.Category &&
                   Description == word.Description &&
                   ImagePath == word.ImagePath;
        }
    }
}
