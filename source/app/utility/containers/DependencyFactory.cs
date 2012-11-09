using System;

namespace app.utility.containers
{
  public class DependencyFactory : ICreateOneDependency
  {
    ICreateADependencyInstance real_factory;
    IDetermineIfATypeCanBeCreated creation_spec;

    public DependencyFactory(ICreateADependencyInstance real_factory, IDetermineIfATypeCanBeCreated creation_spec)
    {
      this.real_factory = real_factory;
      this.creation_spec = creation_spec;
    }

    public object create()
    {
      return real_factory.create();
    }

    public bool can_create(Type dependency)
    {
      return creation_spec(dependency);
    }
  }
}