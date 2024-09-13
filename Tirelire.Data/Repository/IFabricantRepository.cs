
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tirelire.Models;

namespace Tirelire.Data.Data.Repository
{
    public interface IFabricantRepository : IRepository<Fabricant>
    {
        void Update(Fabricant obj);
    }
}
