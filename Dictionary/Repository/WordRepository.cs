using Dicitionary.Models;
using Dictionary.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Dictionary.Repository
{
    public class WordRepository : IWordRepository
    {
        public ObservableCollection<Word> words = new ObservableCollection<Word>();

        private string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Resources", "words.json");

        public WordRepository()
        {
            words = GetWords() ?? new ObservableCollection<Word>();
        }

        public ObservableCollection<Word> GetWords()
        {
            if (!File.Exists(path))
            {

                File.WriteAllText(path, "[]");
            }
            try
            {
                string json = File.ReadAllText(path);
                var list = JsonConvert.DeserializeObject<ObservableCollection<Word>>(json);
                return (list != null) ? list : new ObservableCollection<Word>();
            }
            catch (Exception)
            {
                return new ObservableCollection<Word>();
            }
        }

        public void AddWord(Word word)
        {
            if (words.Any(w => w.Name == word.Name))
            {
                throw new WordExistsException("The word already exists in the dictionary.");
            }
            words.Add(word);
            SaveWord(words);
        }

        public void DeleteWord(Word word)
        {
            words.Remove(word);
            SaveWord(words);
        }

        public void UpdateWord(Word word, int index)
        {
            words[index] = word;
            SaveWord(words);
        }

        public void SaveWord(ObservableCollection<Word> word)
        {
            try
            {
                string json = JsonConvert.SerializeObject(words, Formatting.Indented);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A apărut o eroare: {ex.Message}");
            }
        }

        public ObservableCollection<string> GetCategories()
        {
            if (words.Count == 0)
                return new ObservableCollection<string>();
            return new ObservableCollection<string>(
                 words.DefaultIfEmpty().Select(w => w.Category).Distinct().ToList());
        }
    }
}
