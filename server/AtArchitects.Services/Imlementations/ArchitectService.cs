using AtArchitects.DataAccess.Repositories.Interfaces;
using AtArchitects.DTOs.ArchitectDTOs;
using AtArchitects.Services.Interfaces;
using AtArchitects.Mappers;

namespace AtArchitects.Services.Imlementations
{
    public class ArchitectService : IArchitectService
    {
        private readonly IArchitectRepository _architectRepository;
        public ArchitectService(IArchitectRepository architectRepository)
        {
            _architectRepository = architectRepository;
        }

        public async Task<ArchitectDetailsDto> AddArchitectAsync(ArchitectCreateDto architectCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArchitectAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArchitectDetailsDto>> GetAllArchitectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArchitectDetailsDto> GetArchitectByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateArchitectAsync(int id, ArchitectUpdateDto architectUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
