using System;
using Labb_3_API.DTO;
using Labb_3_API.Models;

namespace Labb_3_API.Mapping;

public static class LinkMapper
{
    public static LinkRespond MapToDTO(this Link link)
    {
        return new LinkRespond
        {
            Id = link.Id,
            Title = link.Title,
            Url = link.Url
        };
    }
}
