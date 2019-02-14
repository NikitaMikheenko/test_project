using System.Collections.Generic;

namespace Common
{
    public class WorkerFormModel
    {
        public Worker Worker { get; set; }

        public int CompanyId { get; set; }

        public List<Company> Companies { get; set; }
    }
}
