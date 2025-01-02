using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BranchManagement.Core.Helpers;

namespace BranchManagement.Core.Models
{
    public class BranchSearch
    {
       
        public string Title { get; set; }=string.Empty;
        public int PageNo { get; set; }
        public int PageSize { get; set; }

    }
}   