
namespace HtmlAgilityPack.Extensions
{
    static class HtmlDocumentExtensionGetElementByClassName
    {
        public static List<HtmlNode> GetElementsByClassName(this HtmlDocument document, string className)
        {
            List<HtmlNode> elements = new List<HtmlNode>();

            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes($"//*[contains(@class, '{className}')]");

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    elements.Add(node);
                }
            }

            return elements;
        }
    }
}
