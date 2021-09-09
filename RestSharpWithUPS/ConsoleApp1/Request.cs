

namespace ConsoleApp1
{
    public class TransactionReference
    {
        public string CustomerContext { get; set; }

    }
    public class Request
    {
        public string SubVersion { get; set; }
        public TransactionReference TransactionReference { get; set; }

    }
    public class ShipmentRatingOptions
    {
        public string UserLevelDiscountIndicator { get; set; }

    }
    public class Address
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }

    }
    public class Shipper
    {
        public string Name { get; set; }
        public string ShipperNumber { get; set; }
        public Address Address { get; set; }

    }
 
    public class ShipTo
    {
        public string Name { get; set; }
        public Address Address { get; set; }

    }

    public class ShipFrom
    {
        public string Name { get; set; }
        public Address Address { get; set; }

    }
    public class Service
    {
        public string Code { get; set; }
        public string Description { get; set; }

    }
    public class UnitOfMeasurement
    {
        public string Code { get; set; }
        public string Description { get; set; }

    }
    public class ShipmentTotalWeight
    {
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string Weight { get; set; }

    }
    public class PackagingType
    {
        public string Code { get; set; }
        public string Description { get; set; }

    }

    public class Dimensions
    {
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }

    }

    public class PackageWeight
    {
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string Weight { get; set; }

    }
    public class Package
    {
        public PackagingType PackagingType { get; set; }
        public Dimensions Dimensions { get; set; }
        public PackageWeight PackageWeight { get; set; }

    }
    public class ShipmentServiceOptions
    {
        public string SaturdayPickupIndicator { get; set; }

    }
    public class Pickup
    {
        public string Date { get; set; }
        public string Time { get; set; }

    }
    public class DeliveryTimeInformation
    {
        public string PackageBillType { get; set; }
        public Pickup Pickup { get; set; }

    }
    public class Shipment
    {
        public ShipmentRatingOptions ShipmentRatingOptions { get; set; }
        public Shipper Shipper { get; set; }
        public ShipTo ShipTo { get; set; }
        public ShipFrom ShipFrom { get; set; }
        public Service Service { get; set; }
        public ShipmentTotalWeight ShipmentTotalWeight { get; set; }
        public Package Package { get; set; }
        public ShipmentServiceOptions ShipmentServiceOptions { get; set; }
        public DeliveryTimeInformation DeliveryTimeInformation { get; set; }

    }
    public class RateRequest
    {
        public Request Request { get; set; }
        public Shipment Shipment { get; set; }

    }
    public class Application
    {
        public RateRequest RateRequest { get; set; }

    }

}
