using System;

namespace app.utility
{
  public class SyntaxSugar
  {
    public static IBuildExecutionChainsFor<T> to_run<T>(Func<T> behaviour)
    {
      return new ChainInvocationBuilder<T>(behaviour);
    }
  }
}