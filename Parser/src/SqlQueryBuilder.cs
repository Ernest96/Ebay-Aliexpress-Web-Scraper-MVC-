using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser
{
    //BUILDER
    public class SqlQueryBuilder
    {
        private string _query = "";

        public string Build()
        {
            return _query;
        }

        public SqlQueryBuilder SELECT(string[] values)
        {
            _query += "SELECT ";
            foreach(var x in values)
            {
                _query += x + ",";
            }

            _query = _query.Remove(_query.Length - 1);
            _query += " ";

            return this;
        }

        public SqlQueryBuilder RETURN_ID()
        {
            _query += " ;  SELECT CAST(SCOPE_IDENTITY() as int);";
            return this;
        }

        public SqlQueryBuilder DELETE()
        {
            _query += "DELETE ";
            return this;
        }

        public SqlQueryBuilder UPDATE()
        {
            _query += "UPDATE ";
            return this;
        }

        public SqlQueryBuilder SET(string[] toSet, string[] values)
        {
            if (toSet.Length != values.Length)
                throw new Exception("Sql Builder SET: columns number is different from values number");

            for (int i = 0; i < toSet.Length; ++i)
            {
                _query += $" {toSet[i]} = {values[i]},"; 
            }

            _query = _query.Remove(_query.Length - 1);
            _query += " ";

            return this;
        }

        public SqlQueryBuilder FROM(string table)
        {
            _query += "FROM " + table + " ";
            return this;
        }

        public SqlQueryBuilder WHERE<T>(string field, string condition, T value)
        {
            Type type = typeof(T);
            var a = type.ToString();

            _query += "WHERE ";
            _query += field + " ";
            _query += condition + " ";

            if (type.ToString() == "System.String")
            {
                CheckInjection(value as string);
                _query += $" '{value}'";
            }
            else
            {
                _query += $" {value}";
            }
            
            return this;
        }

        public SqlQueryBuilder VALUES(string[] values)
        {
            _query += " VALUES (";

            foreach (var x in values)
            {
                CheckInjection(x as string);
                _query += " '" + x + "',";
            }

            _query = _query.Remove(_query.Length - 1);
            _query += ")";

            return this;
        }

        public SqlQueryBuilder INSERT_INTO(string table, string[] values)
        {
            _query += "INSERT INTO " + table + " (";

            foreach (var x in values)
            {
                _query += x + ",";
            }

            _query = _query.Remove(_query.Length - 1);
            _query += ") ";

            return this;
        }

        private void CheckInjection(string value)
        {
            int i1 = value.IndexOf(';');
            int i2 = value.LastIndexOf('\'');

            if (i1 >= 0 && i2 >= 0 &&  i1 > i2)
                throw new Exception("Sql Builder exception to protect SQL Injection");
        }

    }
}