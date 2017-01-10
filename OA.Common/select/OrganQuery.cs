using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Common.select
{
    public class OrganQuery : ParamterQuery
    {
        public string ID { get; set; }
        public string ParentID { get; set; }
        public string TypeID { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string TaxNumber { get; set; }
        public string Bank { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<bool> IsDisable { get; set; }
        public Nullable<int> DeleteMark { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Path { get; set; }
        public string PathName { get; set; }
        public string SortStr { get; set; }
        public Nullable<bool> IsVirtual { get; set; }
    }
}
