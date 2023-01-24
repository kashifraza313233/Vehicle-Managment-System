namespace VM.Data.Models
{
    public class VehicleInfo
    {
        public int VId { get; set; }
        public string? Vehicle { get; set; } = string.Empty;
        public String? VehicleModel { get; set; } = string.Empty;
        public String? VehicleNumber { get; set; } = string.Empty;
        public string? OwnerName { get; set; } = string.Empty;
        public string? ContactNo { get; set; } = string.Empty;
        public string? EmailAddress { get; set; } = string.Empty;
    }
}