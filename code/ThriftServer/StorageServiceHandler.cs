using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using storage;

namespace ThriftServer
{
    public class StorageServiceHandler : StorageService.Iface
    {
       private readonly Dictionary<int, StoragePoint> _points;

        public StorageServiceHandler()
        {
           
            _points = new Dictionary<int, StoragePoint>
            {
                {0, new StoragePoint {StorageId=0, Name = "Storage Point 1", Description = "Description 1"} },
                 {1, new StoragePoint {StorageId=1, Name = "Storage Point 2", Description = "Description 2"} },
                  {2, new StoragePoint {StorageId=2, Name = "Storage Point 3", Description = "Description 3"} },
            };
        }

        public void close()
        {
            throw new NotImplementedException();
        }

 
        public void ping()
        {
            Console.WriteLine("ping()");
        }

        

        public string read(int id)
        {
            Console.WriteLine("Read {0} ", id);
            StoragePoint p = null;
            if (_points.TryGetValue(id, out p) && p.Value != null)
            {
                return p.Value;
            }
            else
            {
                return "N/A";
            }
        }

      
        public bool write(int id, string value)
        {
            Console.WriteLine("Write {0}, {1} ", id, value);
            if (!_points.ContainsKey(id))
            {
                return false;
            }
            else
            {
                _points[id].Value = value;
                return true;
            }
        }

        List<StoragePoint> StorageService.ISync.storagePoints()
        {
            Console.WriteLine("Get storagepoints");
            return _points.Values.ToList<StoragePoint>();
        }
    }
}
