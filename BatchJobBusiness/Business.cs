using BatchJobDataAccess;
using BatchJobInfrastructure;
using System.Data;

namespace BatchJobBusiness
{
    /// <summary>
    /// Author: Saikiran Mandhala
    /// Email: saikiran.mandhala@gmail.com
    /// Date: 15/07/2020
    /// </summary>
    public class Business : IBusiness
    {
        private DataSet orders;
        private IDataAccess _dataAccess;
        private ILogger _logger;
        private IEmailHandler _emailHandler;

        public Business(IDataAccess dataAccess, ILogger logger, IEmailHandler emailHandler)
        {
            _dataAccess = dataAccess;
            _logger = logger;
            _emailHandler = emailHandler;
        }

        public void StartBusinesProcess()
        {
            _logger.Log("Step 1: Orders Processing Started");

            this.GetFromDb();
            this.ProcessData();
            this.UpdateDb();

            this._emailHandler.SendEmail();
            _logger.Log("Step 6: Orders Processing Completed");
            _logger.Log("********* And you have learnt Basics of Autofac, tune in for Unit Testing*********");
            _logger.Log("********* ToDo: Add test projects for Business, DataAccess and other Libs and write test scripts*********");
            _logger.Log("********* If you would like to contribute please fork and send me pull request*********");
            _logger.Log("********* Thanks ~Saikiran Mandhala*********");


        }

        private void GetFromDb()
        {
            orders = _dataAccess.Get();
            _logger.Log("Step 2: Orders retrieved from Data Store");
        }

        private void ProcessData()
        {
            //consider we process data and get new dataset as a result
            orders = new DataSet();
            _logger.Log("Step 3: Orders Processed");

        }

        private void UpdateDb()
        {
            _dataAccess.Update(orders);
            _logger.Log("Step 4: Orders updated in Data Store");

        }
    }
}
