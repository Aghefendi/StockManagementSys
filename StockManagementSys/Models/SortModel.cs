using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;

namespace StockManagementSys.Models
{
    public class SortModel
    {
        public SortOrder SortOrder { get; set; }
        public string SortProperty { get; set; }

        public List<SortableColumn> sortableColumns = new List<SortableColumn>();
        public void AddColumn(string colname)
        {

            SortableColumn tmp = this.sortableColumns.Where(x => x.ColumnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
            {

                sortableColumns.Add(new SortableColumn() { ColumnName = colname });
            }
        }

        public SortableColumn GetColumn(string colname)
        {
            SortableColumn tmp = this.sortableColumns.Where(x => x.ColumnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
            {

                sortableColumns.Add(new SortableColumn() { ColumnName = colname });
                

            }
            return tmp;
        }

        public class SortableColumn
        {

            public string ColumnName { get; set; }
            public string SortExpression { get; set; }
            public string SortIcon { get; set; }
        }



    }
}

