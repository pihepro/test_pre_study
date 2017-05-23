namespace java storage
namespace py storage
namespace csharp storage

typedef i32 int // We can use typedef to get pretty names for the types we are using
 struct StoragePoint {
 1: int storageId = 0,
 2: string name,
 3: optional string description,
 
 }
 
service StorageService
{
		void ping(),
		list<StoragePoint> storagePoints(),
		string read(1:int id),
		bool write(1:int id, 2:string value),
        void close();
}