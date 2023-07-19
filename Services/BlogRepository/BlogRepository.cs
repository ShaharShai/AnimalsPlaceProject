using AnimalPlaceProject.Data;
using AnimalPlaceProject.Models;

namespace AnimalPlaceProject.Services.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private MyContext _context;
        public BlogRepository(MyContext context)
        {
            _context = context;
        }
        public IEnumerable<BlogPost> GetAllPosts()
        {
            return _context.BlogPosts;
        }

        public BlogPost GetPostById(int id)
        {
            return _context.BlogPosts.SingleOrDefault(a => a.Id == id)!;
        }

        public void CreateBlogPost(BlogPost blogPost)
        {
            blogPost.CreateDate = DateTime.Now;
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();
        }

        public BlogPost GetLastPost()
        {
            return _context.BlogPosts.OrderByDescending(post => post.CreateDate).FirstOrDefault()!;
        }
    }
}
