using Graveyard.Models;
using Graveyard_Backend.Interfaces;

namespace Graveyard_Backend.Repositories
{
    public class CartRepository : CRUDRepository<Cart>,ICartRepository
    {
        private contextModel _contextModel;
        public CartRepository(contextModel contextModel) {
        _contextModel = contextModel;
        }
    }
}
