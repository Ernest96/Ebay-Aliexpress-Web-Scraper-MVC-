
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser.Database
{
    public class StatisticsDB
    {
        public static Statistic GetStatisticById(int id)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .SELECT(new[] { "*" })
                    .FROM("statistics")
                    .WHERE("id", "=", id)
                    .Build();

                Statistic Statistic = conn.QueryFirstOrDefault<Statistic>(query);
                return Statistic;
            }
            catch (Exception e)
            {
                throw new Exception("Could not get Statistic from DB " + e.Message);
            }
        }

        public static void DeleteStatistic(int id)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .DELETE()
                    .FROM("statistics")
                    .WHERE("id", "=", id)
                    .Build();

                conn.Execute(query);
            }
            catch (Exception e)
            {
                throw new Exception("Could not delete Statistic from DB " + e.Message);
            }
        }

        public static void UpdateStatistic(Statistic statistic)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .UPDATE()
                    .SET(new[] { "rating" },
                         new[] { statistic.rating.ToString()})
                    .WHERE("id", "=", statistic.id)
                    .Build();

                conn.Execute(query);
            }
            catch (Exception e)
            {
                throw new Exception("Could not update Statistic from DB " + e.Message);
            }
        }


        public static void AddStatistic(Statistic statistic)
        {
            try
            {
                var conn = DbConfig.GetInstance.Connection;
                SqlQueryBuilder queryBuilder = new SqlQueryBuilder();

                string query = queryBuilder
                    .INSERT_INTO("Statistics", new[] { "item_id", "rating"})
                    .VALUES(new[] {statistic.item_id.ToString(), statistic.rating.ToString()})
                    .Build();

                conn.Execute(query);
            }
            catch (Exception e)
            {
                throw new Exception("Could not delete Statistic from DB " + e.Message);
            }
        }
    }
}