using KPZ_MKR1;
using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var ul = new LightElementNode("ul", DisplayType.Block, ClosureType.Paired, new List<string> { "menu", "dark-theme" });

        var li1 = new LightElementNode("li", DisplayType.Block, ClosureType.Paired);
        li1.AddChild(new LightTextNode("Головна"));

        var li2 = new LightElementNode("li", DisplayType.Block, ClosureType.Paired, new List<string> { "active" });
        li2.AddChild(new LightTextNode("Про нас"));

        var img = new LightElementNode("img", DisplayType.Inline, ClosureType.Single, new List<string> { "icon" });
        li2.AddChild(img);

        ul.AddChild(li1);
        ul.AddChild(li2);

        Console.WriteLine("--- РЕЗУЛЬТАТ РОБОТИ LightHTML ---");
        Console.WriteLine(ul.OuterHTML);
        Console.WriteLine($"\nКількість дочірніх елементів у списку (ul): {ul.ChildrenCount}");


        Console.WriteLine("\n--- ТЕСТ ІТЕРАТОРА (ОБХІД У ГЛИБИНУ - DFS) ---");
        foreach (var node in ul.GetDepthFirstIterator())
        {
            if (node is LightElementNode element)
                Console.WriteLine($"Знайдено тег: <{element.TagName}>");
            else
                Console.WriteLine($"Знайдено текст: {node.OuterHTML}");
        }

        Console.WriteLine("\n--- ТЕСТ ІТЕРАТОРА (ОБХІД У ШИРИНУ - BFS) ---");
        foreach (var node in ul.GetBreadthFirstIterator()) 
        {
            if (node is LightElementNode element)
                Console.WriteLine($"Знайдено тег: <{element.TagName}>");
            else
                Console.WriteLine($"Знайдено текст: {node.OuterHTML}");
        }


        Console.WriteLine("\n--- ТЕСТ ПАТЕРНУ: STATE ---");

        var testElement = new LightElementNode("div", DisplayType.Block, ClosureType.Paired);
        testElement.AddChild(new LightTextNode("Я видимий текст"));

        Console.WriteLine("1. Стан за замовчуванням (Normal):");
        Console.WriteLine(testElement.RenderWithState());

        Console.WriteLine("\n2. Змінюємо стан на Hidden:");
        testElement.State = new HiddenState(); 
        Console.WriteLine(testElement.RenderWithState());
    }



}