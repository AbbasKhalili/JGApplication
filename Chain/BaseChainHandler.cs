namespace JG.Application.Chain
{
    public abstract class BaseChainHandler<TIn, TOut> : IHandler<TIn, TOut>
    {
        private IHandler<TIn, TOut> _nextHandler;
        public abstract void Handle(TIn request, TOut response);

        public void SetNext(IHandler<TIn, TOut> handler)
        {
            this._nextHandler = handler;
        }

        protected void CallNext(TIn request, TOut response)
        {
            _nextHandler?.Handle(request, response);
        }
    }
}