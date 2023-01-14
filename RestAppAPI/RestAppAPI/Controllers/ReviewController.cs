using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAppAPI.Data;
using RestAppAPI.Models;

namespace RestAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IContext context;

        public ReviewController(IContext context)
        {
            this.context = context;
        }   

        [HttpGet("/All")]
        public async Task<ActionResult<IEnumerable<Review>>> GetAllReviews()
        {
            var r = await context.GetReviewsAsync();

            if (r== null)
            {
                return NotFound();
            }

            return r.ToList();
        }

        [HttpGet("/Res/{id}")]
        public async Task< ActionResult<IEnumerable<Review>>>GetReviewsByRestId(Restaurant rest)
        {
            var r = await context.GetReviewsByResIdAsync(rest.id);

            if (r == null)
            {
                return NotFound();
            }

            return r.ToList();
        }

        [HttpGet("/Res/Avg")]
        public async Task<ActionResult<double>>GetRestAvgRev(Restaurant rest)
        {
            var r = await context.GetRestAvgReviewAsync(rest.id);

            return r;
        }

        [HttpPost("/new")]
        public async Task<ActionResult<Review>>NewUserReview(User user)
        {
            var r = await context.NewReviewAsync(user);

            return r;
        }


    }
}
