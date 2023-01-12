using Microsoft.EntityFrameworkCore;
using RestAppAPI.Models;

namespace RestAppAPI.Data
{
    public class Context : DbContext
    {

        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        public Context(DbContextOptions<Context> options) : base(options) { }
        public Context() { }




        /************User Table*****************************/

        public void DenoteUserModified (User user)
        {
            Entry(user).State = EntityState.Modified; 
        }

        public async Task<bool> CreateNewUser (User user)
        {
            bool nameTaken = Users.Any(u => u.name == user.name);
            bool emailTaken = Users.Any(u => u.email == user.email);  

            if(nameTaken || emailTaken)
            {
                return false;
            }

            Users.Add(user);
            SaveChanges();
            return true;
        }



        /************Restaurant Table*****************************/
        public void DenoteRestaurantModified(Restaurant restraunt)
        {
            Entry(restraunt).State = EntityState.Modified;
        }

        /************Review Table*****************************/
        public void DenoteReviewModified (Review review)
        {
            Entry (review).State = EntityState.Modified;
        }
    }
}
