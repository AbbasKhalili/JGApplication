namespace JG.Application.Chain
{
    public interface IHandler<TIn, TOut>
    {
        void Handle(TIn request, TOut response);
        void SetNext(IHandler<TIn, TOut> handler);
    }
}