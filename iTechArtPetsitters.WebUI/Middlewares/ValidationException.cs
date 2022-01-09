using System;

namespace iTechArtPetsitters.WebUI.Middlewares
{
    // custom exception class for throwing application specific exceptions
    public class ValidationException : Exception
    {
        public ValidationException() : base() { }
        public ValidationException(string message) : base(message) { }

    }
}
