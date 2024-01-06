using Bogus;
using HappyPaws.Domain.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HappyPaws.API.Services
{
    public class BogusService<T> : IBogusService<T> where T : class, new()
    {
        private readonly Faker<T> faker;

        public BogusService(string locale = "en_US")
        {
            faker = new Faker<T>(locale);
        }

        public IBogusService<T> RuleFor<TProperty>(Expression<Func<T, TProperty>> property, Func<Faker, TProperty> valueFunction)
        {
            faker.RuleFor(property, valueFunction);
            return this;
        }

        public T Generate(params Func<Faker, object>[] staticValues)
        {
            var instance = faker.Generate();

            foreach (var staticValueFunc in staticValues)
            {
                //var staticValue = staticValueFunc(faker);
                //SetStaticValue(instance, staticValue);
            }

            return instance;
        }

        private void SetStaticValue(T instance, object value)
        {
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(instance);

                if (propValue == null || propValue.Equals(default(T)))
                {
                    prop.SetValue(instance, value);
                    break;
                }
            }
        }
    }
}


