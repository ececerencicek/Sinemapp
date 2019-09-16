using Sinemapp.Data;
using Sinemapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinemapp.Service
{
    public class TvSerieService : ITvSerieService
    {
        private readonly IRepository<TvSerie> tvSerieRepository;
        private readonly IUnitOfWork unitOfWork;
        public TvSerieService(IRepository<TvSerie> tvSerieRepository, IUnitOfWork unitOfWork)
        {
            this.tvSerieRepository = tvSerieRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return tvSerieRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var tvSerie = tvSerieRepository.Get(id);
            if (tvSerie != null)
            {
                tvSerieRepository.Delete(tvSerie);
                unitOfWork.SaveChanges();
            }
        }

        public TvSerie Get(Guid id)
        {
            return tvSerieRepository.Get(id);
        }

        public IEnumerable<TvSerie> GetAll()
        {
            return tvSerieRepository.GetAll();
        }

        public void Insert(TvSerie tvSerie)
        {
            tvSerieRepository.Insert(tvSerie);
            unitOfWork.SaveChanges();
        }

        public void Update(TvSerie tvSerie)
        {
            tvSerieRepository.Update(tvSerie);
            unitOfWork.SaveChanges();
        }
    }
    public interface ITvSerieService
    {
        IEnumerable<TvSerie> GetAll();
        TvSerie Get(Guid id);
        void Insert(TvSerie tvSerie);
        void Update(TvSerie tvSerie);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}
