using System;

namespace LibMgmtSys.TypeContainer
{
    /// <summary>
    /// 注册时类型没找到
    /// </summary>
    internal class RegisterTypeNotFoundException : Exception
    {
        public RegisterTypeNotFoundException(string message) : base(message)
        {

        }
    }
}
