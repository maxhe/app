using System;
using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;
    MissingCommandFactory_Behaviour missing_command;

    public CommandRegistry(IEnumerable<IProcessOneRequest> commands, MissingCommandFactory_Behaviour missing_command)
    {
      this.commands = commands;
      this.missing_command = missing_command;
    }

    public IProcessOneRequest get_the_command_that_can_run(IContainRequestDetails request)
    {

      var command_can_run = commands.FirstOrDefault(x => x.can_run(request)) ?? missing_command();
      return command_can_run;
    }

  }
}