using Labb_3_API.DTO;
using Labb_3_API.Models;

namespace Labb_3_API.Mapping;

public static class PersonMapper
{
    public static PersonRespond MapToDTO(this Person person)
    {
        return new PersonRespond
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            PhoneNumber = person.PhoneNumber,
            BirthDate = person.BirthDate,
        };
    }
}
