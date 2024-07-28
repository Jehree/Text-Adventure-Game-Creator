using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureFramework.Types
{
    internal class SaveDataNode
    {
        public string Name { get; private set; }
        public string Parent { get; private set; }
        public StoryManager.NodeState State { get; private set; }

        public SaveDataNode(Node node)
        {
            Name = node.Name;
            Parent = node.Parent;
            State = StoryManager.NodeState.DISABLED;
        }
    }
}
