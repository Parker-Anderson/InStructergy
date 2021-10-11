using SchoolBoard.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolBoard.Interfaces
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetSearchedPosts(string searchQuery);
        IEnumerable<Post> GetRecent(string id, int n);
        IEnumerable<Post> GetByAuthor(string id);
        IEnumerable<Post> GetByStudent(int id);

        Task Add(Post post);
        Task Delete(int id);
        Task Edit(int id, string body);
        Task AddReply(PostReply reply);
        Task DeleteReply(PostReply reply);
    }
}
