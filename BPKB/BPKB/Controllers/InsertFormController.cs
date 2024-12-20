using BPKB.Data;
using BPKB.Models;
using BPKB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BPKB.Controllers
{
    public class InsertFormController : Controller
    {
        private readonly BpkbService _bpkbService;

        private readonly BPKBContext _context;

        //public InsertFormController(BPKBContext context)
        //{
        //    _context = context;
        //}
        public InsertFormController(BpkbService bpkbService, BPKBContext context)
        {
            _bpkbService = bpkbService;
            _context = context;
        }
        public async Task<IActionResult> InsertForm()
        {
            var locations = await _bpkbService.GetLocation();
            return View(locations);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitBPKB([FromBody] BpkbModel data)
        {
            if (data == null)
            {
                return View(data);
            }
            StorageLocationModel storageLocation = await _bpkbService.GetLocationByName(data.LocationName);
            //MsStorageLocation storageLocation = await _context.MsStorageLocations.Where(x => x.LocationName == data.LocationName).SingleOrDefaultAsync();

            BpkbModel trBpkb = new BpkbModel();
            trBpkb.AgreementNumber = data.AgreementNumber;
            trBpkb.BranchId = data.BranchId;
            trBpkb.BpkbNo = data.BpkbNo;
            trBpkb.BpkbDateIn = data.BpkbDateIn;
            trBpkb.BpkbDate = data.BpkbDate;
            trBpkb.FakturNo = data.FakturNo;
            trBpkb.FakturDate = data.FakturDate;
            trBpkb.PoliceNo = data.PoliceNo;
            trBpkb.LocationId = storageLocation.LocationId;
            trBpkb.LocationName = storageLocation.LocationName;
            trBpkb.CreatedBy = HttpContext.Session.GetString("UserName");
            trBpkb.LastUpdatedBy = HttpContext.Session.GetString("UserName");

            if (data.AgreementNumber == null || data.AgreementNumber == "")
            {
                data.ValidationMessage = "Please fill all data!";

            }
            if (data.BranchId == null || data.BranchId == "")
            {
                data.ValidationMessage = "Please fill all data!";

            }
            if (data.BpkbNo == null || data.BpkbNo == "")
            {
                data.ValidationMessage = "Please fill all data!";

            }
            if (data.BpkbDateIn == null)
            {
                data.ValidationMessage = "Please fill all data!";

            }
            if (data.BpkbDate == null)
            {
                data.ValidationMessage = "Please fill all data!";

            }
            if (data.FakturNo == null || data.FakturNo == "")
            {
                data.ValidationMessage = "Please fill all data!";

            }
            if (data.FakturDate == null)
            {
                data.ValidationMessage = "Please fill all data!";

            }
            if (data.PoliceNo == null || data.PoliceNo == "")
            {
                data.ValidationMessage = "Please fill all data!";

            }
            if (data.LocationName == null || data.LocationName == "")
            {
                data.ValidationMessage = "Please fill all data!";

            }
            if (data.ValidationMessage != null && data.ValidationMessage != "")
            {
                return View();
            }

            await _bpkbService.SubmitBPKB(trBpkb);

            return Json(new { message = "Items saved successfully!" });

        }
    }
}
