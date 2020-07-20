using DomainClass.Models.Devices;
using JG.Application.Chain;
using Newtonsoft.Json;

namespace BusinessLayer.Device.Alive
{
    public abstract class TemplateRequestChainHandler<TIn,TOut,TData> : BaseChainHandler<TIn, TOut> where TIn : DeviceRequest
    {
        protected abstract bool CanHandleRequest(TIn request);
        protected abstract void HandleRequest(TIn request, TOut response);
        
        protected TData Data;
        protected AliveCommunicate<object> CurrentDevice;
        

        public override void Handle(TIn request, TOut response)
        {
            CurrentDevice = DeviceCommunicate.Instance.GetById(request.DevId);
            Data = JsonConvert.DeserializeObject<TData>(request.Data?.ToString());
            if (CanHandleRequest(request))
            {
                HandleRequest(request, response);
                return;
            }
            else
            {
                CallNext(request, response);
            }
        }
    }
}