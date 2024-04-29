using Dicitionary.ViewModels;
using Dictionary.Models;
using Dictionary.Repository;
using Dictionary.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Dictionary.ViewModels
{
    public class QuizPageViewModel : BaseViewModel
    {

        static int numberOfWords = 5;


        private readonly RandomWordGenerator _randomWordGenerator;
        private ObservableCollection<WordDto> _words;


        private List<string> _userInputList;
        //private string _currentUserInput;

        public string UserInput
        {
            get { return _userInputList[CurrentIndex]; }
            set
            {
                _userInputList[CurrentIndex] = value;
                NotifyPropertyChanged(nameof(UserInput));
            }
        }

        public ObservableCollection<WordDto> Words
        {
            get => _words;
            set
            {
                _words = value;
                NotifyPropertyChanged(nameof(Words));
            }
        }

        public bool ShowDescription
        {
            get { return Words[CurrentIndex].ShowDescription; }
        }

        private int _currentIndex;

        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                _currentIndex = value;
                UpdateProperties();
            }
        }

        public WordDto CurrentWord
        {
            get => Words[CurrentIndex];
        }

        public string RightButtonContent
        {
            get => (CurrentIndex == numberOfWords-1)? "Finish" : "Next";
        }

        private void InitializeQuiz()
        {
            Words = _randomWordGenerator.GenerateRandomWords();
            _userInputList = Enumerable.Repeat(string.Empty, numberOfWords).ToList();
            CurrentIndex = 0;
        }

        public QuizPageViewModel()
        {
            _randomWordGenerator = new RandomWordGenerator(new WordRepository(), numberOfWords);
            InitializeQuiz();


            NextWordCommand = new RelayCommand(ExecuteNextWordCommand, _ => true) ;
            PreviousWordCommand = new RelayCommand(_ => CurrentIndex--, _ => CurrentIndex > 0);
        }

        private void ExecuteNextWordCommand(object parameter)
        {
            if (CurrentIndex < numberOfWords - 1)
            {
                CurrentIndex++;
                UpdateProperties();
            }
            else
            {
                ShowScore();
                InitializeQuiz();
            }
        }

        private void ShowScore()
        {
            int score = CalculateScore();
            MessageBox.Show($"Your score is {score} out of {numberOfWords}");
        }

        private int CalculateScore()
        {
            int score = 0;
            for (int i = 0; i < numberOfWords; i++)
            {
                if (Words[i].Name == _userInputList[i]) score++;
            }
            return score;
        }

        private void UpdateProperties()
        {
            NotifyPropertyChanged(nameof(CurrentIndex));
            NotifyPropertyChanged(nameof(CurrentWord));
            NotifyPropertyChanged(nameof(ShowDescription));
            NotifyPropertyChanged(nameof(UserInput));
            NotifyPropertyChanged(nameof(RightButtonContent));
        }

        

        public ICommand NextWordCommand { get; set; }

        public ICommand PreviousWordCommand { get; set; }

    }
}
