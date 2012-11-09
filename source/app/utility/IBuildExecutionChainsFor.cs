using System;

namespace app.utility
{
  public interface IBuildExecutionChainsFor<T>
  {
    IBuildExecutionChainsFor<T> on_error(Func<Exception, Exception> custom_exception_factory);
    T run();
  }

  public class ChainInvocationBuilder<T> : IBuildExecutionChainsFor<T>
  {
    Func<T> target;

    public ChainInvocationBuilder(Func<T> target)
    {
      this.target = target;
    }

    public IBuildExecutionChainsFor<T> on_error(Func<Exception, Exception> custom_exception_factory)
    {
      return new ChainInvocationBuilder<T>(() =>
      {
        try
        {
          return target();
        }
        catch (Exception e)
        {
          throw custom_exception_factory(e);
        }
      });
    }

    public T run()
    {
      return target();
    }
  }
}