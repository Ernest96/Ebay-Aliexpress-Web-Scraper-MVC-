using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser
{
    public class EbayParser : Parser
    {
        public EbayParser() { }
        public EbayParser(string html) : base(html){ }

        public override Item GetItem()
        {
            document.LoadHtml(_html);
            ParseName();
            ParseAuthor();
            ParseCategory();
            ParseDescription();
            ParseImage();
            ParsePrice();
            SetSite("ebay.com");

            Item temp = _item;
            _item = new Item();
            document = new HtmlDocument();

            return temp;
        }

        protected override void ParseAuthor()
        {
            _item.author_name = document.DocumentNode.
                SelectSingleNode("//span[@class='mbg-nw']")?.InnerHtml;
        }

        protected override void ParseCategory()
        {
            _item.category = document.DocumentNode.
                SelectSingleNode("//ul[@itemtype='https://schema.org/BreadcrumbList']")?.
                SelectSingleNode("//span[@itemprop='name']")?.InnerHtml;
        }

        protected override void ParseDescription()
        {
            _item.description = document.DocumentNode.
                SelectSingleNode("//div[@id='vi-desc-maincntr']")?.InnerHtml;
            if (!String.IsNullOrEmpty(_item.description))
            {
                _item.description = _item.description.Replace('\'', '"');
                _item.description = _item.description.Replace("\n", String.Empty);
                _item.description = _item.description.Replace("\t", String.Empty);
                _item.description = _item.description.Trim();
            }
        }

        protected override void ParseImage()
        {
            _item.image_url = document.DocumentNode.
                SelectSingleNode("//img[@id='icImg']")?.
                GetAttributeValue("src", "");
        }

        protected override void ParseName()
        {
            _item.name = document.DocumentNode.
                SelectSingleNode("//h1[@id='itemTitle']")?.InnerHtml;

            if (!String.IsNullOrEmpty(_item.name))
            {
                _item.name = _item.name.Split(new string[] { "</span>" }, StringSplitOptions.None)[1];
            }
        }

        protected override void ParsePrice()
        {
            _item.price= document.DocumentNode.
                SelectSingleNode("//span[@id='prcIsum_bidPrice']")?.InnerHtml;
            if (String.IsNullOrEmpty(_item.price))
            {
                _item.price = document.DocumentNode.SelectSingleNode("//span[@id='prcIsum']")?.InnerHtml;
            }
            if (String.IsNullOrEmpty(_item.price))
            {
                _item.price = document.DocumentNode.SelectSingleNode("//span[@id='mm-saleDscPrc']")?.InnerHtml;
            }
            
        }


    }
}