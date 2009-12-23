﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentNamespace.Web.Code.Entities.Base
{
    public abstract class ContentManagerBaseItem
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}