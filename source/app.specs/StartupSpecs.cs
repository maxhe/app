 using Machine.Specifications;
 using app.tasks.startup;
 using app.utility.containers;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(Startup))]  
  public class StartupSpecs
  {
    public abstract class concern : Observes
    {
        
    }

   
    public class when_run : concern
    {
      Because b = () =>
        Startup.run();


      It should_have_configured_all_of_the_startup_items = () =>
      {
        Container.fetch.an<IProcessRequests>().ShouldBeAn<FrontController>();
      };
        
    }
  }
}
