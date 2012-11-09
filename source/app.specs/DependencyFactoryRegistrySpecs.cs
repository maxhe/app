 using Machine.Specifications;
 using app.utility.containers;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(DependencyFactoryRegistry))]  
  public class DependencyFactoryRegistrySpecs
  {
    public abstract class concern : Observes<IFindDependencyFactories,
                                      DependencyFactoryRegistry>
    {
        
    }

   
    public class when_ : concern
    {
        
      It first_observation = () =>        
        
    }
  }
}
