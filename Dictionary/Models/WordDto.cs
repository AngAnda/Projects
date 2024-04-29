using Dicitionary.Models;

namespace Dictionary.Models
{
    public class WordDto : Word
    {
        public WordDto(Word word, bool showDescription) : base(word.Name, word.Category, word.Description, word.ImagePath)
        {
            this.showDescription = showDescription;
        }

        private bool showDescription;
        public bool ShowDescription
        {
            get { return showDescription; }
            set
            {
                showDescription = value;
                NotifyPropertyChanged(nameof(ShowDescription));
            }
        }
    }
}
