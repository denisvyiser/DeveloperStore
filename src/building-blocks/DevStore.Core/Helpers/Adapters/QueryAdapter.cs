using DevStore.Core.Mediatr.Queries;
using DevStore.Core.Models.Entities;
using DevStore.Core.Models.Pagination;
using System.Text.RegularExpressions;

namespace DevStore.Core.Helpers.Adapters
{
    public class QueryAdapter
    {
        public static TQuery CreateQuery<TQuery, TEntity>(Dictionary<string, string> queryParam) where TQuery : GetPaginatedQuery<TEntity>, new() where TEntity : Entity
        {
            var query = new TQuery();

            int _page = 1;
            int _size = 10;
            
            // The foreach loop will iterate over the params collection and print the key and value for each param

            foreach (var prop in queryParam)
            {
                if (Regex.Matches(prop.Key, "(\\b_min)([a-zA-Z]+)", RegexOptions.IgnoreCase).Any())
                {
                    query.Filters.Add(CreateFilterByKey(prop.Key, prop.Value, Operator.LessThan, "(\\b_min)([a-zA-Z]+)"));
                }
                else if (Regex.Matches(prop.Key, "(\\b_max)([a-zA-Z]+)", RegexOptions.IgnoreCase).Any())
                {
                    query.Filters.Add(CreateFilterByKey(prop.Key, prop.Value, Operator.GreaterThan, "(\\b_max)([a-zA-Z]+)"));
                }
                else if (prop.Key == "_order")
                {
                    query.Orders = CreateOrder(prop.Key, prop.Value, "([a-zA-Z]+) \\b(desc|asc)|([a-zA-Z]+)");
                }
                else if (prop.Key == "_size")
                { 
                    _size = int.Parse(queryParam["_size"]); 
                }
                else if (prop.Key == "_page")
                {
                    _page = int.Parse(queryParam["_page"]);
                }
                else
                {
                    if (Regex.Match(prop.Value, "\\*([a-zA-Z0-9]+)\\*", RegexOptions.IgnoreCase).Success)//contains
                    {
                        query.Filters.Add(CreateFilterByValue(prop.Key, prop.Value, Operator.Contains, "\\*([a-zA-Z0-9]+)\\*"));
                    }

                    else if (Regex.Match(prop.Value, "\\*([a-zA-Z0-9]+)", RegexOptions.IgnoreCase).Success)//starts with
                    {
                        query.Filters.Add(CreateFilterByValue(prop.Key, prop.Value, Operator.StartsWith, "\\*([a-zA-Z0-9]+)"));
                    }

                    else if (Regex.Match(prop.Value, "([a-zA-Z0-9]+)\\*", RegexOptions.IgnoreCase).Success)//ends with
                    {
                        query.Filters.Add(CreateFilterByValue(prop.Key, prop.Value, Operator.EndsWith, "([a-zA-Z0-9]+)\\*"));
                    }
                    else
                    {
                        query.Filters.Add(new Filter(prop.Key, Operator.Equals, prop.Value));
                    }
                }
            }

            query.Page = new Page(_page, _size);

            return query;
        }

        private static Filter CreateFilterByKey(string key, string value, Operator _operator, string regex)
        {
            var property = Regex.Matches(key, regex, RegexOptions.IgnoreCase)[0].Groups[2].Value;

            var filter = new Filter(property, _operator, value);

            return filter;
        }

        private static Filter CreateFilterByValue(string key, string value, Operator _operator, string regex)
        {
            var _value = Regex.Matches(value, regex, RegexOptions.IgnoreCase);

            var filter = new Filter(key, _operator, _value[0].Groups[1].Value);

            return filter;
        }

        private static List<Order> CreateOrder(string key, string value, string regex)
        {

            List<Order> orders = new List<Order>();

            foreach (Match match in Regex.Matches(value, regex, RegexOptions.IgnoreCase))
            {


                orders.Add(new Order(!string.IsNullOrEmpty(match.Groups[1].Value) ? match.Groups[1].Value : match.Groups[3].Value,
                    !string.IsNullOrEmpty(match.Groups[2].Value) ? match.Groups[2].Value : "asc"));
            }

            return orders;
        }
    }


