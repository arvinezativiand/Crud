using Crud.Application.DTOs.ExternalDataDTOs;
using Crud.Domain.Entities.ExternalUser;

namespace Crud.Application.Mapper.ExternalDataDTO;

public static class ExternalDataMapper
{
    public static List<ExternalUserDTO> MapToDTO(IEnumerable<ExternalUsers> users)
    {
        List<ExternalUserDTO> userDTOs = new List<ExternalUserDTO>();
        foreach (var user in users)
        {
            userDTOs.Add(new ExternalUserDTO
            {
                City = user.City,
                Email = user.Email,
                FullName = user.Fullname,
                Id = user.Id,
                Status = user.Status
            });
        }

        return userDTOs;
    }
}
