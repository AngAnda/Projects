using Dicitionary.Models;
using Dictionary.Repository;
using Dictionary.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dicitionary.ViewModels
{
    public class UserPageViewModel : BaseViewModel
    {

        private string _category;

        public string Category {
            get { return _category; }
            set
            {
                if (_category != value) 
                {
                    _category = value;
                    NotifyPropertyChanged(nameof(Category));
                    NotifyPropertyChanged(nameof(FilteredWords));
                }
            }
        }

        public string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                NotifyPropertyChanged(nameof(FilteredWords));
                NotifyPropertyChanged(nameof(CurrentWord));
                NotifyPropertyChanged(nameof(SearchText));
            }
        }

        public IWordRepository wordRepository { get; set; }

        private IEnumerable<Word> _filteredWords;

        public IEnumerable<Word> FilteredWords
        {
            get
            {
                return SearchText == null ?
                    _filteredWords
                    .Where(w => (string.IsNullOrEmpty(Category) || w.Category == Category))
                    .ToList():
                    _filteredWords
                    .Where(w => w.Name.StartsWith(SearchText) &&
                    (string.IsNullOrEmpty(Category) || w.Category == Category))
                    .ToList();
            }

            set
            {
                NotifyPropertyChanged(nameof(FilteredWords));
            }
        }

        private Word _currentWord;
        public Word CurrentWord
        {
            get
            {
                return _filteredWords.FirstOrDefault(w => w.Name == SearchText);
            }

            set
            {
                _currentWord = value;

                NotifyPropertyChanged(nameof(CurrentWord));
            }
        }

        private ObservableCollection<string> _categories;

        public ObservableCollection<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyPropertyChanged(nameof(Categories));
            }
        }

        public UserPageViewModel()
        {
            CurrentWord = new Word();
            wordRepository = new WordRepository();
            _filteredWords = wordRepository.GetWords();
            Categories = wordRepository.GetCategories();
        }

    }
}
