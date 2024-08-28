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

        public void ApplySort(String sortExpression)
        {
            //ViewData["SortParamName"] = "name";
            //ViewData["SortParamDesc"] = "description";

            //ViewData["SortIconName"] = "";
            //ViewData["SortIconDesc"] = "";

            //SortOrder sortOrder;
            //string sortProperty;
            this.GetColumn("name").SortIcon = "";
            this.GetColumn("name").SortExpression = "name";

            this.GetColumn("description").SortIcon = "";
            this.GetColumn("description").SortExpression = "description";


            

            switch (sortExpression.ToLower())
            {

                case "name_desc":
                    this.SortOrder = SortOrder.Descending;
                    this.SortProperty = "name";

                    this.GetColumn("name").SortIcon = "fa fa-arrow-up";
                    this.GetColumn("name").SortExpression = "name";

                    //  ViewData["SortParamName"] = "name";
                    // ViewData["SortIconName"] = "fa fa-arrow-up";
                    break;

                case "description":
                    this.SortOrder = SortOrder.Ascending;
                    this.SortProperty = "description";

                    this.GetColumn("description").SortIcon = "fa fa-arrow-down";
                    this.GetColumn("description").SortExpression = "description_desc";

                    //ViewData["SortParamDesc"] = "description_desc";
                    //ViewData["SortIconDesc"] = "fa fa-arrow-down";
                    break;
                case "description_desc":
                    this.SortOrder = SortOrder.Descending;
                    this.SortProperty = "description";

                    this.GetColumn("description").SortIcon = "fa fa-arrow-up";
                    this.GetColumn("description").SortExpression = "description";

                    //ViewData["SortParamDesc"] = "description";
                    //ViewData["SortIconDesc"] = "fa fa-arrow-up";
                    break;
                default:
                    this.SortOrder = SortOrder.Ascending;
                    this.SortProperty = "name";

                    this.GetColumn("name").SortIcon = "fa fa-arrow-down";
                    this.GetColumn("name").SortExpression = "name_desc";

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

