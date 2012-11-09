using System;

namespace app.utility.containers
{
  public interface ICreateOneDependency
  {
    object create();
    bool can_create(Type dependency);
  }
}