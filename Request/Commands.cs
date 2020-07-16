using System.Collections.Generic;

namespace RumahTuya.Request
{
#pragma warning disable IDE1006 // Naming Styles
    public class Commands
    {
        public List<Command> commands { get; set; }

        public Commands(List<Command> commands)
        {
            this.commands = commands;
        }
    }
}
