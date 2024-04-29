using Dicitionary.Models;
using Dictionary.Repository;
using Dictionary.ViewModels;
using Dictionary.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Dicitionary.ViewModels
{
    public class AdministrationViewModel : BaseViewModel
    {

        private ObservableCollection<Word> _words;

        private int _selectedIndex;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                NotifyPropertyChanged(nameof(_selectedIndex));
            }
        }

        private Word _currentWord;
        public Word CurrentWord
        {
            get { return _currentWord; }
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
                if (_currentWord != null && !_categories.Contains(_currentWord.Category))
                {
                    _categories.Add(_currentWord.Category);

                    NotifyPropertyChanged(nameof(Categories));
                }
            }
        }

        private IWordRepository wordRepository;
        public ObservableCollection<Word> Words
        {
            get { return _words; }
            set
            {
                _words = value;
                NotifyPropertyChanged(nameof(Words));
            }
        }

        public AdministrationViewModel()
        {
            wordRepository = new WordRepository();
            Words = wordRepository.GetWords();
            AddWordCommand = new RelayCommand(AddWord, CanAddWord);
            DeleteWordCommand = new RelayCommand(DeleteWord, CanDeleteWord);
            UpdateWordCommand = new RelayCommand(UpdateWord, CanUpdateWord);
            NewWordCommand = new RelayCommand(_ => CurrentWord = new Word(), _ => true);
            AddImageCommad = new RelayCommand(AddImage, _ => true);
            DeleteImageCommand = new RelayCommand(_ => { CurrentWord.ImagePath = Word.DefaultImagePath; CommandManager.InvalidateRequerySuggested(); }, _ => true);
            ManageCredentials = new RelayCommand(_ => new ManageCredentials().ShowDialog(), _ => true);

            Categories = wordRepository.GetCategories();
            CurrentWord = new Word();
        }

        private bool CanAddWord(object parameter)
        {
            return !string.IsNullOrWhiteSpace(CurrentWord?.Name)
                && !string.IsNullOrWhiteSpace(CurrentWord?.Description)
                && !string.IsNullOrWhiteSpace(CurrentWord?.Category)
                && !Words.Any(c => c.Name == CurrentWord.Name);
        }

        private bool CanDeleteWord(object parameter)
        {
            return CurrentWord != null
                && Words.Contains(CurrentWord);
        }

        private bool CanUpdateWord(object parameter)
        {
            return CurrentWord != null && Words.Contains(CurrentWord);
        }

        private void DeleteWord(object parameter)
        {
            wordRepository.DeleteWord(CurrentWord);
            Words = wordRepository.GetWords();
            Categories = wordRepository.GetCategories();
            CurrentWord = new Word();
        }

        private void AddWord(object parameter)
        {
            try
            {
                wordRepository.AddWord(CurrentWord);
                Words = wordRepository.GetWords();
                Categories = wordRepository.GetCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Word Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            CurrentWord = new Word();
        }

        private void UpdateWord(object parameter)
        {
            wordRepository.UpdateWord(CurrentWord, SelectedIndex);
            Words = wordRepository.GetWords();
            Categories = wordRepository.GetCategories();
        }

        private void AddImage(object parameter)
        {
            CurrentWord.ImagePath = FileManager.SaveImage();
        }



        public ICommand AddWordCommand { get; }
        public ICommand DeleteWordCommand { get; }
        public ICommand UpdateWordCommand { get; }
        public ICommand NewWordCommand { get; }
        public ICommand AddImageCommad { get; }
        public ICommand DeleteImageCommand { get; }

        public ICommand ManageCredentials { get; }
    }
}
