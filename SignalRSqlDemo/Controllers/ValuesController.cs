using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SignalRSqlDemo.Models;

namespace SignalRSqlDemo.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        readonly JobInfoRepository _jobInfoRepository = new JobInfoRepository();
        [Route("GetValues")]
        public IEnumerable<JobInfo> GetValues()
        {
            return _jobInfoRepository.GetData();
        }
    }
}
