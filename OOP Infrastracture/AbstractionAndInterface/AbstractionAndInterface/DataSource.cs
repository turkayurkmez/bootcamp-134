using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterface
{
    public abstract class DataSource
    {
       // public abstract void SaveData(string data);
        public abstract void GetData();

        public abstract void Open();

        public bool IsConnected { get; set; }
        public void GetInfo()
        {
            Console.WriteLine("bağlantı bilgileri....");
        }



    }

    public interface IRecordable
    {
        void SaveData(string value);
    }

    public class SqlDataSource : DataSource,IRecordable
    {
        public override void GetData()
        {
            Console.WriteLine("SQL'den veri okunuyor");
        }

        public override void Open()
        {
            Console.WriteLine("sql Bağlantısı açılıyor");
        }

        public  void SaveData(string data)
        {
            Console.WriteLine("SQL'e veri yazılıyor");

        }
    }

    public class XmlDataSource : DataSource
    {
        public override void GetData()
        {
            Console.WriteLine("XML'den veri okunuyor");
        }

        public override void Open()
        {
            Console.WriteLine("XML dosyasına Bağlanılıyor");

        }

      
    }

    public class OracleDatasource : DataSource, IRecordable
    {
        public override void GetData()
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            throw new NotImplementedException();
        }

        public void SaveData(string data)
        {
            throw new NotImplementedException();
        }
    }
}
