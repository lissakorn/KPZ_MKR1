using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{

    public class LightTextNode : LightNode
    {
        private string _text;

        public LightTextNode(string text)
        {
            _text = text;
        }

        protected override string BuildHTML()
        {
            return _text;
        }

        public override string InnerHTML => _text;

        public override void OnTextRendered()
        {
            Console.WriteLine($"[Hook] Текст успішно відрендерено: \"{_text}\"");
        }
    }
}
