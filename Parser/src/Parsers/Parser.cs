using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser
{
    public abstract class Parser
    {
        protected Item _item = new Item();
        protected string _html;
        protected HtmlDocument document = new HtmlDocument();

        public Parser() { }
        public Parser(string html)
        {
            _html = html;
        }

        public abstract Item GetItem();
        protected abstract void ParseName();
        protected abstract void ParsePrice();
        protected abstract void ParseCategory();
        protected abstract void ParseDescription();
        protected abstract void ParseAuthor();
        protected abstract void ParseImage();

        protected  void SetSite(string site)
        {
            _item.site = site;
        }

        public void SetHtml(string html)
        {
            _html = html;
        }
    }
}