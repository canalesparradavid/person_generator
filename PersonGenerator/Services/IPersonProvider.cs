using PersonGenerator.Models;

namespace PersonGenerator.Services
{
    public interface IPersonProvider
    {
        Person Get();
        ICollection<Person> Get(int quantity);
    }
}
