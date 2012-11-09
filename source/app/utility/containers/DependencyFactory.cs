using System;

namespace app.utility.containers
{
  public class DependencyFactory:ICreateOneDependency
  {
    public object create()
    {
      throw new NotImplementedException();
    }

    public bool can_create(Type type)
    {
      throw new NotImplementedException();
    }
  }
}