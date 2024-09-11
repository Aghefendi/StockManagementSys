namespace Entity.Concreate
{
    public static class Helper
    {
        public static string GetTypeName(string fullTypeName)
        {


            string reString = "";
            try
            {
                int lastIndex= fullTypeName.LastIndexOf('.') +1 ;
                reString = fullTypeName.Substring(lastIndex,fullTypeName.Length-lastIndex);
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
