using System;
using System.Collections.Generic;

namespace pfeProject2020.Models
{
    public partial class SsmsDatabases
    {
        public SsmsDatabases()
        {
            SsmsProcedures = new HashSet<SsmsProcedures>();
            SsmsTable = new HashSet<SsmsTable>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string InstanceName { get; set; }
        // public Guid? IdInstances { get; set; }
        public Guid IdInstances { get; set; }

        public SsmsInstances IdInstancesNavigation { get; set; }
        public ICollection<SsmsProcedures> SsmsProcedures { get; set; }
        public ICollection<SsmsTable> SsmsTable { get; set; }
    }
}
