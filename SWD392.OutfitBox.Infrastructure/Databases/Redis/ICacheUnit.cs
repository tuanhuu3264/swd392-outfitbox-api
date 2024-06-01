using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SWD392.OutfitBox.Infrastructure.Databases.Redis
{
    public interface ICacheUnit<T> where T : class
    {   
        Task<bool> SetObject(T obj, object id);
        Task<T> Get(Type type, object id);
        Task<List<T>> GetAll();
        Task<bool> Delete(string key);
    }
}
