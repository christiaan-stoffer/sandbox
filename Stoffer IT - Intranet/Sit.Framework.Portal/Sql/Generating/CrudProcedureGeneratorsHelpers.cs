namespace Sit.Framework.Portal.Sql.Generating
{
    public static class CrudProcedureGeneratorsHelpers
    {
        public static string ParseSqlPropertyInfoForProcedureParam(SqlPropertyInfo property)
        {
            string nullableText, typeExtra;

            nullableText = null;
            typeExtra = null;

            if (property.Length != Length.Empty)
            {
                typeExtra = property.Length == Length.Max
                                ? "(MAX)"
                                : string.Format(
                                    "({0})",
                                    property.Length);
            }

            if (property.IsNullable)
            {
                nullableText = " = NULL";
            }

            return
                string.Format(
                    "\t@{0} {1}{2}{3}",
                    property.Name, property.DbType, typeExtra,
                    nullableText);
        }
    }
}