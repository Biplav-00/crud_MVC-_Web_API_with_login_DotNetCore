using crud_api.Data;
using crud_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : Controller
    {
        

        private readonly PersonApiDbContext dbContex;
        public DeviceController(PersonApiDbContext dbContext)
        {
            this.dbContex = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> getAllDevice()
        {
            return Ok(await dbContex.tbl_Device.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> addDevice(AddDevice addDevice)
        {
            var dev = new Device
            {
                device_Name = addDevice.device_Name
            };
            await dbContex.tbl_Device.AddAsync(dev);
            await dbContex.SaveChangesAsync();
            return Ok(dev);
        }
    }
}
