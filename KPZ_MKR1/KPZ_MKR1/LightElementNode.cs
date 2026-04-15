using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{
    using System.Collections.Generic;
    using System.Text;
    using static KPZ_MKR1.Enum;

    public class LightElementNode : LightNode
    {
        public string TagName { get; set; }
        public DisplayType DisplayType { get; set; }
        public ClosureType ClosureType { get; set; }
        public List<string> CssClasses { get; set; }

        private List<LightNode> _children = new List<LightNode>();

        public LightElementNode(string tagName, DisplayType displayType, ClosureType closureType, List<string> cssClasses = null)
        {
            TagName = tagName;
            DisplayType = displayType;
            ClosureType = closureType;
            CssClasses = cssClasses ?? new List<string>();
        }

        public void AddChild(LightNode node)
        {
            _children.Add(node);
        }

        public void RemoveChild(LightNode node)
        {
            _children.Remove(node);
        }

        public int ChildrenCount => _children.Count;

        public override string InnerHTML
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var child in _children)
                {
                    sb.Append(child.OuterHTML);
                }
                return sb.ToString();
            }
        }

        public override string OuterHTML
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"<{TagName}");

                if (CssClasses.Count > 0)
                {
                    sb.Append($" class=\"{string.Join(" ", CssClasses)}\"");
                }

                if (ClosureType == ClosureType.Single)
                {
                    sb.Append(" />");
                }
                else
                {
                    sb.Append(">");
                    sb.Append(InnerHTML);
                    sb.Append($"</{TagName}>");
                }

                return sb.ToString();
            }
        }
    }
}
