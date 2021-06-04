using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Interfaces
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFiltered();
        IEnumerable<Post> GetByStudent(int id);

        Task Add(Post post);
        Task Delete(int id);
        Task Edit(int id, string body);
        Task AddReply(PostReply reply);
    }
}
