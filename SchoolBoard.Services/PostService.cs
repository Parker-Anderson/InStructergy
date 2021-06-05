using Microsoft.EntityFrameworkCore;
using SchoolBoard.Data;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Services
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(int id, string body)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetByAuthor(string id)
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(p => p.Id == id)
                .Include(post => post.Instructor)
                .Include(post => post.Replies)
                    .ThenInclude(reply=>reply.Instructor)
                .Include(post => post.Student)
                .First();
        }

        public IEnumerable<Post> GetByStudent(int id)
        {
            return _context.Students
                .Where(s => s.Id == id)
                     .First().Posts;
        }
    }
}
