using Microsoft.AspNetCore.Mvc;
using AnimalPlaceProject.Models;

namespace AnimalPlaceProject.Services.CommentRepository
{
    public interface ICommentsRepository
    {
        public void AddComment(string content, Animal currentAnimal);
        public Comment GetFirst(int commentId);
        public void AddLike(int commentId, bool isLiked);
    }
}
