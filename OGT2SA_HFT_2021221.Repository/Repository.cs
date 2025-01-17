﻿using Microsoft.EntityFrameworkCore;
using OGT2SA_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected AnimeDataDbContext context;
        public Repository(AnimeDataDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        public abstract T GetOne(int id);
    }
}
