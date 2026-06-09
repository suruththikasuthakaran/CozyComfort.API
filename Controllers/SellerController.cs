using CozyComfort.API.Interfaces;
using CozyComfort.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozyComfort.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetAllSellers()
        {
            return Ok(await _sellerService.GetAllSellersAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Seller>> CreateSeller(Seller seller)
        {
            var created = await _sellerService.AddSellerAsync(seller);
            return Ok(created);
        }

        public class OrderRequest
        {
            public int SellerId { get; set; }
            public int DistributorId { get; set; }
            public int BlanketId { get; set; }
            public int Quantity { get; set; }
        }

        [HttpPost("order")]
        public async Task<ActionResult<Order>> PlaceOrder(OrderRequest request)
        {
            var order = await _sellerService.PlaceOrderAsync(
                request.SellerId, request.DistributorId, request.BlanketId, request.Quantity);
            return Ok(order);
        }

        [HttpGet("{id}/orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int id)
        {
            return Ok(await _sellerService.GetOrdersForSellerAsync(id));
        }
    }
}
