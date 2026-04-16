using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{
    public interface IVisitor
    {
        void VisitElementNode(LightElementNode node);
        void VisitTextNode(LightTextNode node);
    }
}