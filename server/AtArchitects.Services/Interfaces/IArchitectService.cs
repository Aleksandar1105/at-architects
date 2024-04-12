namespace AtArchitects.Services.Interfaces
{
    using AtArchitects.DTOs.ArchitectDTOs;

    public interface IArchitectService
    {
        Task<List<ArchitectDetailsDto>> GetAllArchitectsAsync();
        Task<ArchitectDetailsDto> GetArchitectByIdAsync(int id);
        Task<ArchitectDetailsDto> AddArchitectAsync(ArchitectCreateDto architectCreateDto);
        Task UpdateArchitectAsync(int id, ArchitectUpdateDto architectUpdateDto);
        Task DeleteArchitectAsync(int id);
    }
}
