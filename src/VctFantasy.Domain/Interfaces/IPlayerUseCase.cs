using VctFantasy.Domain.Dtos.Request;
using VctFantasy.Domain.Dtos.Response;

namespace VctFantasy.Domain.Interfaces
{
    public interface IPlayerUseCase
    {
        string Register(List<PlayerDto> dto);
        List<PlayerDtoResponse> GetAll();
        PlayerDtoResponse GetById(int id);
        string Update(int id, PlayerDto dto);
    }
}
