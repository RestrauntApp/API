using RestAppAPI.Models;

namespace RestAppAPI.Data
{
    public interface IContext
    {
        //User Table
        public void DenoteUserModified(User user);
        public Task<bool> CreateNewUser(User user);
        public Task<User?> GetUserByIdAsync(int id);
        public Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);

        //Restaurant Table
        public void DenoteRestaurantModified(Restaurant restraunt);
        public Task<Restaurant> GetRestaurantByIdAsync(int id);
        public Task<IEnumerable<Restaurant>> GetRestaurantsAsync();

        //Review Table
        public void DenoteReviewModified(Review review);
        public Task<Review> GetReviewByIdAsync(int id);
        public Task<IEnumerable<Review>> GetReviewsAsync();
        public Task<IEnumerable<Review>> GetReviewsByResIdAsync(int restId);
        public Task<double> GetRestAvgReviewAsync(int restId);

    }
}
