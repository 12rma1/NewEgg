using System;

using Newegg.Marketplace.SDK;
using Newegg.Marketplace.SDK.Base;
using Newegg.Marketplace.SDK.Order;
using Newegg.Marketplace.SDK.Order.Model;

namespace NewEgg
{
    public class OrderInfo
    {
        private OrderCall ordercall;

        public OrderInfo()
        {
            APIConfig config = APIConfig.FromJsonFile("./setting.json");
            APIClient client = new APIClient(config);
            ordercall = new OrderCall(client);
        }

        public void GetOrderInfo()
        {
            var orderreq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                Status = Newegg.Marketplace.SDK.Order.Model.OrderStatus.Voided,
                Type = OrderInfoType.All
            });

            var response = ordercall.GetOrderInformation(null, orderreq).Result;
            GetOrderInformationResponseBody info = response.GetResponseBody();

            Console.WriteLine("{0,-30}{1,-30}{2,-30}{3,-30}{4,-30}",
                "OrderNumber",
                "ShipToFirstName",
                "ShipToAddress1", 
                "ShipToZipCode",
                "ShipToCountryCode");
                    
            var infoList = info.OrderInfoList;
            for (int i = 0; i < infoList.Count; i++ )
            {
                Console.WriteLine("{0,-30}{1,-30}{2,-30}{3,-30}{4,-30}",
                    infoList[i].OrderNumber,
                    infoList[i].ShipToFirstName,
                    infoList[i].ShipToAddress1, 
                    infoList[i].ShipToZipCode,
                    infoList[i].ShipToCountryCode);
            }
        }
    }
}