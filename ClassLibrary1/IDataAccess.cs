using System.Data;

namespace BatchJobDataAccess
{
    /// <summary>
    /// Author: Saikiran Mandhala
    /// Email: saikiran.mandhala@gmail.com
    /// Date: 15/07/2020
    /// </summary>
    public interface IDataAccess
    {
        DataSet Get();
        bool Update(DataSet orders);
    }
}