using System;

namespace app.utility.containers
{
  public interface IFetchDependencies
  {
    TDependency an<TDependency>();
    object an(Type dependency);
  }
}