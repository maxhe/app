using System;
using System.Collections.Generic;
using System.Reflection;

namespace app.utility.containers
{
  public class AutomaticDependencyFactory : ICreateADependencyInstance
  {
    IFetchDependencies container;
    IDetermineWhichConstructorShouldBeUsedToCreateAType ctor_picker;
    Type dependency_type;

    public AutomaticDependencyFactory(IFetchDependencies container, IDetermineWhichConstructorShouldBeUsedToCreateAType ctor, Type dependency_type)
    {
      this.container = container;
      this.ctor_picker = ctor;
      this.dependency_type = dependency_type;
    }

    public object create()
    {
      var ctor = ctor_picker.get_the_ctor_to_create_the(dependency_type);
      var parameter_infos = ctor.GetParameters();

      var parameters = new List<object>();
      foreach (var parameter_info in parameter_infos)
      {
        parameters.Add(container.an(parameter_info.GetType()));
      }

      return ctor.Invoke(parameters.ToArray());
    }
  }
}