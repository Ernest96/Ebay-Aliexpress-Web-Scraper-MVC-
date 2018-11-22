using Parser.Database;
using Parser.src.Util;
using Parser.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Parser
{
    //FACADE
    public class ScraperFacade
    {
        private Item item;
        private Parser parser;
        private string _url;

        public ScraperFacade(string url)
        {
            _url = url;
            item = new Item();
            parser = ParserFactory.GetParserByUrl(url);
        }

        public async Task<Item> ParseItemToDB()
        {
            try
            {
                string html = await HttpUtil.GetDataFromUrlAsync(_url);
                parser.SetHtml(html);

                item = parser.GetItem();
                HandleErrors();
                AddItemToDb();
                return item;

            }
            catch (Exception e)
            {
                throw new Exception("Cannot Parse Item to DB " + e.Message);
            }
        }

        private void AddItemToDb()
        {
            item.id = ItemsDB.AddItem(item);
        }

        private void HandleErrors()
        {
            var errors = ItemValidator.Validate(item);
            if (errors.Any())
            {
                string err = "";

                foreach (var x in errors)
                {
                    err += x + " ";
                }

                throw new Exception("Error creating item : " + err);
            }
        }

    }
}