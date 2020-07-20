using System.Collections.Generic;
using DomainClass.Enums;
using DomainClass.Enums.DeviceEnums;
using DomainClass.ViewModels;
using DomainClass.ViewModels.DeviceViewModels;
using JG.Application.PipeAndFilter;

namespace BusinessLayer.Device.DoDeliver
{
    public static class DoDeliverPipeline
    {
        public static Pipeline<VDeliveryFood> Build(string cardid,List<GroupDto> groupList,int deviceId, string password, 
            IdentityType identifyType, DeviceSeries deviceSeries)
        {
            var pipeline = new Pipeline<VDeliveryFood>();
            pipeline.AddOperation(new AuthenticateByCardProcess(cardid, groupList, identifyType));
            pipeline.AddOperation(new AuthenticateByFishFaramoshiProcess(cardid, password, groupList, identifyType));
            pipeline.AddOperation(new CurrentMealProcess(deviceSeries));
            pipeline.AddOperation(new CurrentMealEagleProcess(deviceSeries));
            pipeline.AddOperation(new StudentCreditProcess());
            pipeline.AddOperation(new FillReservationProcess(deviceId,deviceSeries));
            pipeline.AddOperation(new FillReservationEagleProcess(deviceId, deviceSeries));
            pipeline.AddOperation(new FishFaramoshiPenalty(identifyType, groupList));
            pipeline.AddOperation(new ConvertCurrentMealToEagleProcess());
            return pipeline;
        }
    }
}
