using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.utility.containers;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependencyFactoryRegistry))]
  public class DependencyFactoryRegistrySpecs
  {
    public abstract class concern : Observes<IFindDependencyFactories,
                                      DependencyFactoryRegistry>
    {
    }

    public class when_finding_a_dependency_factory_to_resolve_a_dependency : concern
    {
      Establish c = () =>
      {
      };

      Because b = () =>
        result = sut.get_the_factory_that_can_create(typeof(ICreateOneDependency));

      static ICreateOneDependency result;

      public class and_it_has_the_dependency
      {
        Establish c = () =>
        {
          the_dependency_factory = fake.an<ICreateOneDependency>();
          all_the_dependency_factories = Enumerable.Range(1, 10).Select(x => fake.an<ICreateOneDependency>()).ToList();
          all_the_dependency_factories.Add(the_dependency_factory);

          the_dependency_factory.setup(x => x.can_create(typeof(ICreateOneDependency))).Return(true);
          depends.on<IEnumerable<ICreateOneDependency>>(all_the_dependency_factories);
        };

        It should_return_the_factory_that_can_create_the_dependency = () =>
          result.ShouldEqual(the_dependency_factory);


        static ICreateOneDependency the_dependency_factory;
        static List<ICreateOneDependency> all_the_dependency_factories;
      }

     public class and_it_does_not_have_the_dependency
     {
         Establish c = () =>
         {
             the_null_object = fake.an<ICreateOneDependency>();
             all_the_dependency_factories = Enumerable.Range(1, 10).Select(x => fake.an<ICreateOneDependency>()).ToList();
             depends.on<IEnumerable<ICreateOneDependency>>(all_the_dependency_factories);
             depends.on<ICreateTheFactoryWhenDependencyFactoryIsNotFound>(() => the_null_object);
         };

         It should_return_the_null_object_factory = () =>
             result.ShouldEqual(the_null_object);
         static ICreateOneDependency the_null_object;
         static List<ICreateOneDependency> all_the_dependency_factories;
     }
    }
  }
    
}