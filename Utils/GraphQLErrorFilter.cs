namespace Bank.Utils
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception != null)
            {
                return error.WithMessage(error.Exception.Message);
            }
            else
            {
                return error;
            }
        }
    }
}