using Crud.Application.DTOs;
using Crud.Domain.Entities;

namespace Crud.Application.Mapper;

public static class RPouyaFileMapper
{
    public static RPouyaFileDTO MapToDTO(RPouyaFile file)
    {
        var fileDTO = new RPouyaFileDTO()
        {
            Data = file.Data
        };
        return fileDTO;
    }

    public static RPouyaFile MapToFile(RPouyaFileDTO fileDTO)
    {
        var file = new RPouyaFile()
        {
            Data = fileDTO.Data
        };
        return file;
    }

    public static List<RPouyaFileDTO> MapToDTOs(IEnumerable<RPouyaFile> files)
    {
        List<RPouyaFileDTO> fileDTOs = [];

        foreach (var file in files)
        {
            var fileDTO = MapToDTO(file);
            fileDTOs.Append(fileDTO);
        }

        return fileDTOs;
    }
}
