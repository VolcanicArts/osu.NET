using System;

namespace volcanicarts.osu.NET.Exceptions
{
    public class InvalidOsuClientCredentialsException : Exception
    {
        public InvalidOsuClientCredentialsException(string message) : base(message) { }
    }
}