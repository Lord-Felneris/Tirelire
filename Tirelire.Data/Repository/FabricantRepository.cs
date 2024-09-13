
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tirelire.Models;

namespace Tirelire.Data.Data.Repository
{
    public class FabricantRepository : Repository<Fabricant>, IFabricantRepository
    {
        private readonly ApplicationDbContext _db;
        public FabricantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Fabricant obj)
        {
            _db.Fabricants.Update(obj);
        }
    }
}
