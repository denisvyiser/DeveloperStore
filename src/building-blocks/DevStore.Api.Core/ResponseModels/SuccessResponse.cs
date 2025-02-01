namespace DevStore.Api.Core.ResponseModels
{
    public class SuccessResponse<TResponseData>
    {
        public TResponseData Data { get; }

        public SuccessResponse(TResponseData data)
        {
            Data = data;
        }
    }
}