namespace DevStore.Core.Models.Erros
{
    public enum ErrorType
    {
        ValidationError = 400,
        Unauthorized = 401,
        Forbidden = 403,
        ResourceNotFound = 404,
        ServerError = 500

    }
}