    //    public static TQuery CreateQuery<TQuery, TEntity>(string url) where TQuery : GetPaginatedQuery<TEntity>, new() where TEntity : Entity
    //    {                        
    //        var parsedUrl = url.Split('?')[1];

    //        // The ParseQueryString method will parse the query string and return a NameValueCollection
    //        var paramsCollection = HttpUtility.ParseQueryString(parsedUrl);

    //        var query = new TQuery();

    //        // The foreach loop will iterate over the params collection and print the key and value for each param

    //        foreach (var key in paramsCollection.AllKeys)
    //        {
    //            if (Regex.Matches(key, "(\\b_min)([a-zA-Z]+)", RegexOptions.IgnoreCase).Any())
    //            {
    //                query.Filters.Add(CreateFilterByKey(key, prop.Value, Operator.LessThan, "(\\b_min)([a-zA-Z]+)"));
    //            }
    //            else if (Regex.Matches(key, "(\\b_max)([a-zA-Z]+)", RegexOptions.IgnoreCase).Any())
    //            {
    //                query.Filters.Add(CreateFilterByKey(key, prop.Value, Operator.GreaterThan, "(\\b_max)([a-zA-Z]+)"));
    //            }
    //            else if (key == "_order")
    //            {
    //                query.Orders = CreateOrder(key, prop.Value, "([a-zA-Z]+) \\b(desc|asc)|([a-zA-Z]+)");
    //            }
    //            else
    //            {
    //                if (Regex.Match(prop.Value, "\\*([a-zA-Z0-9]+)\\*", RegexOptions.IgnoreCase).Success)//contains
    //                {
    //                    query.Filters.Add(CreateFilterByValue(key, prop.Value, Operator.Contains, "\\*([a-zA-Z0-9]+)\\*"));                       
    //                }

    //                else if (Regex.Match(prop.Value, "\\*([a-zA-Z0-9]+)", RegexOptions.IgnoreCase).Success)//starts with
    //                {
    //                    query.Filters.Add(CreateFilterByValue(key, prop.Value, Operator.StartsWith, "\\*([a-zA-Z0-9]+)"));                        
    //                }

    //                else if (Regex.Match(prop.Value, "([a-zA-Z0-9]+)\\*", RegexOptions.IgnoreCase).Success)//ends with
    //                {
    //                    query.Filters.Add(CreateFilterByValue(key, prop.Value, Operator.EndsWith, "([a-zA-Z0-9]+)\\*"));                        
    //                }
    //                else
    //                {
    //                    query.Filters.Add(new Filter(key, Operator.Equals, prop.Value));
    //                }
    //            }
    //        }

    //        return query;
    //     }

    //    private static Filter CreateFilterByKey(string key, string value, Operator _operator, string regex)
    //    {
    //        var property = Regex.Matches(key, regex, RegexOptions.IgnoreCase)[0].Groups[2].Value;

    //        var filter = new Filter(property, _operator, value);

    //        return filter;
    //    }

    //    private static Filter CreateFilterByValue(string key, string value, Operator _operator, string regex)
    //    {
    //        var _value = Regex.Matches(value, regex, RegexOptions.IgnoreCase);

    //        var filter = new Filter(key, _operator, _value[0].Groups[1].Value);

    //        return filter;
    //    }

    //    private static List<Order> CreateOrder(string key, string value, string regex)
    //    {

    //        List<Order> orders = new List<Order>();

    //        foreach (Match match in Regex.Matches(value, regex, RegexOptions.IgnoreCase))
    //        {


    //            orders.Add(new Order(!string.IsNullOrEmpty(match.Groups[1].Value) ? match.Groups[1].Value : match.Groups[3].Value,
    //                !string.IsNullOrEmpty(match.Groups[2].Value) ? match.Groups[2].Value : "asc"));
    //        }

    //        return orders;
    //    }
}

