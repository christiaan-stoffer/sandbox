using System.Data;

namespace Sit.Framework.Portal.Sql.Generating
{
    public class SqlPropertyInfo
    {
        public string Name { get; set; }

        public SqlDbType DbType { get; set; }

        public bool IsNullable { get; set; }

        public Length Length
        {
            get;
            set;
        }

        public bool IsKey { get; set; }
    }
}