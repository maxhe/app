using System;

namespace app.utility
{
  public class Conventions
  {
    public static Func<Exception, Exception> standard_error_handling = e =>
    {
      throw new NotImplementedException("You had an unhandled error, your kung fu is weak");
    };
  }
}