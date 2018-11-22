using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser
{
    //FACTORY METHOD
    public class ParserFactory
    {
        public static Parser GetParserByUrl(string url)
        {
            if (url.Contains("ebay.com"))
                return new EbayParser();
            else if (url.Contains("aliexpress.com"))
                return new AliParser();

            return null;
        }
    }
}