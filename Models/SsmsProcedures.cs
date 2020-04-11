using System;
using System.Collections.Generic;

namespace pfeProject2020.Models
{
    public partial class SsmsProcedures
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DBName { get; set; }
        public Guid? IdBd { get; set; }

        public SsmsDatabases IdBdNavigation { get; set; }
    }
}
