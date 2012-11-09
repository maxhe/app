using System;
using System.Collections.Generic;
using app.utility.containers;
using app.web.core;

namespace app.tasks.startup
{
  public class Startup
  {
    static IFetchDependencies container;
    static IList<ICreateOneDependency> factories;

    public static void run()
    {
      factories = new List<ICreateOneDependency>();
      container = new BasicContainer(new DependencyFactoryRegistry(factories,
                                                                   StartupItems.errors.no_factory_for_type_registered),
                                     StartupItems.errors.dependency_creation_error);
      Container.facade_resolution = () => container;

      register_dependencies();
    }

    static void register_dependencies()
    {
      throw new NotImplementedException();
    }
  }

  public class Dependency
  {
    public static IDetermineIfATypeCanBeCreated is_a<TType>()
    {
      return new TypeIsAssignableFrom(typeof(TType)).matches;
    } 
  }

  class TypeIsAssignableFrom
  {
    Type type;

    public TypeIsAssignableFrom(Type type)
    {
      this.type = type;
    }

    public bool matches(Type dependency)
    {
      return type.IsAssignableFrom(dependency);
    }
  }

  public class StartupItems
  {
    public class errors
    {
      public static ICreateTheFactoryWhenDependencyFactoryIsNotFound no_factory_for_type_registered = type =>
      {
        throw new NotImplementedException(string.Format("There is no factory registered that can create the type {0}",
                                                        type.Name));
      };

      public static ICreateTheExceptionWhenAnDependencyFactoryCantCreateItsItem dependency_creation_error =
        (type, inner) =>
        {
          throw new NotImplementedException(
            string.Format("There was an error trying to create the item of type {0}", type.Name), inner);
        };
    }
  }
}