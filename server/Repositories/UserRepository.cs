﻿using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.User;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories
{
    public class UserRepository : BaseRepository, Interface.IRepository<User>
    {
        private readonly SieveProcessor _sieveProcessor;
        public UserRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(User item)
        {
            await _context.Users.AddAsync(item);
        }

        public async Task<User> FindByIdAsync(long id)
        {
            var item = await _context.Users
                .AsNoTracking()
                .FirstAsync(x => x.UserId == id);
            return item;
        }

        public async Task<IEnumerable<User>> ListAsync(SieveModel query)
        {
            var items = _context.Users.AsNoTracking();
            var result = _sieveProcessor.Apply(query, items);
            return await result.ToListAsync();
        }

        public void Remove(User item)
        {
            _context.Users.Remove(item);
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
        }
    }
}
