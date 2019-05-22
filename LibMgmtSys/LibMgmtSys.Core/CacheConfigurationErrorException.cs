using System;

namespace LibMgmtSys.Core
{
    internal class CacheConfigurationErrorException : Exception
    {
        public CacheConfigurationErrorException(string message) : base(message)
        {

        }
    }
}
