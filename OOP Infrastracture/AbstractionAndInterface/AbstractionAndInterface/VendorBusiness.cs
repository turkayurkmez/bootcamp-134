using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterface
{
   public class VendorBusiness
    {
        //Markaları nereye kaydedeceğim ya da nereden çekeceğim?
        //SQL mi, XML mi yoksa Oracle mı? Bilmiyorum! Agnostik tasarladım:
        public DataSource DataSource { get; set; }
        

    }

    public class Recorder
    {
        public void RecordData(IRecordable recordable)
        {
            recordable.SaveData("test");
        }
    }
}
