using BatchJobBusiness;

namespace BatchJobEntryConsole
{
    public class Application : IApplication
    {
        private IBusiness _business;
        public Application(IBusiness business)
        {
            _business = business;
        }

        public void Run()
        {
            _business.StartBusinesProcess();
        }
    }
}
