using System;

namespace Dictionary.Repository
{
    [Serializable]
    internal class UserExistsException : Exception
    {
        private static readonly string DefaultMessage = "This user already exists";
        public UserExistsException() : base(DefaultMessage)
        {
        }

    }
}