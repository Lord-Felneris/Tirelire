
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tirelire.Data.Data;
using Tirelire.Data.Data.Repository;
using Tirelire.Models;

namespace Tirelire.Data.Data.Repository
{
    public class TirelireRepository : Repository<Produit>, ITirelireRepository
    {
        private readonly ApplicationDbContext _db;
        public TirelireRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Produit obj)
        {
            _db.Tirelires.Update(obj);  
        }
    }
}
