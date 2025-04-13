using VseVeshi.ru.Data;

namespace VseVeshi.ru.Models
{
    public class CatalogService : ICatalogService
    {
        public ApplicationDbContext _context;

        public CatalogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Catalog> GetAll() { 
            return _context.Catalog.ToList();
        }
    }
}
