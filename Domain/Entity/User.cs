using DiaryPetProject.Domain.Interfaces;

namespace DiaryPetProject.Domain.Entity;

public class User : IEntityId<long>, IAuditable
{
    public long Id { get; set; }

    public required string Login { get; set; }

    public required string Password { get; set; }

    public List<Report>? Reports { get; set; }

    public DateTime CreatedAt { get; set; }

    public long CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long UpdatedBy { get; set; }
}
