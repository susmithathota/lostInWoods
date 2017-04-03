using lostInWoods.Models;
using System.Collections.Generic;
namespace lostInWoods.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}
