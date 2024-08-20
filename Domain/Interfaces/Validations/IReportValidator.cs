using DiaryPetProject.Domain.Entity;
using DiaryPetProject.Domain.Result;

namespace DiaryPetProject.Domain.Interfaces.Validations;

public interface IReportValidator : IBaseValidator<Report>
{
    /// <summary>
    /// The presence of a report in the database is checked; if it exists, a new one cannot be created
    /// The user is checked, if the user is not found in the UserId, then there is no such user
    /// </summary>
    /// <param name="report"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    BaseResult CreateValidator(Report report, User user);
}
