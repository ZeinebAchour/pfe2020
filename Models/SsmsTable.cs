using System;
using System.Collections.Generic;

namespace pfeProject2020.Models
{
    public partial class SsmsTable
    {
        public SsmsTable()
        {
            SsmsColumn = new HashSet<SsmsColumn>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DBName { get; set; }
        public Guid IdBds { get; set; }

        public SsmsDatabases IdBdsNavigation { get; set; }
        public ICollection<SsmsColumn> SsmsColumn { get; set; }
    }
}
