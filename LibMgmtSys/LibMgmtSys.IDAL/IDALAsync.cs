namespace LibMgmtSys.IDAL
{
    public interface IDALAsync<T> : IDataReaderAsync<T>, IDataWriterAsync<T>, IDataChanged<T> where T : class
    {
    }
}
