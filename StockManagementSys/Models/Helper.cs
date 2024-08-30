namespace StockManagementSys.Models
{
    public static class Helper
    {
        public static string GetTypeName(string fullTypeName)
        {


            string reString = "";
            try
            {
                int lastIndex= fullTypeName.IndexOf('.')+1;
                reString = fullTypeName.Substring(lastIndex,fullTypeName.Length+lastIndex);
            }
            catch 
            {
                reString = fullTypeName;
           
            }
            reString = reString.Replace("]","");
            return reString;
        }

    }
}
