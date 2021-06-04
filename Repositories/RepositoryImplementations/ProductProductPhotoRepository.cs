﻿using Model;
using Model.Models;
using Repositories.RepositoryImplementations;
using Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoryImplementations
{
    public class ProductProductPhotoRepository : Repository<ProductProductPhoto>, IProductProductPhotoRepository
    {
        public ProductProductPhotoRepository(DbContext context) : base(context)
        {
        }
    }
}
