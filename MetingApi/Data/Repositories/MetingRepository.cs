using Microsoft.EntityFrameworkCore;
using MetingApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetingApi.Data.Repositories
{
    public class MetingRepository : IMetingRepository
    {
        private readonly MetingContext _context;
        private readonly DbSet<Meting> _metingen;

        public MetingRepository(MetingContext dbContext)
        {
            _context = dbContext;
            _metingen = dbContext.Metingen;
        }

        public IEnumerable<Meting> GetAll()
        {
            return _metingen.Include(r => r.Resultaten).ToList();
        }

        public Meting GetBy(int id)
        {
            return _metingen.Include(r => r.Resultaten).SingleOrDefault(r => r.Id == id);
        }

        public bool TryGetMeting(int id, out Meting meting)
        {
            meting = _context.Metingen.Include(t => t.Resultaten).FirstOrDefault(t => t.Id == id);
            return meting != null;
        }

        public void Add(Meting meting)
        {
            _metingen.Add(meting);
        }

        public void Update(Meting meting)
        {
            _context.Update(meting);
        }

        public void Delete(Meting meting)
        {
            _metingen.Remove(meting);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Meting> GetBy(string resultaatType = null)
        {
            var metingen = _metingen.Include(r => r.Resultaten).AsQueryable();
            if (!string.IsNullOrEmpty(resultaatType))
                metingen = metingen.Where(r => r.Resultaten.Any(i => i.Type== resultaatType));
            return metingen.OrderBy(r => r.Created).ToList();
        }
    }
}
