 using System.Data;
 using System.Data.Common;
 using System.Data.SqlClient;
 using Machine.Specifications;
 using app.utility.containers;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(DependencyFactory))]  
  public class DependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateOneDependency,
                                      DependencyFactory>
    {
        
    }

   
    public class when_creating_a_dependency : concern
    {
        Establish c = () =>
        {
            the_dependency = new SqlConnection();
            depends.on<ICreateADependencyInstance>((type) =>
            {
                type.ShouldEqual(typeof(IDbConnection));
                return the_dependency;
            });


        };

        Because b = () =>
            result = sut.create();

        It should_return_the_dependency = () =>
            result.ShouldEqual(the_dependency);

        static DbConnection the_dependency;
        static object result;
    }
  }
}
