namespace JG.Application.Exceptions
{
    public class ExternalException : BusinessException
    {
        protected ExternalException(int exceptionCode, string message)
        {
            base.Code = exceptionCode;
            base.ExceptionMessage = message;
        }
    }
}