using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notion.Client.Extensions
{
    public static class TitleRelatedExtensions
    {
        public static KeyValuePair<string, PropertyValue> GetTitleProperty(this Page page)
        {
            return page.Properties.First(x =>
                x.Value.Type == PropertyValueType.Title);
        }

        /// <summary>
        /// Appends all PlaintText of TitlePropertyValue sub elements
        /// </summary>
        public static string GetAllPlainText(this TitlePropertyValue titlePropertyValue)
        {
            // to save some efficiency with most common case
            if (titlePropertyValue.Title.Count == 1)
                return titlePropertyValue.Title[0].PlainText;

            // in other case append all title sub elements into one string
            var str = new StringBuilder();
            foreach (var richTextBase in titlePropertyValue.Title)
                str.Append(richTextBase.PlainText);

            return str.ToString();
        }
    }
}