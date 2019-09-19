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
    public class StatesController : ControllerBase
    {
        private ParksContext _db = new ParksContext();
        private static int _page = 1;
        private static int _size = 3;
        private static int _count;
        private static int _totalPages;
        private static int _prevPage;
        private static int _nextPage;

        // GET api/States
        [HttpGet]
        public ActionResult<IEnumerable<State>> Get()
        {
            var allStates = _db.States
                .ToList();
            _count = allStates.Count();
            _totalPages = (int)Math.Ceiling(_count / (float)_size);
            var output = _db.States
                .Take(_size)
                .Include(states => states.NationalParks)
                .ToList();
            return output;
        }

        // Get the next page
        [HttpGet("next/")]
        public ActionResult<IEnumerable<State>> GetNextPage()
        {
            _nextPage = _page < _totalPages ? _page + 1 : _totalPages;
            var output= _db.States
                .Include(states => states.NationalParks)
                .Skip((_nextPage - 1) * _size)
                .Take(_size)
                .ToList();
            if (_page<_totalPages)
            {
                _page += 1;
            }
            return output;
        }

        // Get the previous page
        [HttpGet("prev/")]
        public ActionResult<IEnumerable<State>> GetPrevPage()
        {
            _prevPage = _page > 1 ? _page - 1 : 1;
            var output= _db.States
                .Include(states => states.NationalParks)
                .Skip((_prevPage - 1) * _size)
                .Take(_size)
                .ToList();
            if (_page>1)
            {
                _page -= 1;
            }
            return output;
        }

        // POST api/states
        [HttpPost]
        public void Post([FromBody] State state)
        {
            _db.States.Add(state);
            _db.SaveChanges();
        }

        // GET api/states/1
        [HttpGet("{id}")]
        public ActionResult<State> Get(int id)
        {
            return _db.States
                .Include(states => states.NationalParks)
                .FirstOrDefault(x => x.StateId == id);
        }

        // PUT api/states/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] State state)
        {
            state.StateId = id;
            _db.Entry(state).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/states/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var thisState = _db.States.FirstOrDefault(x => x.StateId == id);
            _db.States.Remove(thisState);
            _db.SaveChanges();
        }
        
        // get Parks name by Country name
        [HttpGet("country/{country}")]
        public ActionResult<IEnumerable<State>> Get (string country)
        {
            return _db.States.Where(x => x.Country == country).ToList();
        }

        
    }
}