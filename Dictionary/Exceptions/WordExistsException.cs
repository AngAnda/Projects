using System;

namespace Dictionary.Exceptions
{
    internal class WordExistsException : Exception
    {
        private static readonly string DefaultMessage = "The word already exists in the dictionary.";
        public WordExistsException(string message) : base(message)
        {
        }
    }
}
