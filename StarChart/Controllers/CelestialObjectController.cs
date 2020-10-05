using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {

            var T = _context.CelestialObjects.Find(id);
            if (T != null)
            {
                T.Satellites.Add(T);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var T = _context.CelestialObjects.Find(name);
            if (T != null)
            {
                T.Satellites.Add(T);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            foreach (var item in _context.CelestialObjects)
            {
                item.Satellites.Add(item);

            }
            return Ok();
        }
    }
}
