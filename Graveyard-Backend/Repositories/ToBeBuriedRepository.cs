using Graveyard.Models;
using Graveyard_Backend.Interfaces;

namespace Graveyard_Backend.Repositories
{
    public class ToBeBuriedRepository : CRUDRepository<ToBeBurried>, IToBeBurriedRepository
    {
        private contextModel _contextModel;
        public ToBeBuriedRepository(contextModel model)
        {
            _contextModel = model;
        }
    }
}
