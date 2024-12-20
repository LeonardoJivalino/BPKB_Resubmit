namespace BPKB_BackEnd.Models
{
    public class EditModel
    {
        public string AgreementNumber { get; set; } = null!;
        public string BranchId { get; set; } = null!;
        public string BpkbNo { get; set; } = null!;
        public DateTime? BpkbDateIn { get; set; }
        public DateTime? BpkbDate { get; set; }
        public string FakturNo { get; set; } = null!;
        public DateTime? FakturDate { get; set; }
        public string PoliceNo { get; set; } = null!;
        public string LocationId { get; set; } = null!;
        public string LocationName { get; set; } = null!;
        public string CurrentLocation { get; set; } = null!;
        public List<StorageLocationModel> StorageLocations { get; set; }
    }
}
