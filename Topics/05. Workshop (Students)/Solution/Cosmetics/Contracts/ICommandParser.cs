using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Contracts
{
    internal interface ICommandParser
    {
        IList<ICommand> ReadCommands();
    }
}
