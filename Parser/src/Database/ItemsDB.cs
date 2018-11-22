using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser.Database
{
    public class ItemsDB
    {
        public static Item GetItemById(int id)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .SELECT(new[] { "*" })
                    .FROM("items")
                    .WHERE("id", "=", id)
                    .Build();

                Item item = conn.QueryFirstOrDefault<Item>(query);
                return item;
            }
            catch (Exception e)
            {
                throw new Exception("Could not get item from DB " + e.Message);
            }
        }

        public static List<Item> GetAllItems()
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .SELECT(new[] { "*" })
                    .FROM("items")
                    .Build();

                List<Item> items = conn.Query<Item>(query).ToList();
                return items;
            }
            catch (Exception e)
            {
                throw new Exception("Could not get item from DB " + e.Message);
            }
        }

        public static void DeleteItem(int id)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .DELETE()
                    .FROM("items")
                    .WHERE("id", "=", id)
                    .Build();

                conn.Execute(query);
            }
            catch (Exception e)
            {
                throw new Exception("Could not delete item from DB " + e.Message);
            }
        }

        public static void UpdateItem(Item item)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .UPDATE()
                    .SET(new[] { "name", "price", "category", "site", "description",
                                "author_name", "statistic_id", "image_url"},
                         new[] { item.name, item.price.ToString(), item.category, item.site,
                                item.description, item.author_name, item.statistic_id.ToString(), item.image_url})
                    .WHERE("id", "=", item.id)
                    .Build();

                conn.Execute(query);
            }
            catch (Exception e)
            {
                throw new Exception("Could not update item from DB " + e.Message);
            }
        }


        public static int AddItem(Item item)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .INSERT_INTO("items",
                        new[] { "name", "price", "category", "site", "description",
                                "author_name", "statistic_id", "image_url"})
                    .VALUES(new[] { item.name, item.price.ToString(), item.category, item.site,
                                item.description, item.author_name, item.statistic_id.ToString(), item.image_url})
                    .RETURN_ID()
                    .Build();

                return conn.QueryFirstOrDefault<int>(query);
            }
            catch (Exception e)
            {
                throw new Exception("Could not delete item from DB " + e.Message);
            }
        }

    }
}