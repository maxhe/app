using System;

namespace app.utility.containers
{
  public class BasicDependencyFactory : ICreateADependencyInstance
  {
    Func<object> factory;

    public BasicDependencyFactory(Func<object> factory)
    {
      this.factory = factory;
    }

    public object create()
    {
      return factory();
    }
  }
}