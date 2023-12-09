using Core.Entities;
using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task AddToCart(Cart cart)
        {
            await CreateAsync(cart);
            await SaveAsync();
        }

        public IEnumerable<Cart> GetAll()
        {
            return FindAll();
        }

        public Cart GetCart()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Cart> GetCartListByUID(string uid)
        {
            return FindByConditionQuery(x => x.ApplicationUser.Id == uid)
                .AsQueryable();
        }

        public async Task RemoveFromCart(Cart cart)
        {
            Delete(cart);
            await SaveAsync();
        }
    }
}