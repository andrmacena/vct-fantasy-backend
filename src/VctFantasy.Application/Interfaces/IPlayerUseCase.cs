using VctFantasy.Application.Dtos.Request;
using VctFantasy.Application.Dtos.Response;

namespace VctFantasy.Application.Interfaces
{
    public interface IPlayerUseCase
    {
        string Register(List<PlayerDto> dto);
        Task<BaseResponse<PlayerDtoResponse>> GetAll();
        Task<PlayerDtoResponse> GetById(int id);
        string Update(int id, PlayerDto dto);
    }
}
