using System;
using System.Collections.Generic;

namespace pfeProject2020.Models
{
    public partial class SsmsColumn
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TableName { get; set; }
        public Guid IdTab { get; set; }

        public SsmsTable IdTabNavigation { get; set; }
    }
}
