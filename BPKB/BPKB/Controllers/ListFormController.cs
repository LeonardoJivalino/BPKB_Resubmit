using BPKB.Data;
using BPKB.Services;
using Microsoft.AspNetCore.Mvc;

namespace BPKB.Controllers
{
    public class ListFormController : Controller
    {
        private readonly BpkbService _bpkbService;

        private readonly BPKBContext _context;
        public ListFormController(BpkbService bpkbService, BPKBContext context)
        {
            _bpkbService = bpkbService;
            _context = context;
        }
        public async Task<IActionResult> ListForm()
        {
            //var locations = await _bpkbService.GetLocation();
            var bpkbList = await _bpkbService.GetBPKB();
            return View(bpkbList);
        }
    }
}
