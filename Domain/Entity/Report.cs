using DiaryPetProject.Domain.Interfaces;

namespace DiaryPetProject.Domain.Entity;

public class Report : IEntityId<long>, IAuditable
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public User User { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public long CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long UpdatedBy { get; set; }
}