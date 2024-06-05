using AtArchitects.DataAccess.Repositories.Interfaces;
using AtArchitects.DTOs.ArchitectDTOs;
using AtArchitects.Mappers;
using AtArchitects.Services.Interfaces;
using AtArchitects.Shared.Exceptions;
using Microsoft.Extensions.Logging;

namespace AtArchitects.Services.Imlementations
{
    public class ArchitectService : IArchitectService
    {
        private readonly IArchitectRepository _architectRepository;
        private readonly ILogger<ArchitectService> _logger;
        public ArchitectService(IArchitectRepository architectRepository, ILogger<ArchitectService> logger)
        {
            _architectRepository = architectRepository;
            _logger = logger;
        }

        public async Task<ArchitectDetailsDto> AddArchitectAsync(ArchitectCreateDto architectCreateDto)
        {
            _logger.LogInformation("Mapping ArchitectCreateDto to Architect model");
            var newArchitect = ArchitectMappers.MapToArchitectModel(architectCreateDto);
            await _architectRepository.AddAsync(newArchitect);
            return ArchitectMappers.MapToArchitectDetailsDto(newArchitect);
        }

        public async Task DeleteArchitectAsync(int id)
        {
            var existingArchitect = await _architectRepository.GetByIdAsync(id);

            if (existingArchitect != null)
            {
               await _architectRepository.DeleteByIdAsync(id);
            }
            else
            {
                throw new ArchitectNotFoundException(id);
            }
        }

        public async Task<List<ArchitectDetailsDto>> GetAllArchitectsAsync()
        {
            var architects = await _architectRepository.GetAllAsync();

            return architects != null
                ? architects.Select(ArchitectMappers.MapToArchitectDetailsDto).ToList()
                : [];
        }

        public async Task<ArchitectDetailsDto> GetArchitectByIdAsync(int id)
        {
            var architect =await _architectRepository.GetByIdAsync(id);

            return architect != null
                ? ArchitectMappers.MapToArchitectDetailsDto(architect)
                : throw new ArchitectNotFoundException(id);
        }

        public async Task UpdateArchitectAsync(int id, ArchitectUpdateDto architectUpdateDto)
        {
            var existingArchitect = await _architectRepository.GetByIdAsync(id) ?? throw new ArchitectNotFoundException(id);

            ArchitectMappers.ApplyUpdateFromDto(architectUpdateDto, existingArchitect);
            await _architectRepository.UpdateAsync(existingArchitect);
        }
    }
}
