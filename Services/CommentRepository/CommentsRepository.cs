using AnimalPlaceProject.Data;
using AnimalPlaceProject.Models;
using AnimalPlaceProject.Services.AnimalRepository;
using System.ComponentModel.Design;

namespace AnimalPlaceProject.Services.CommentRepository
{
    public class CommentsRepository : ICommentsRepository
    {
        private MyContext _context;
        private IAnimalRepository _AnimalRepository;
        public CommentsRepository(MyContext context, IAnimalRepository animalRepository)
        {
            _context = context;
            _AnimalRepository = animalRepository;
        }

        public void AddComment(string content, Animal currentAnimal)
        {
            Comment comment = new Comment { animalId = currentAnimal.AnimalId };
            comment.Content = content;
            comment.numOfLikes = 0;
            comment.isLiked = false;
            currentAnimal?.Comments?.Add(comment);
            _context.SaveChanges();

        }

        public void AddLike(int commentId, bool isLiked)
        {
          
            Comment currentComment = GetFirst(commentId);
            currentComment.isLiked = !currentComment.isLiked;
            if (currentComment.isLiked == true)
            {
                currentComment.numOfLikes++;
            }
            else
            {
                currentComment.numOfLikes--;
            }

            _context.SaveChanges();
        }

        public Comment GetFirst(int commentId)
        {
            return _context.Comment.FirstOrDefault(b => b.Id == commentId)!;
        }
    }
}
