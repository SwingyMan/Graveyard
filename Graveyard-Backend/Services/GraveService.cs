﻿using Graveyard.Models;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Services
{
    public class GraveService : IGraveService
    {
        public Task<Grave> AddGrave(GraveDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ToBeBurried> AddToBeBurried(ToBeBurried toBeBurried)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToBeBurried(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Grave> ExtendGrave(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Grave> GetGrave(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Grave>> GetGraveList(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ToBeBurried> GetToBeBurried(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToBeBurried>> GetToBeBurriedList(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveGrave(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Grave> UpdateGrave(int id, GraveDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ToBeBurried> UpdateToBeBurried(ToBeBurried toBeBurried)
        {
            throw new NotImplementedException();
        }
    }
}
