using LP.Common.Domain.Interfaces;
using LP.Common.Domain.ValueObjects;

namespace LP.Common.Domain.Data;

public record EntityPersistData<T>(EntityNo? No, T Data) : IPersistableEntity
    where T : class
{
    public static EntityPersistData<T> CreateForCreation(T data) =>
        new(null, data);

    public static EntityPersistData<T> CreateForUpdate(EntityNo no, T data) =>
        new(no, data);
}