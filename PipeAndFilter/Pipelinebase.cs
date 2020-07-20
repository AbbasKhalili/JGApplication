using System.Collections.Generic;

namespace JG.Application.PipeAndFilter
{
    public abstract class Pipelinebase<T>
    {
        private readonly List<IOperation<T>> _operations = new List<IOperation<T>>();

        protected Pipelinebase<T> Register(IOperation<T> operation)
        {
            _operations.Add(operation);
            return this;
        }

        public T PerformOperation(T input)
        {
            foreach (var opr in _operations)
            {
                opr.Execute(input);
                if (opr.Stop) break;
            }
            return input;
            //return _operations.Aggregate(input, (current, operation) => operation.Execute(current));
        }
    }
}