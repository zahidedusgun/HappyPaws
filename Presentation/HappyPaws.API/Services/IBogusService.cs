

namespace HappyPaws.API.Services
{
    public interface IBogusService<T>
    {
        List<T> GenerateFakeData(int count);
    }


}
