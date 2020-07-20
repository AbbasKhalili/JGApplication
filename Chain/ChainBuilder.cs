using System;
using System.Collections.Generic;
using System.Linq;

namespace JG.Application.Chain
{
    public class ChainBuilder<TIn, TOut>
    {
        private readonly List<IHandler<TIn, TOut>> _handlers;

        public ChainBuilder()
        {
            this._handlers = new List<IHandler<TIn, TOut>>();
        }

        public ChainBuilder<TIn, TOut> WithHandler(IHandler<TIn, TOut> handler)
        {
            this._handlers.Add(handler);
            return this;
        }

        public IHandler<TIn, TOut> Build()
        {
            if (!_handlers.Any()) throw new Exception("No handler has been added");

            _handlers.Aggregate((a, b) =>
            {
                a.SetNext(b);
                return b;
            });
            return _handlers.First();
        }
    }
}
