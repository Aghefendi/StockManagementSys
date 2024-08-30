using System.Collections.Generic;
using System.Linq;

namespace CodeByStudent.Tools
{
    public enum SortOrder { Ascending = 0, Descending = 1 }

    public class SortModel
    {
        private string UpIcon = "fa fa-arrow-up";
        private string DownIcon = "fa fa-arrow-down";
        public SortOrder SortOrder { get; set; } = SortOrder.Ascending;
        public string SortProperty { get; set; } = string.Empty;

        private List<SortableColumn> sortableColumns = new List<SortableColumn>();

        public void AddColumn(string colname, bool IsDefaultColumn = false)
        {
            if (string.IsNullOrWhiteSpace(colname))
                return;

            var tmp = sortableColumns.FirstOrDefault(x => x.ColumnName.ToLower() == colname.ToLower());
            if (tmp == null)
            {
                sortableColumns.Add(new SortableColumn() { ColumnName = colname });
            }

            if (IsDefaultColumn || sortableColumns.Count == 1)
            {
                SortProperty = colname;
                SortOrder = SortOrder.Ascending;
            }
        }

        public SortableColumn? GetColumn(string colname)
        {
            if (string.IsNullOrWhiteSpace(colname))
                return null;

            var tmp = sortableColumns.FirstOrDefault(x => x.ColumnName.ToLower() == colname.ToLower());
            if (tmp == null)
            {
                tmp = new SortableColumn() { ColumnName = colname };
                sortableColumns.Add(tmp);
            }
            return tmp;
        }

        public void ApplySort(string sortExpression)
        {
            if (sortableColumns == null || !sortableColumns.Any())
                return;

            if (string.IsNullOrEmpty(sortExpression))
                sortExpression = this.SortProperty;
            sortExpression = sortExpression.ToLower();

            foreach (var sortableColumn in sortableColumns)
            {
                sortableColumn.SortIcon = "";
                sortableColumn.SortExpression = sortableColumn.ColumnName;

                if (sortExpression == sortableColumn.ColumnName.ToLower())
                {
                    this.SortOrder = SortOrder.Ascending;
                    this.SortProperty = sortableColumn.ColumnName;
                    sortableColumn.SortIcon = DownIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName + "_desc";
                }
                else if (sortExpression == sortableColumn.ColumnName.ToLower() + "_desc")
                {
                    this.SortOrder = SortOrder.Descending;
                    this.SortProperty = sortableColumn.ColumnName;
                    sortableColumn.SortIcon = UpIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName;
                }
            }
        }

        public class SortableColumn
        {
            public string ColumnName { get; set; } = string.Empty;
            public string SortExpression { get; set; } = string.Empty;
            public string SortIcon { get; set; } = string.Empty;
        }
    }
}
