﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tirelire.Models;

namespace Tirelire.Data.Data.Repository
{
    public interface ITirelireRepository : IRepository<Produit>
    {
        void Update(Produit obj);
    }
}
