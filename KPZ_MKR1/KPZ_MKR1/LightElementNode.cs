using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{

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
            node.OnInserted(); 
        }

        public void RemoveChild(LightNode node)
        {
            _children.Remove(node);
            node.OnRemoved();
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

        protected override string BuildHTML()
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

        public override void OnCreated()
        {
            Console.WriteLine($"[Hook] Життєвий цикл: Елемент <{TagName}> почав рендеринг.");
        }

        public override void OnClassListApplied()
        {
            if (CssClasses.Count > 0)
            {
                Console.WriteLine($"[Hook] Життєвий цикл: До <{TagName}> застосовано класи ({string.Join(", ", CssClasses)}).");
            }
        }

        public override void OnInserted()
        {
            Console.WriteLine($"[Hook] Життєвий цикл: Елемент <{TagName}> було вставлено в дерево.");
        }


        public IEnumerable<LightNode> GetDepthFirstIterator()
        {
            yield return this;
            foreach (var child in _children)
            {
                if (child is LightElementNode elementNode)
                {
                    foreach (var node in elementNode.GetDepthFirstIterator()) yield return node;
                }
                else yield return child;
            }
        }

        public IEnumerable<LightNode> GetBreadthFirstIterator()
        {
            Queue<LightNode> queue = new Queue<LightNode>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current;

                if (current is LightElementNode elementNode)
                {
                    foreach (var child in elementNode._children) queue.Enqueue(child);
                }
            }
        }
    }
}
