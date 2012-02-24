using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Sit.Framework.Portal.Content;

namespace Sit.Framework.Portal.Sql.Generating
{
    public class SqlEntityMap
    {
        private readonly List<SqlEntityInfo> _entityInfos;

        protected SqlEntityMap()
        {
            _entityInfos = new List<SqlEntityInfo>();
        }

        public IEnumerable<SqlEntityInfo> Entities
        {
            get
            {
                return _entityInfos;
            }
        }

        public static SqlEntityMap Generate(params Type[] types)
        {
            if (types == null)
            {
                throw new ArgumentNullException("types");
            }

            var map = new SqlEntityMap();

            foreach(var t in types)
            {
                map.ProcessType(t);
            }

            return map;
        }

        private void ProcessType(Type type)
        {
            var entity = new SqlEntityInfo(type.GetEntityName());

            var props = type.AllInterfaces().SelectMany(t=>t.GetProperties()).Select(ParseProperty);

            entity.Properties.AddRange(props);

            _entityInfos.Add(entity);
        }

        private static SqlPropertyInfo ParseProperty(PropertyInfo propertyInfo)
        {
            var attrs = propertyInfo.GetCustomAttributes(typeof(IPortalAttribute), true);

            var sqlPropertyInfo = new SqlPropertyInfo();

            var type = propertyInfo.PropertyType;

            bool needsLengthSpecified;

            sqlPropertyInfo.Name = propertyInfo.Name;
            sqlPropertyInfo.DbType = GetDbType(propertyInfo, out needsLengthSpecified);
            sqlPropertyInfo.IsKey = attrs.OfType<KeyAttribute>().Any();
            sqlPropertyInfo.IsNullable = attrs.OfType<NullableAttribute>().Any() || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>));

            if (needsLengthSpecified)
            {
                if (attrs.OfType<MultiLineAttribute>().Any())
                {
                    sqlPropertyInfo.Length = Length.Max;
                }
                else if (attrs.OfType<MaxLengthAttribute>().Any())
                {
                    sqlPropertyInfo.Length = new Length(attrs.OfType<MaxLengthAttribute>().First().Value);
                }
                else
                {
                    sqlPropertyInfo.Length = new Length(50);
                }
            }

            return sqlPropertyInfo;
        }

        private static SqlDbType GetDbType(PropertyInfo prop, out bool needsLengthSpecified)
        {
            var t = prop.PropertyType;
            needsLengthSpecified = false;

            if (t == typeof(string))
            {
                needsLengthSpecified = true;
                return SqlDbType.NVarChar;
            }

            if (t == typeof(DateTime))
            {
                return SqlDbType.DateTime2;
            }

            if (t == typeof(int))
            {
                return SqlDbType.Int;
            }

            if (t == typeof(Guid))
            {
                return SqlDbType.UniqueIdentifier;
            }

            throw new NotSupportedException(string.Format("Type '{0}' not supported (yet).", t.FullName));
        }
    }
}