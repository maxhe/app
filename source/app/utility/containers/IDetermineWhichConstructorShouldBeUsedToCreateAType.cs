using System;
using System.Reflection;

namespace app.utility.containers
{
  public interface IDetermineWhichConstructorShouldBeUsedToCreateAType
  {
    ConstructorInfo get_the_ctor_to_create_the(Type type);
  }
}