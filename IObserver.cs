using System.Threading.Tasks;

namespace JG.Application
{
    public interface IObserver<in T>
    {
        Task Notify(T data);
    }
}