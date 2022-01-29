using System;

namespace CleanCQRS.Application.Exceptions
{
    public class DuplicateBookTitleException : Exception
    {
        public DuplicateBookTitleException(string title) : base($"The book already exists. Title = {title}")
        {

        }
    }
}
