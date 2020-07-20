using System;
using System.Collections.Generic;
using System.Data;

namespace JG.Application
{
    public static class ConvertListToDataTable
    {
        public static DataTable ConvertTovDataTable<T>(this IEnumerable<T> list)
        {
            var elementType = typeof(T);
            using (var t = new DataTable())
            {
                var props = elementType.GetProperties();
                foreach (var propInfo in props)
                {
                    var pi = propInfo.PropertyType;
                    var colType = Nullable.GetUnderlyingType(pi) ?? pi;
                    t.Columns.Add(propInfo.Name, colType);
                }
                foreach (var item in list)
                {
                    var row = t.NewRow();
                    foreach (var propInfo in props)
                    {
                        row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                    }
                    t.Rows.Add(row);
                }
                return t;
            }
        }





        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            var list = new List<T>();
            foreach (var row in table.AsEnumerable())
            {
                var obj = new T();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        var propertyInfo = obj.GetType().GetProperty(prop.Name);
                        if (propertyInfo.PropertyType.IsEnum)
                        {
                            propertyInfo.SetValue(obj, Enum.Parse(propertyInfo.PropertyType, row[prop.Name].ToString()));
                        }
                        else
                        {
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                list.Add(obj);
            }

            return list;
        }
    }
}
