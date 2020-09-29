using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DWMS.Domain
{
    public class BarCode
    {
        public int ID { get; set; }
        [Required,MaxLength(50)]
        public string BARCODE { get; set; }
        [MaxLength(200)]
        public string DESCRIPTION { get; set; }
        public int PP { get; set; }
        public int CPZL { get; set; }
        public int XH { get; set; }
        public int QUANTITY { get; set; }
        public int BZXS { get; set; }
        public string BZSL { get; set; }
        public int SERIES { get; set; }
        public string VERSION { get; set; }
        public string YWY { get; set; }
        public string SQR { get; set; }
        public int BEGINNING { get; set; }
        public string PIPECODE { get; set; }
        public string BEIZ { get; set; }
        public int ISACTIVE { get; set; }
        public int CJR { get; set; }
        public DateTime? CJSJ { get; set; }
        public int XGR { get; set; }
        public DateTime? XGSJ { get; set; }
        public int ISEDIT { get; set; }
        public int CLONEBARCODE { get; set; }

    }
}
