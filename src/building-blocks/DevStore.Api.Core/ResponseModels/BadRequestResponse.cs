namespace DevStore.Api.Core.ResponseModels
{
    public class BadRequestResponse
    {
        public IEnumerable<string> Errors { get; }

        public BadRequestResponse(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}