using System;
using System.Data;
using Machine.Specifications;
using app.utility.containers;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(BasicDependencyFactory))]
  public class BasicDependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateADependencyInstance,
                                      BasicDependencyFactory>
    {
    }

    public class when_creating_its_instance : concern
    {
      Establish c = () =>
      {
        connection = fake.an<IDbConnection>();
        depends.on<Func<object>>(() => connection);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_instace_created_by_its_provided_functional_factory = () =>
        result.ShouldEqual(connection);

      static object result;
      static IDbConnection connection;
    }
  }
}