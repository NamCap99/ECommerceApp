using AutoMapper;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ECommerceDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ECommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();

            return _mapper.Map<List<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<bool> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var products = await _context.Products.FindAsync(id);
            if (products is null) return false;
            _mapper.Map(products, dto);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<int> CreateAsync(ProductCreateDto dto)
        {
            var products = _mapper.Map<Product>(dto);
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return products.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if(product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
