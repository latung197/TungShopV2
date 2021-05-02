using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TungShop.Model.Model;
using TungShop.Data.Repositorys;
using TungShop.Data.Infastructure;

namespace TungShop.Service
{
    public interface IPostService
    {
        Post Add(Post post);
        void Update(Post post);
        Post Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPagin(int page, int pageSize, int totalRow);
        IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);
        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        Post GetById(int id);
        void SaveChanges();

    }
    public class PostService : IPostService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfwork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfwork;
        }
        public Post Add(Post post)
        {
           return _postRepository.Add(post);
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.CategoryID == categoryId, out totalRow, page, pageSize, new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<Post> GetAllPagin(int page, int pageSize, int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
