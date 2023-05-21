using System.Configuration;

namespace UITech.Utility
{
    public class IOC
    {
        public IOC() 
        {
            try
            {
                string con = ConfigurationManager.AppSettings["DBMS"];
                if (con == "PSQL")
                {
                    PSQL();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public void PSQL()
        {

        }
    }
}
