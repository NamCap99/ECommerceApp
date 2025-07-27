using AutoMapper;
using E_Commerce.Application.DTOs.OrderDTO;
using E_Commerce.Application.Interfaces;
using E_Commerce.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Controllers
{
    public class OrdersController : ControllerBase
    {
        private readonly ECommerceDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(ECommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponseDto>> GetAllAsync()
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .ToListAsync();

            return _mapper.Map<List<OrderResponseDto>>(order);
        }
    }
}
