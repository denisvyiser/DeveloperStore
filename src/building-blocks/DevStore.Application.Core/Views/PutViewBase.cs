using DevStore.Api.Core.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Application.Core.Views
{
    public class PutViewBase<TView> : ViewBase
    {
        [FromRoute]
        public Guid Id { get; set; }

        [FromBody]
        public TView View { get; set; }
    }
}
