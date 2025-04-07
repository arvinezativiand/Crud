using Crud.Application.DTOs.ExternalDataDTOs;
using Crud.Domain.Entities;

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
                city = user.city,
                email = user.email,
                fullname = user.fullname,
                id = user.id,
                status = user.status
            });
        }

        return userDTOs;
    }
}
