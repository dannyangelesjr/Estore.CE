using System;
using System.Reflection;
using System.Data.SqlServerCe;

namespace Estore.Ce.Helpers
{
    public static class ObjectMapper
    {
        public static TTarget MapTo<TSource, TTarget>(TSource source)
            where TTarget : class, new()
            where TSource : class
        {
            if (source == null)
                throw new ArgumentNullException("source");

            TTarget target = new TTarget();

            PropertyInfo[] sourceProps = typeof(TSource).GetProperties();
            PropertyInfo[] targetProps = typeof(TTarget).GetProperties();

            foreach (PropertyInfo sourceProp in sourceProps)
            {
                foreach (PropertyInfo targetProp in targetProps)
                {
                    if (targetProp.Name == sourceProp.Name &&
                        targetProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType) &&
                        targetProp.CanWrite)
                    {
                        object value = sourceProp.GetValue(source, null);
                        targetProp.SetValue(target, value, null);
                        break;
                    }
                }
            }

            return target;
        }

        public static T MapReaderToEntity<T>(SqlCeDataReader reader) where T : new()
        {
            T entity = new T();

            foreach (var property in typeof(T).GetProperties())
            {
                if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                {
                    property.SetValue(entity, reader[property.Name] ?? null, null);
                }
            }

            return entity;
        }
    }
}
