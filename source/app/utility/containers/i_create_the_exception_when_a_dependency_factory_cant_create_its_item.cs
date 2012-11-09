using System;

namespace app.utility.containers
{
  public delegate Exception ICreateTheExceptionWhenAnDependencyFactoryCantCreateItsItem(Type type_that_could_not_be_created,Exception inner);
}