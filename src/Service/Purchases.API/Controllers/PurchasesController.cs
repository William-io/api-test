using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchases.API.Models;
using Purchases.API.Services;

namespace Purchases.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _service;

        public PurchasesController(IPurchaseService service)
        {
            _service = service;
        }

        //GET api/purchases
        [HttpGet]
        public ActionResult<IEnumerable<PurchaseItem>> Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);

        }

        //GET api/purchases/5
        [HttpGet("{id}")]
        public ActionResult<PurchaseItem> Get(int id)
        {
            var item = _service.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST api/compras
        [HttpPost]
        public ActionResult Post([FromBody] PurchaseItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }
        // DELETE api/compras/5
        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var existingItem = _service.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return Ok();
        }


    }
}
