using System.Data;

namespace BatchJobDataAccess
{
    /// <summary>
    /// Author: Saikiran Mandhala
    /// Email: saikiran.mandhala@gmail.com
    /// Date: 15/07/2020
    /// </summary>
    public class DataAccess : IDataAccess
    {
        private string _connectionString;
        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataSet Get()
        {
            return new DataSet();
        }

        public bool Update(DataSet orders)
        {
            return true;
        }
    }
}
