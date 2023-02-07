using System.Runtime.CompilerServices;

namespace CLG.OperationAPI.Application.Repositories
{
    public interface IRepository<T>
    {
        Task AddOperation(T request);
        //Task<double> GetTotal();
        Task<List<T>> GetDailyReport(DateTime date);
    }
}
