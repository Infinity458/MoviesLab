﻿using Domain.Enities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        protected MovieContext Context { get; }
        private readonly DbSet<T> table;

        public Repository(MovieContext context)
        {
            Context = context;
            table = context.Set<T>();
        }

        public async Task CreateAsync(T item)
        {
            await table.AddAsync(item);
            await Context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                await table.AddAsync(item);
            }
            await Context.SaveChangesAsync();
        }

        public async Task<T> DeleteItemAsync(int id)
        {
            var item = await table.FirstOrDefaultAsync(e => e.Id == id);
            table.Remove(item);
            await Context.SaveChangesAsync();
            return item;
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }
        public virtual async Task<ICollection<T>> GetByFilterAsync(Expression<Func<T, bool>> expression)
        {
            return await table.Where(expression).ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await table.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateItemAsync(T item)
        {
            table.Update(item);
            await Context.SaveChangesAsync();
        }

        public async Task Clear()
        {
            ICollection<T> items = await GetAllAsync();
            foreach (T item in items)
            {
                table.Remove(item);
            }
            await Context.SaveChangesAsync();
        }
    }
}
