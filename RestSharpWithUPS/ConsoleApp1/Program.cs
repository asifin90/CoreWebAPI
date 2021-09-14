using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
//using System.Text.Json;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            demo3();
        }




        static RateRequest ModelData()
        {
            // Request object
            RateRequest objReq = new RateRequest();
            objReq.Request = new Request();
            objReq.Request.SubVersion = "1703";
            objReq.Shipment = new Shipment();
            objReq.Shipment.ShipmentRatingOptions = new ShipmentRatingOptions();
            objReq.Shipment.ShipmentRatingOptions.UserLevelDiscountIndicator = "True";
            objReq.Shipment.Shipper = new Shipper();
            objReq.Shipment.Shipper.Name = "Billy Blanks";
            objReq.Shipment.Shipper.Address = new Address();
            objReq.Shipment.Shipper.Address.AddressLine = "366 Robin LN SE";
            objReq.Shipment.Shipper.Address.City = "Marietta";
            objReq.Shipment.Shipper.Address.StateProvinceCode = "GA";
            objReq.Shipment.Shipper.Address.PostalCode = "30067";
            objReq.Shipment.Shipper.Address.CountryCode = "US";
            objReq.Shipment.ShipTo = new ShipTo();
            objReq.Shipment.ShipTo.Name = "Sarita Lynn";
            objReq.Shipment.ShipTo.Address = new Address();
            objReq.Shipment.ShipTo.Address.AddressLine = "355 West San Fernando Street";
            objReq.Shipment.ShipTo.Address.City = "San Jose";
            objReq.Shipment.ShipTo.Address.StateProvinceCode = "CA";
            objReq.Shipment.ShipTo.Address.PostalCode = "95113";
            objReq.Shipment.ShipTo.Address.CountryCode = "US";
            objReq.Shipment.ShipFrom = new ShipFrom();
            objReq.Shipment.ShipFrom.Name = "Billy Blanks";
            objReq.Shipment.ShipFrom.Address = new Address();
            objReq.Shipment.ShipFrom.Address.AddressLine = "366 Robin LN SE";
            objReq.Shipment.ShipFrom.Address.City = "Marietta";
            objReq.Shipment.ShipFrom.Address.StateProvinceCode = "GA";
            objReq.Shipment.ShipFrom.Address.PostalCode = "30067";
            objReq.Shipment.ShipFrom.Address.CountryCode = "US";
            objReq.Shipment.Service = new Service();
            objReq.Shipment.Service.Code = "02";
            objReq.Shipment.Service.Description = "2nd Day Air";
            objReq.Shipment.ShipmentTotalWeight = new ShipmentTotalWeight();
            objReq.Shipment.ShipmentTotalWeight.UnitOfMeasurement = new UnitOfMeasurement();
            objReq.Shipment.ShipmentTotalWeight.UnitOfMeasurement.Code = "LBS";
            objReq.Shipment.ShipmentTotalWeight.UnitOfMeasurement.Description = "Pound";
            objReq.Shipment.ShipmentTotalWeight.Weight = "10";
            objReq.Shipment.Package = new Package();
            objReq.Shipment.Package.PackagingType = new PackagingType();
            objReq.Shipment.Package.PackagingType.Code = "02";
            objReq.Shipment.Package.PackagingType.Description = "Package";
            objReq.Shipment.Package.Dimensions = new Dimensions();
            objReq.Shipment.Package.Dimensions.UnitOfMeasurement = new UnitOfMeasurement();
            objReq.Shipment.Package.Dimensions.UnitOfMeasurement.Code = "IN";
            objReq.Shipment.Package.Dimensions.Length = "10";
            objReq.Shipment.Package.Dimensions.Width = "7";
            objReq.Shipment.Package.Dimensions.Height = "5";
            objReq.Shipment.Package.PackageWeight = new PackageWeight();
            objReq.Shipment.Package.PackageWeight.UnitOfMeasurement = new UnitOfMeasurement();
            objReq.Shipment.Package.PackageWeight.UnitOfMeasurement.Code = "LBS";
            objReq.Shipment.Package.PackageWeight.Weight = "7";
            objReq.Shipment.DeliveryTimeInformation = new DeliveryTimeInformation();
            objReq.Shipment.DeliveryTimeInformation.PackageBillType = "03";
            objReq.Shipment.DeliveryTimeInformation.Pickup = new Pickup();
            objReq.Shipment.DeliveryTimeInformation.Pickup.Date = "20210909";
            objReq.Shipment.DeliveryTimeInformation.Pickup.Time = "1130";
            return objReq;
        }


        static void demo3()
        {
            var client = new RestClient("https://wwwcie.ups.com/ship/v1/rating/Ratetimeintransit");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("AccessLicenseNumber", "Num");
            request.AddHeader("Password", "PWD");
            request.AddHeader("Username", "User");
            request.AddHeader("Content-Type", "application/json");
            string json = JsonConvert.SerializeObject(Program.ModelData());
            
            var body = json.Replace("null","\"\""); //"{ ""RateRequest"":{ ""Request"":{ ""SubVersion"":""1703"", ""TransactionReference"":{ ""CustomerContext"":"" "" } }, ""Shipment"":{ ""ShipmentRatingOptions"":{ ""UserLevelDiscountIndicator"":""TRUE"" }, ""Shipper"":{ ""Name"":""Billy Blanks"", ""ShipperNumber"":"" "", ""Address"":{ ""AddressLine"":""366 Robin LN SE"", ""City"":""Marietta"", ""StateProvinceCode"":""GA"", ""PostalCode"":""30067"", ""CountryCode"":""US"" } }, ""ShipTo"":{ ""Name"":""Sarita Lynn"", ""Address"":{ ""AddressLine"":""355 West San Fernando Street"", ""City"":""San Jose"", ""StateProvinceCode"":""CA"", ""PostalCode"":""95113"", ""CountryCode"":""US"" } }, ""ShipFrom"":{ ""Name"":""Billy Blanks"", ""Address"":{ ""AddressLine"":""366 Robin LN SE"", ""City"":""Marietta"", ""StateProvinceCode"":""GA"", ""PostalCode"":""30067"", ""CountryCode"":""US"" } }, ""Service"":{ ""Code"":""03"", ""Description"":""Ground"" }, ""ShipmentTotalWeight"":{ ""UnitOfMeasurement"":{ ""Code"":""LBS"", ""Description"":""Pounds"" }, ""Weight"":""10""}, ""Package"":{ ""PackagingType"":{ ""Code"":""02"", ""Description"":""Package"" }, ""Dimensions"":{ ""UnitOfMeasurement"":{ ""Code"":""IN"" }, ""Length"":""10"", ""Width"":""7"", ""Height"":""5"" }, ""PackageWeight"":{ ""UnitOfMeasurement"":{ ""Code"":""LBS"" }, ""Weight"":""7"" } } } } }";
            var data = "{ \"RateRequest\":" + body + "}";
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        
         static void TimeInTransit()
        {
            var client = new RestClient("https://wwwcie.ups.com/ship/v1/shipments/transittimes");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("AccessLicenseNumber", "CDA387C04F6A9C15");
            request.AddHeader("Password", "Capgemini2021");
            request.AddHeader("Username", "LucasProject");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("transactionSrc", "transaction source");
            request.AddHeader("transId", "transaction id");
            request.AddHeader("Content-Type", "application/json");
            var body = BindTimeInTransit(); //@"{" + "\n" +            @"""originCountryCode"":""US""," + "\n" +            @"""originStateProvince"":""""," + "\n" +            @"""originCityName"":""""," + "\n" +            @"""originTownName"":""""," + "\n" +            @"""originPostalCode"":""30067""," + "\n" +            @"""destinationCountryCode"":""US""," + "\n" +            @"""destinationStateProvince"":""""," + "\n" +            @"""destinationCityName"":""""," + "\n" +            @"""destinationTownName"":""""," + "\n" +            @"""destinationPostalCode"":""95113""," + "\n" +            @"""weight"":""10.0""," + "\n" +            @"""weightUnitOfMeasure"":""kgs""," + "\n" +            @"""shipmentContentsValue"":""10""," + "\n" +            @"""shipmentContentsCurrencyCode"":""EUR""," + "\n" +            @"""billType"":""03""," + "\n" +            @"""requestType"":""D""," + "\n" +            @"""shipDate"":""2021-09-29""," + "\n" +            @"""shipTime"":""17:00:00""," + "\n" +            @"""residentialIndicator"":""01""," + "\n" +            @"""numberOfPackages"":""1""," + "\n" +            @"""returnUnfilteredServices"": false," + "\n" +            @"""returnHeavyGoodsServices"": true," + "\n" +            @"""dropOffAtFacilityIndicator"": 1," + "\n" +            @"""holdForPickupIndicator"": 1" + "\n" +            @"} " + "\n" +            @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        static string BindTimeInTransit()
        {
            TimeInTransitRequest objTimeInTransitRequest = new TimeInTransitRequest();

            objTimeInTransitRequest.originCountryCode = "US";
            objTimeInTransitRequest.originPostalCode = "30067";
            objTimeInTransitRequest.destinationCountryCode = "US";
            objTimeInTransitRequest.destinationPostalCode = "30067";

            objTimeInTransitRequest.weight = "10.0";
            objTimeInTransitRequest.weightUnitOfMeasure = "kgs";
            objTimeInTransitRequest.shipmentContentsValue = "10";
            objTimeInTransitRequest.shipmentContentsCurrencyCode = "EUR";
            objTimeInTransitRequest.billType = "03";
            objTimeInTransitRequest.requestType = "D";
            objTimeInTransitRequest.shipDate = "2021-09-14";
            objTimeInTransitRequest.shipTime = "17:00:00";
            objTimeInTransitRequest.residentialIndicator = "01";
            objTimeInTransitRequest.numberOfPackages = "1";
            objTimeInTransitRequest.returnUnfilteredServices = false;
            objTimeInTransitRequest.returnHeavyGoodsServices = true;
            objTimeInTransitRequest.dropOffAtFacilityIndicator = 1;
            objTimeInTransitRequest.holdForPickupIndicator = 1;
            return JsonConvert.SerializeObject(objTimeInTransitRequest);
        }
        
    }
    
     public class TimeInTransitRequest
    {
        public string originCountryCode { get; set; }
        public string originStateProvince { get; set; }
        public string originCityName { get; set; }
        public string originTownName { get; set; }
        public string originPostalCode { get; set; }
        public string destinationCountryCode { get; set; }
        public string destinationStateProvince { get; set; }
        public string destinationCityName { get; set; }
        public string destinationTownName { get; set; }
        public string destinationPostalCode { get; set; }
        public string weight { get; set; }
        public string weightUnitOfMeasure { get; set; }
        public string shipmentContentsValue { get; set; }
        public string shipmentContentsCurrencyCode { get; set; }
        public string billType { get; set; }
        public string requestType { get; set; }
        public string shipDate { get; set; }
        public string shipTime { get; set; }
        public string residentialIndicator { get; set; }
        public string numberOfPackages { get; set; }
        public bool returnUnfilteredServices { get; set; }
        public bool returnHeavyGoodsServices { get; set; }
        public int dropOffAtFacilityIndicator { get; set; }
        public int holdForPickupIndicator { get; set; }
    }
}

