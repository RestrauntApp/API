using Microsoft.EntityFrameworkCore;
using RestAppAPI.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace RestAppAPI.Data
{
    public class Context : DbContext
    {

        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        public Context(DbContextOptions<Context> options) : base(options) { }
        public Context() { }




  /*********************************************User Table*****************************************************************/

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

            user.password = EncryptPwd(user.password);

            Users.Add(user);
            SaveChanges();
            return true;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await Users.FindAsync(id);
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            email.Trim();
            password.Trim();
            return await Users.FirstOrDefaultAsync(u => u.email == email && u.password == password);
        }





 /*******************************************Restaurant Table**************************************************************/
      
        public void DenoteRestaurantModified(Restaurant restraunt)
        {
            Entry(restraunt).State = EntityState.Modified;
        }


        public async Task<Restaurant> GetRestaurantByIdAsync (int id)
        {
            return await Restaurants.FindAsync(id);
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            return await Restaurants.ToListAsync<Restaurant>();
        }



 /**************************************** *********Review Table************************************************************/
       
        public void DenoteReviewModified (Review review)
        {
            Entry (review).State = EntityState.Modified;
        }

        public async Task<Review?> GetReviewByIdAsync(int id)
        {
            return await Reviews.FindAsync(id);
        }




 /*******************************************Helper Methods***************************************************************/

        private string EncryptPwd(string password)
        {
            SHA256 myHash = SHA256.Create();
            string salt = "restaurant";
            string combined = salt + password;

            byte[] bytes = new byte[combined.Length * sizeof(char)];
            System.Buffer.BlockCopy(combined.ToCharArray(), 0, bytes, 0, bytes.Length);

            byte[] hashvalue = myHash.ComputeHash(bytes);
            string hash = BitConverter.ToString(hashvalue).Replace("-", "");

            return hash;
        }
    }
}
