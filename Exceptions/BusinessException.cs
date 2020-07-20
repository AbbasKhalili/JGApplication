using System;

namespace JG.Application.Exceptions
{
    public class BusinessException : Exception
    {
        public int Code { get; protected set; }
        public string ExceptionMessage { get; protected set; }
    }
}