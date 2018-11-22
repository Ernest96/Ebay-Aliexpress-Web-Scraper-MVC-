using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser
{
    public class AliParser : Parser
    {
        public AliParser() { }
        public AliParser(string html) : base(html) { }

        public override Item GetItem()
        {
            document.LoadHtml(_html);
            ParseName();
            ParseAuthor();
            ParseCategory();
            ParseDescription();
            ParseImage();
            ParsePrice();
            SetSite("aliexpress.com");

            Item temp = _item;
            _item = new Item();
            document = new HtmlDocument();

            return temp;
        }

        protected override void ParseAuthor()
        {
            _item.author_name = document.DocumentNode.
                SelectSingleNode("//a[@class='store-lnk']")?.InnerHtml;
        }

        protected override void ParseCategory()
        {
            var a = document.DocumentNode.
                SelectSingleNode("//div[@class='ui-breadcrumb']//div//a[3]");

            _item.category = a?.InnerHtml;
        }

        protected override void ParseDescription()
        {
            var a = document.DocumentNode.
                SelectSingleNode("//div[@class='description-content']")?.InnerHtml;

        }

        protected override void ParseImage()
        {
            var a = document.DocumentNode.
                SelectSingleNode("//meta[@property='og:image']");
            var b = a.GetAttributeValue("content", "");

            _item.image_url = b;
        }

        protected override void ParseName()
        {
            _item.name = document.DocumentNode.
                SelectSingleNode("//h1[@class='product-name']")?.InnerHtml;
        }

        protected override void ParsePrice()
        {
            _item.price = document.DocumentNode.
                SelectSingleNode("//span[@id='j-sku-discount-price']")?.InnerHtml;
        }

    }
}