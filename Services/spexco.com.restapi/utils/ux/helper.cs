using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using spexco.com.restapi.Models;

namespace spexco.com.restapi.utils.ux
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class helper
    {
        /// <summary>
        /// Appsettings deki dataları getirir 
        /// </summary>
        /// <param name="key">Getirilerek datanın key i</param>
        /// <returns></returns>
        public static T get_appsettings<T>(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return (T)Convert.ChangeType(builder.Build()[key], typeof(T));
        }
        /// <summary>
        /// Dinamik sorgu
        /// </summary>
        /// <param name="request">sorgu parametreleri</param>
        /// <returns></returns>
        public static apiresponse<dynamic> get_query(apigenericrequest request)
        {
            var result = new apiresponse<dynamic>();
            try
            {
                using (var db = utils.connection.helper.get_connection())
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("select ");
                    sb.Append(query_selectfield(request.seletedfileds));
                    sb.Append(" from ");
                    sb.Append(request.tablename);
                    sb.Append(query_where(request.predicates));
                    sb.Append(query_paging(request.paging, request.pageindex, request.pagesize, request.orderby));
                    var data = db.QueryAsync(sb.ToString(), null, null, null, System.Data.CommandType.Text);
                    if (data.Exception != null && !string.IsNullOrEmpty(data.Exception.Message))
                        throw data.Exception;

                    var count_sql = "select count(*) from " + request.tablename + query_where(request.predicates);
                    var count = db.ExecuteScalar<int>(count_sql, null, null, null, System.Data.CommandType.Text);
                    
                    result.data = data.Result.ToList();
                    result.displayedrecord = data.Result.Count();
                    result.totalcount = count;
                    result.code = 200;
                    result.success.Add("İşlem başarılı");
                }
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.errors.Add(ex.Message);
            }
            return result;
        }
        /// <summary>
        /// Sayfalama sorgusu
        /// </summary>
        /// <param name="paging">sayfalama yapılacak mı true & false</param>
        /// <param name="index">hangi index</param>
        /// <param name="size">gelecek kayıt sayısı</param>
        /// <param name="orderby">sıralama kriteri</param>
        /// <returns></returns>
        private static string query_paging(bool paging, int index, int size, orderby orderby)
        {
            if (orderby.fieldname == null)
                return string.Empty;

            var query = new System.Text.StringBuilder();
            query.Append(" ORDER BY ");
            query.Append(orderby.fieldname + " ");
            query.Append(orderby.type + " ");

            if (!paging)
                return query.ToString();

            query.Append(" OFFSET (");
            query.Append(index * size);
            query.Append(") ROWS FETCH NEXT ");
            query.Append(size);
            query.Append(" ROWS ONLY; ");
            return query.ToString();
        }
        /// <summary>
        /// sorgu kriterleri,şartlar
        /// </summary>
        /// <param name="predicate">şartlar</param>
        /// <returns></returns>
        private static string query_where(predicate predicate)
        {
            if (predicate == null || predicate.logicaloperators == null)
                return string.Empty;
            var query = new System.Text.StringBuilder();
            query.Append(" WHERE ");

            foreach (var item in predicate.filters)
            {
                query.Append(" " + item.fieldname + " ");
                if (item.operators.ToString() == "LIKE" || item.operators.ToString() == "like")
                    query.Append(" LIKE '%" + item.value1 + "%' ");
                else if (item.operators.ToUpper() == "BETWEEN")
                    query.Append(" BETWEEN '" + item.value1 + "' AND '" + item.value2 + "' ");
                else
                    query.Append(" " + item.operators + "'" + item.value1 + "' ");

                if (item != predicate.filters.Last())
                    query.Append(" " + predicate.logicaloperators + " ");
            }

            return query.ToString();
        }
        /// <summary>
        /// Sorguda getirilecek field lar 
        /// </summary>
        /// <param name="selected">field</param>
        /// <returns></returns>
        private static string query_selectfield(List<string> selected)
        {
            var query = new System.Text.StringBuilder();
            if (selected.Count() == 0)
                query.Append(" * ");
            foreach (var item in selected)
                if (selected.Last() == item)
                    query.Append(" " + item + " ");
                else
                    query.Append(" " + item + ",");

            return query.ToString();
        }
 
    }
}
