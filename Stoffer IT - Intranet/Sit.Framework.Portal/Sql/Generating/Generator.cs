using System;
using Sit.Framework.Portal.Content;

namespace Sit.Framework.Portal.Sql.Generating
{
    public static class Generator
    {
        public static IGenerator For<TEntity>(GeneratorType type)
            where TEntity : IEntity
        {
            var t = typeof (TEntity);

            if (!t.IsInterface)
            {
                throw new NotSupportedException("Only interfaces are supported.");
            }

            switch (type)
            {
                case GeneratorType.Table:
                    return new TableGenerator(t);
                default:
                    return null;
            }
        }
    }
}
