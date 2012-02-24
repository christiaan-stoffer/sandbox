using System.Collections.Generic;

namespace Sit.Framework.Portal.Sql.Generating
{
    public class SqlEntityInfo
    {
        private readonly List<SqlPropertyInfo> _properties;

        public SqlEntityInfo(string name)
        {
            this.Name = name;
            _properties = new List<SqlPropertyInfo>();
        }

        public string Name { get; private set; }

        public List<SqlPropertyInfo> Properties
        {
            get
            {
                return _properties;
            }
        }
    }
}