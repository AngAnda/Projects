using Dicitionary.Models;
using System.Collections.ObjectModel;

namespace Dictionary.Repository
{
    public interface IWordRepository
    {
        ObservableCollection<Word> GetWords();

        void SaveWord(ObservableCollection<Word> word);

        void AddWord(Word word);

        void DeleteWord(Word word);

        void UpdateWord(Word word, int index);
        ObservableCollection<string> GetCategories();

    }
}
