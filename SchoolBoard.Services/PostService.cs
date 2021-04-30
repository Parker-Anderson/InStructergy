using SchoolBoard.Data;
using SchoolBoard.Data.DomainModels;
using SchoolBoard.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Services
{
    public class PostService
    {
        private readonly Guid _instructorId;
        public PostService(Guid userId)
        {
            _instructorId = userId;
        }
        public bool CreatePost(NewPostModel model)
        {
            var entity =
                new Post()
                {
                    Student = model.Student,
                    Instructor = model.Instructor,
                    InstructorId = model.InstructorId,
                    Title = model.Title,
                    Body = model.Body,
                    Created = model.Created
                };
            using (var context = new ApplicationDbContext())
            {
                context.Posts.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                    .Posts
                    .Select(p => new PostListItem
                    {
                        Id = p.Id,
                        Student = p.Student,
                        Instructor = p.Instructor,
                        InstructorId = p.InstructorId,
                        Title = p.Title,
                        Body = p.Body,
                        Replies = (ICollection<Data.DomainModels.PostReply>)p.Replies,
                        Created = p.Created
                    });
                return query.ToArray();
            }
        }
        public ICollection<PostListItem> GetPostsByStudent(Student student)
        {
            using (var context = new ApplicationDbContext())
            {
                return (ICollection<PostListItem>)context.Posts.Include("Replies").Include("Instructor").Where(p => p.Student == student).Select(p => new PostListItem
                {
                    Id = p.Id,
                    Student = p.Student,
                    Instructor = p.Instructor,
                    Title = p.Title,
                    Body = p.Body,
                    Replies = (ICollection<PostReply>)p.Replies,
                    Created = p.Created
                }).ToArray();
            }
        }
        public PostDetail GetPostById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Posts.Include("Student").Include("Instructor").Include("Replies")
                    .Single(p => p.Id == id);
                return
                    new PostDetail
                    {
                        Id = entity.Id,
                        Student = entity.Student,
                        Instructor = entity.Instructor,
                        InstructorId = entity.Instructor.Id,
                        Title = entity.Title,
                        Body = entity.Body,
                        Replies = (ICollection<PostReply>)entity.Replies,
                        Created = entity.Created
                    };
            }
        }
    }
}
