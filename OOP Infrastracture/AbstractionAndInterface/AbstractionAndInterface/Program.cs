using System;

namespace AbstractionAndInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDataSource xmlDataSource = new XmlDataSource();
            SqlDataSource sqlDataSource = new SqlDataSource();

            VendorBusiness vendorBusiness = new VendorBusiness();
            vendorBusiness.DataSource = sqlDataSource;
            vendorBusiness.DataSource.GetData();

            vendorBusiness.DataSource = xmlDataSource;
            //vendorBusiness.DataSource.SaveData("xml örnek");

            Recorder recorder = new Recorder();
            recorder.RecordData(new SqlDataSource());
            recorder.RecordData(new OracleDatasource());

           // recorder.RecordData(new XmlDataSource());
        }
    }
}
