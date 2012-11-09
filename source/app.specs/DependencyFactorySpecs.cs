using System.Data.Common;
using System.Data.SqlClient;
using Machine.Specifications;
using app.utility.containers;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependencyFactory))]
  public class DependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateOneDependency,
                                      DependencyFactory>
    {
    }

    public class when_determining_if_it_can_create_a_dependency : concern
    {
      Establish c = () =>
      {
        depends.on<IDetermineIfATypeCanBeCreated>(x =>
        {
          x.ShouldEqual(typeof(int));
          return true;
        });
      };

      Because b = () =>
        result = sut.can_create(typeof(int));

      It should_decide_by_using_its_specification = () =>
        result.ShouldBeTrue();

      static bool result;
    }

    public class when_creating_a_dependency : concern
    {
      Establish c = () =>
      {
        the_dependency = new SqlConnection();
        real_factory = depends.on<ICreateADependencyInstance>();
        real_factory.setup(x => x.create()).Return(the_dependency);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_dependency = () =>
        result.ShouldEqual(the_dependency);

      static DbConnection the_dependency;
      static object result;
      static ICreateADependencyInstance real_factory;
    }
  }
}