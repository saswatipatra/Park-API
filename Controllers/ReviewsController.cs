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
    public class ReviewsController : ControllerBase
    {
        private ParksContext _db = new ParksContext();

        // GET api/Reviews
        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get()
        {
            return _db.Reviews
                   .ToList();
        }

        // POST api/Reviews
        [HttpPost]
        public void Post([FromBody] Review review)
        {
            _db.Reviews.Add(review);
            Console.WriteLine("Review added");
            var thisNationalPark = _db.NationalParks
                .Include(NationalPark => NationalPark.Reviews)
                .FirstOrDefault(x => x.NationalParkId == review.NationalParkId);
            thisNationalPark.GetAvgRating();
            _db.SaveChanges();
        }

        // GET api/Reviews/1
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            return _db.Reviews.FirstOrDefault(x => x.ReviewId == id);
        }

        // PUT api/Reviews/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Review review)
        {
            review.ReviewId = id;
            _db.Entry(review).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/Reviews/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var thisReview = _db.Reviews.FirstOrDefault(x => x.ReviewId == id);
            _db.Reviews.Remove(thisReview);
            _db.SaveChanges();
        }
    }
}