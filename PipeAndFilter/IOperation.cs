namespace JG.Application.PipeAndFilter
{
    public interface IOperation<T>
    {
        bool Stop { get; set; }
        T Execute(T input);
        
    }
}
