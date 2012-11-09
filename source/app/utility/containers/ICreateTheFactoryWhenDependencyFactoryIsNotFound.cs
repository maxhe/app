using System;

namespace app.utility.containers
{
    public delegate ICreateOneDependency ICreateTheFactoryWhenDependencyFactoryIsNotFound(Type type_that_has_no_factory);
}