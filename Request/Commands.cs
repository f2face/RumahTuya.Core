using Newtonsoft.Json;
using System.Collections.Generic;

namespace RumahTuya.Request
{
    public struct Command
    {
        [JsonProperty("code")]
        public string Key { get; }

        [JsonProperty("value")]
        public object Value { get; }

        public Command(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }

    public class Commands
    {
        [JsonProperty("commands")]
        public List<Command> CommandList { get; }

        public Commands()
        {
            CommandList = new List<Command>();
        }

        public Commands(string key, object value)
        {
            CommandList = new List<Command>();
            AddCommand(key, value);
        }

        public Commands(List<Command> commands)
        {
            CommandList = commands;
        }

        public void AddCommand(string key, object value)
        {
            CommandList.Add(new Command(key, value));
        }
    }
}
