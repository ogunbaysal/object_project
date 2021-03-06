﻿using Microsoft.EntityFrameworkCore;
using server.Helpers;
using server.Models.Product;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories.Products
{
    public class ProductImageRepository : BaseRepository, Interface.IRepository<ProductImage>
    {
        private readonly SieveProcessor _sieveProcessor;
        public ProductImageRepository(ModelContext context, SieveProcessor processor) : base(context)
        {
            this._sieveProcessor = processor;
        }
        public async Task AddAsync(ProductImage item)
        {
            await _context.ProductImages.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductImage> FindByIdAsync(long id)
        {
            var item = await _context
                .ProductImages
                .AsNoTracking()
                .FirstAsync(x => x.ImageId == id);
            return item;
        }

        public async Task<IEnumerable<ProductImage>> ListAsync(SieveModel query)
        {
            IQueryable<ProductImage> result = _context
                .ProductImages
                .AsNoTracking();
            result = _sieveProcessor.Apply(query, result);
            return await result.ToListAsync();
        }
        public async Task<IEnumerable<ProductImage>> ListAsync(System.Linq.Expressions.Expression<Func<ProductImage, bool>> query)
        {
            var items = _context.ProductImages.Where(query).AsNoTracking();
            return await items.ToListAsync();
        }

        public void Remove(ProductImage item)
        {
            _context.ProductImages.Remove(item);
            _context.SaveChanges();
        }

        public void Update(ProductImage item)
        {
            _context.ProductImages.Update(item);
            _context.SaveChanges();
        }
    }
}
