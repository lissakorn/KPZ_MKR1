using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{
    public class NodeCountVisitor : IVisitor
    {
        public int ElementCount { get; private set; } = 0;
        public int TextCount { get; private set; } = 0;

        public void VisitElementNode(LightElementNode node)
        {
            ElementCount++;
        }

        public void VisitTextNode(LightTextNode node)
        {
            TextCount++;
        }
    }
}
