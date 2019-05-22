using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMgmtSys.ICache
{
    /// <summary>
    /// 该接口中的方法和ICache中功能完全相同，该类中提供异步接口,更多细节请看<see cref="ICache"/>
    /// </summary>
    public interface ICacheAsync
    {
        Task<bool> SetAsync<T>(string key, T value, TimeSpan expiresIn);
        
        Task<bool> RemoveAsync(string key);
        
        Task<T> GetAsync<T>(string key);
        
        Task<bool> ExpireInAsync(string key, TimeSpan expireIn);
    }
}
