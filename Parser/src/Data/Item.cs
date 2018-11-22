using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string category { get; set; }
        public string site { get; set; }
        public string description { get; set; }
        public string author_name { get; set; }
        public int statistic_id { get; set;}
        public string image_url { get; set; }
        public Statistic statistic { get; set; }
        public Author author { get; set; }

        public Item()
        {
            statistic = new Statistic();
            author = new Author();
        }
    }
}