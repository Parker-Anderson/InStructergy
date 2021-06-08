using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SchoolBoard.Data;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return _context.Posts
                .Include(p => p.Instructor)
                .Include(p => p.Replies)
                    .ThenInclude(r => r.Instructor)
                .Include(p => p.Student);
        }
        //TODO Implement a filtered GetRecent() to display to Instructors/Student roles with only relevant recent posts.
        public IEnumerable<Post> GetRecent(string id, int n)
        {
            return
                _context.Posts
                .Include(p => p.Instructor)
                .Include(p => p.Student)
                .Include(p => p.Replies)
                    .ThenInclude(r => r.Instructor)
                .OrderByDescending(p => p.Created)
                .Take(n);
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
                    .ThenInclude(reply => reply.Instructor)
                .Include(post => post.Student)
                .First();
        }

        public IEnumerable<Post> GetByStudent(int id)
        {
            return
                _context.Students
                .Include(s => s.Posts)
                    .ThenInclude(p => p.Replies)
                    .ThenInclude(p => p.Instructor)
                .Where(s => s.Id == id)
                     .First().Posts;
        }

        public IEnumerable<Post> GetSearchedPosts(string searchQuery)
        {
           // var lowerCaseSearchQuery = searchQuery.ToLower();
            return GetAll()
                .Where(p =>
               p.Title.Contains(searchQuery)
            || p.Body.Contains(searchQuery)
            || p.Student.Name.Contains(searchQuery)
            || p.Instructor.Name.Contains(searchQuery));
        }
    }

}
