using AnimalPlaceProject.Models;

namespace AnimalPlaceProject.Services.BlogRepository
{
    public interface IBlogRepository
    {
        public IEnumerable<BlogPost> GetAllPosts();
        public BlogPost GetPostById(int id);
        public void CreateBlogPost(BlogPost blogPost);
        public BlogPost GetLastPost();
    }
}
