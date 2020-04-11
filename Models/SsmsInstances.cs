using System;
using System.Collections.Generic;

namespace pfeProject2020.Models
{
    public partial class SsmsInstances
    {
        public SsmsInstances()
        {
            SsmsDatabases = new HashSet<SsmsDatabases>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }

        public ICollection<SsmsDatabases> SsmsDatabases { get; set; }
    }
}
