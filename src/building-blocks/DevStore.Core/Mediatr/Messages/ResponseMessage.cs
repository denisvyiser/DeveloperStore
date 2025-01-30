using MediatR;

namespace DevStore.Core.Mediatr.Messages
{
    public abstract class ResponseMessage<TResponse> : IRequest<TResponse>
    {
        public string MessageType { get; set; }

        protected ResponseMessage()
        {
            MessageType = GetType().Name;
        }
    }
}