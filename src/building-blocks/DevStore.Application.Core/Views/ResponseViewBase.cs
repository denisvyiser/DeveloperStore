using DevStore.Api.Core.ResponseModels;

namespace DevStore.Application.Core.Views
{
    public class ResponseViewBase<TView> where TView : ViewBase
    {
        public Guid Id { get; set; }
    }
}
