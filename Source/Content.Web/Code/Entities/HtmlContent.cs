﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentNamespace.Web.Code.Entities
{
    public class HtmlContent
    {
        public int Id { get; set; }
        public string ContentData { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ActiveDate { get; set; }
        public string ModifiedBy { get; set; }

        public HtmlContent()
        {
            Id = -2;
        }
    }
}