using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Repositories;

public class GravediggerRepository : CRUDRepository<Gravedigger>, IGravediggerRepository
{
    private readonly ContextModel _contextModel;

    public GravediggerRepository(ContextModel contextModel)
    {
        _contextModel = contextModel;
    }
}