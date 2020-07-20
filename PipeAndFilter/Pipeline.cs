namespace JG.Application.PipeAndFilter
{
    public class Pipeline<T> : Pipelinebase<T> 
    {
        public void AddOperation(IOperation<T> operation)
        {
            Register(operation);
        }
    }
}