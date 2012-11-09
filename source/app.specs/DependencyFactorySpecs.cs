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

   
    public class when_observation_name : concern
    {
        
      It first_observation = () =>        
        
    }
  }
}
