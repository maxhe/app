using System;

namespace app.utility.containers
{
  public interface IFindDependencyFactories
  {
    ICreateOneDependency get_the_factory_that_can_create(Type dependency);
  }
}