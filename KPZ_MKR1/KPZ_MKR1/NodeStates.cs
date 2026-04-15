using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{
   
    public class NormalState : INodeState
    {
        public string Render(LightNode node) => node.Render();
    }

    public class HiddenState : INodeState
    {
        public string Render(LightNode node) => "";
    }
}