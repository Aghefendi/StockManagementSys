
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace CodeByStudent.Tools
{

    public enum SortOrder { Ascending = 0, Descending = 1 }
    public class SortModel
    {


        private string UpIcon = "fa fa-arrow-up";
        private string DownIcon = "fa fa-arrow-down";
        public SortOrder SortOrder { get; set; }
        public string SortProperty { get; set; }

        public List<SortableColumn> sortableColumns = new List<SortableColumn>();
        public void AddColumn(string colname, bool IsDefaultColumn = false)
        {

            SortableColumn tmp = sortableColumns.Where(x => x.ColumnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
            {

                sortableColumns.Add(new SortableColumn() { ColumnName = colname });
            }
            if (IsDefaultColumn == true || sortableColumns.Count == 1)
            {
                SortProperty = colname;
                SortOrder = SortOrder.Ascending;
            }
        }

        public SortableColumn GetColumn(string colname)
        {
            SortableColumn tmp = sortableColumns.Where(x => x.ColumnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
            {

                sortableColumns.Add(new SortableColumn() { ColumnName = colname });


            }
            return tmp;
        }

        public void ApplySort(string sortExpression)
        {
            //ViewData["SortParamName"] = "name";
            //ViewData["SortParamDesc"] = "description";

            //ViewData["SortIconName"] = "";
            //ViewData["SortIconDesc"] = "";

            //SortOrder sortOrder;
            //string sortProperty;


            //this.GetColumn("name").SortIcon = "";
            //this.GetColumn("name").SortExpression = "name";

            //this.GetColumn("description").SortIcon = "";
            //this.GetColumn("description").SortExpression = "description";

            if (sortExpression == "")
                sortExpression = SortProperty;
            sortExpression = sortExpression.ToLower();

            foreach (SortableColumn sortableColumn in sortableColumns)
            {
                sortableColumn.SortIcon = "";
                sortableColumn.SortExpression = sortableColumn.ColumnName;

                if (sortExpression == sortableColumn.ColumnName)
                {
                    SortOrder = SortOrder.Ascending;
                    SortProperty = sortableColumn.ColumnName;

                    sortableColumn.SortIcon = DownIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName + "_decs";
                }
                if (sortExpression == sortableColumn.ColumnName.ToLower() + "_decs")
                {
                    SortOrder = SortOrder.Descending;
                    SortProperty = sortableColumn.ColumnName;
                    sortableColumn.SortIcon = UpIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName;

                }
            }


            switch (sortExpression.ToLower())
            {

                case "name_desc":
                    SortOrder = SortOrder.Descending;
                    SortProperty = "name";

                    GetColumn("name").SortIcon = UpIcon;
                    GetColumn("name").SortExpression = "name";

                    //  ViewData["SortParamName"] = "name";
                    // ViewData["SortIconName"] = "fa fa-arrow-up";
                    break;

                case "description":
                    SortOrder = SortOrder.Ascending;
                    SortProperty = "description";

                    GetColumn("description").SortIcon = DownIcon;
                    GetColumn("description").SortExpression = "description_desc";

                    //ViewData["SortParamDesc"] = "description_desc";
                    //ViewData["SortIconDesc"] = "fa fa-arrow-down";
                    break;
                case "description_desc":
                    SortOrder = SortOrder.Descending;
                    SortProperty = "description";
                    GetColumn("description").SortIcon = UpIcon;
                    GetColumn("description").SortExpression = "description";

                    //ViewData["SortParamDesc"] = "description";
                    //ViewData["SortIconDesc"] = "fa fa-arrow-up";
                    break;
                default:
                    SortOrder = SortOrder.Ascending;
                    SortProperty = "name";

                    GetColumn("name").SortIcon = DownIcon;
                    GetColumn("name").SortExpression = "name_desc";

                    //ViewData["SortIconName"] = "fa fa-arrow-down";
                    //ViewData["SortParamName"] = "name_desc";

                    break;

            }



        }

        public class SortableColumn
        {

            public string ColumnName { get; set; }
            public string SortExpression { get; set; }
            public string SortIcon { get; set; }
        }



    }
}

