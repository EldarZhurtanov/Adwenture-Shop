﻿using Model;
using Model.Models;
using Repositories.RepositoryImplementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoryInterfaces
{
    public class ProductPhotoRepository : Repository<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(DbContext context) : base(context)
        {
        }
    }
}