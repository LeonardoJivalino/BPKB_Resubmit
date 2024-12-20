﻿namespace BPKB.Models
{
    public class BpkbModel
    {
        public string AgreementNumber { get; set; } = null!;
        public string BranchId { get; set; } = null!;
        public string BpkbNo { get; set; } = null!;
        public DateTime BpkbDateIn { get; set; }
        public DateTime BpkbDate { get; set; }
        public string FakturNo { get; set; } = null!;
        public DateTime FakturDate { get; set; }
        public string PoliceNo { get; set; } = null!;
        public string LocationId { get; set; } = null!;
        public string LocationName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string LastUpdatedBy { get; set; } = null!;
        public string ValidationMessage { get; set; } = null!;
    }
}
