using Dapper;
using Parser.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser.Database
{
    public class AuthorDB
    {
        public static Author GetAuthorByName(string name)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .SELECT(new[] { "*" })
                    .FROM("authors")
                    .WHERE("name", "=", name)
                    .Build();

                Author author = conn.QueryFirstOrDefault<Author>(query);
                return author;
            }
            catch (Exception e)
            {
                throw new Exception("Could not get Author from DB " + e.Message);
            }
        }

        public static void DeleteAuthor(string name)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .DELETE()
                    .FROM("authors")
                    .WHERE("name", "=", name)
                    .Build();

                conn.Execute(query);
            }
            catch (Exception e)
            {
                throw new Exception("Could not delete author from DB " + e.Message);
            }
        }

        public static void UpdateAuthor(Author author)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .UPDATE()
                    .SET(new[] { "name", "rating"},
                         new[] { author.name, author.rating.ToString()})
                    .WHERE("name", "=", author.name)
                    .Build();

                conn.Execute(query);
            }
            catch (Exception e)
            {
                throw new Exception("Could not update Author from DB " + e.Message);
            }
        }

        public static void AddAuthor(Author author)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .INSERT_INTO("authors", new[] { "name", "rating"})
                    .VALUES(new[] { author.name, author.rating.ToString()})
                    .Build();

                conn.Execute(query);
            }
            catch (Exception e)
            {
                throw new Exception("Could not delete Author from DB " + e.Message);
            }
        }
    }
}