using Dicitionary.Models;
using Dictionary.Models;
using Dictionary.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dictionary.Services
{
    internal class RandomWordGenerator
    {
        private IWordRepository _wordRepository;

        private readonly Random _random;

        private int _numberOfWords;

        public RandomWordGenerator(WordRepository wordRepository, int numberOfWords)
        {
            _wordRepository = wordRepository;
            _random = new Random();
            _numberOfWords = numberOfWords;
        }

        private IEnumerable<int> GenerateRandomList(int count)
        {
            var randomList = new List<int>();
            while(randomList.Count < _numberOfWords)
            {
                var randomIndex = _random.Next(count);
                if (!randomList.Contains(randomIndex))
                {
                    randomList.Add(randomIndex);
                }
            }
            return randomList;
        }

        private bool BinaryGenerator()
        {
            return _random.Next(2) == 0;
        }

        public ObservableCollection<WordDto> GenerateRandomWords()
        {
            var words = _wordRepository.GetWords();
            var randomList = GenerateRandomList(words.Count);
            var randomWords = new ObservableCollection<WordDto>();
            foreach (var index in randomList)
            {
                if (words[index].ImagePath == Word.DefaultImagePath)
                {
                    randomWords.Add(new WordDto(words[index], true));
                }
                else
                {
                    randomWords.Add(new WordDto(words[index], BinaryGenerator()));
                }
            }
            return randomWords;
        }

    }
}
