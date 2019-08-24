using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;

namespace Parks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : ControllerBase
    {
        private ParksContext _db = new ParksContext();

        // GET api/NationalParks
        [HttpGet]
        public ActionResult<IEnumerable<NationalPark>> Get()
        {
            return _db.NationalParks
                // .Include(nationalPark => nationalPark.State)
                .ToList();
        }

        // POST api/NationalParks
        [HttpPost]
        public void Post([FromBody] NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);
            Console.WriteLine("NationalPark added");
            var thisState = _db.States
                .Include(state => state.NationalParks)
                .FirstOrDefault(x => x.StateId == nationalPark.StateId);
            thisState.GetAvgRating();
            _db.SaveChanges();
        }

        // GET api/NationalParks/1
        [HttpGet("{id}")]
        public ActionResult<NationalPark> Get(int id)
        {
            return _db.NationalParks.FirstOrDefault(x => x.NationalParkId == id);
        }

        // PUT api/NationalParks/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NationalPark nationalPark)
        {
            nationalPark.NationalParkId = id;
            _db.Entry(nationalPark).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/NationalParks/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var thisNationalPark = _db.NationalParks.FirstOrDefault(x => x.NationalParkId == id);
            _db.NationalParks.Remove(thisNationalPark);
            _db.SaveChanges();
        }
    }
}