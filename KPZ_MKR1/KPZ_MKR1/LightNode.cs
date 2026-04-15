using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{
    public abstract class LightNode
    {
       public string Render()
        {
            OnCreated();
            OnStylesApplied();
            OnClassListApplied();

            string html = BuildHTML(); 
            OnTextRendered();
            return html;
        }

        public virtual void OnCreated() { }
        public virtual void OnInserted() { }
        public virtual void OnRemoved() { }
        public virtual void OnStylesApplied() { }
        public virtual void OnClassListApplied() { }
        public virtual void OnTextRendered() { }

        protected abstract string BuildHTML();

        public string OuterHTML => Render();
        public abstract string InnerHTML { get; }
    }
}
