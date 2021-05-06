using SchoolBoard.Data;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Models.PostModels;
using SchoolBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public ICollection<PostListItem> GetPostsByStudent(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context.Posts
                    .Include("Student")
                    .Include("Instructor.Name")
                    .Where(p => p.StudentId == id)
                    .Select(e => new PostListItem
                    {
                        Id = e.Id,
                        Instructor = e.Instructor,
                        MyName = e.MyName,
                        Title = e.Title,
                        Body = e.Body,
                        Created = e.Created
                        
                    });
                return query.ToArray();
            }
        }
        public PostDetail GetPostById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Posts
                    .Single(c => c.Id == id);
                return new PostDetail
                {
                    Id = entity.Id,
                    Instructor = entity.Instructor,
                    InstructorId = entity.InstructorId,
                    Student = entity.Student,
                    StudentId = entity.StudentId,
                    MyName = entity.MyName,
                    Title = entity.Title,
                    Body = entity.Body,
                    Created = entity.Created
                };
            }
        }

        public bool CreatePost(PostCreate model)
        {
            var courseService = new CourseService(_userId);
            var student = courseService.GetStudentByName(model.Student.Name);
            var entity =
                new Post
                {
                    Id = model.Id,
                    StudentId = student.Id,
                    InstructorId = _userId.ToString(),
                    MyName = model.MyName,
                    Title = model.Title,
                    Body = model.Body,
                    Created = DateTime.Now,
                };
            using (var context = new ApplicationDbContext())
            {
                context.Posts.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
        public bool UpdatePost(PostEdit model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Posts
                    .Single(p => p.Id == model.Id);
                entity.Title = model.Title;
                entity.Body = model.Body;
                entity.Created = DateTime.Now;
                return context.SaveChanges() == 1;
            }
            
        }
        public bool DeletePost(int id)
        {
            using(var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Posts
                    .Single(p => p.Id == id);
                context.Posts.Remove(entity);
                return context.SaveChanges() == 1;
                  
            }
        }
    }
}

