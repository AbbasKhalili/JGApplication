using BusinessLayer.Device.Alive.AliveChains;
using BusinessLayer.Device.Alive.DataChains;
using DomainClass.Models.Devices;
using JG.Application.Chain;

namespace BusinessLayer.Device.Alive
{
    public static class DeviceChainFactory
    {
        public static IHandler<DeviceRequest, DeviceResponse> CreateInstance()
        {
            return new ChainBuilder<DeviceRequest, DeviceResponse>()
                .WithHandler(new UcDetectorChain())
                .WithHandler(new IdentityDeviceChain())
                .WithHandler(new SendDeviceConfigChain())
                .WithHandler(new DeviceTasksChain())
                .WithHandler(new AliveChain())
                .WithHandler(new SendReservationAllEagleDataChain())
                .WithHandler(new SendReservationSobhKhaEagleDataChain())
                .WithHandler(new SendReservationNaharKhaEagleDataChain())
                .WithHandler(new SendReservationShamKhaEagleDataChain())
                .WithHandler(new BinaryVersionChain())
                .WithHandler(new OfflineCountChain())
                .WithHandler(new SendFoodDataChain())
                .WithHandler(new SendFoodTypeDataChain())
                .WithHandler(new SendMealDataChain())
                .WithHandler(new SendGroupDataChain())
                .WithHandler(new SendMealSchedulingDataChain())
                .WithHandler(new SendStudentDataChain())
                .WithHandler(new SendReservationDataChain())
                .WithHandler(new DeliveryOnlineEagleDataChain())
                .WithHandler(new DeliveryOnlineDataChain())
                .WithHandler(new DeliveryOfflineEagleDataChain())
                .WithHandler(new DeliveryOfflineDataChain())
                .WithHandler(new ReserveLessChain())
                .WithHandler(new SaveReserveLessChain())
                .WithHandler(new IncreaseCreditGiveInfoChain())
                .WithHandler(new IncreaseCreditPersistChain())
                .Build();
        }
    }
}
