using E_Commerce.Application.DTOs.OrderDTO;

namespace E_Commerce.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetAllAsync(); // return all orders
        Task<OrderResponseDto?> GetByIdAsync(int id); // return a specific order
        Task<int> CreateAsync(OrderCreateDto dto);
        Task<bool> UpdateAsync(int id,  OrderUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
