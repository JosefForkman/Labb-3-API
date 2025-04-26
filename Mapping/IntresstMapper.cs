using Labb_3_API.DTO;
using Labb_3_API.Models;

namespace Labb_3_API.Mapping;

public static class IntresstMapper
{
    public static IntrestRespond MapToDTO(this Intrest intresst)
    {
        return new IntrestRespond
        {
            Id = intresst.Id,
            Title = intresst.Title,
            Description = intresst.Description
        };
    }
}
