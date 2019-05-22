using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMgmtSys.ICache
{
    public interface ICache : IDisposable
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value, TimeSpan expiresIn);

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Remove(string key);
        
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);
        
        /// <summary>
        /// 使缓存过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expireIn"></param>
        /// <returns></returns>
        bool ExpireIn(string key, TimeSpan expireIn);
    }
}
