using DiaryPetProject.Domain.Result;

namespace DiaryPetProject.Domain.Interfaces.Validations;

public interface IBaseValidator<T> where T : class
{
    BaseResult ValidateOnNull(T model);
}
