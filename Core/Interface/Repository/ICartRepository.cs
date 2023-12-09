using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface ICartRepository : IRepositoryBase<Cart>
    {
        Task AddToCart(Cart cart);
        Cart GetCart();
        IEnumerable<Cart> GetAll();
        IQueryable<Cart> GetCartListByUID(string uid);
        Task RemoveFromCart(Cart cart);

    }
}
