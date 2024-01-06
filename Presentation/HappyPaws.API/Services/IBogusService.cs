
using Bogus;
using System.Linq.Expressions;

namespace HappyPaws.API.Services
{
    public interface IBogusService<T>
    {
        IBogusService<T> RuleFor<TProperty>(Expression<Func<T, TProperty>> property, Func<Faker, TProperty> valueFunction);
        T Generate(params Func<Faker, object>[] staticValues);
    }
}
