
using Application.Contracts;

namespace Application.Interfaces
{
    public interface IPerfumeHttpClient
    {
        Task<PerfumeDto?> GetPerfumeAsync(int id);
    }
}
