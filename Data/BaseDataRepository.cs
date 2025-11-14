using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject.Data
{
    public abstract class BaseDataRepository<TList, TItem>
    where TList : class, new()
    where TItem : class
    {
        protected readonly string filePath;

        public BaseDataRepository()
        {
            filePath = Path.Combine(GetPath.path, typeof(TItem).Name + ".dat");
        }

        protected virtual TList Load()
        {
            try
            {
                if (!File.Exists(filePath))
                    return new TList();

                var serializer = new NetDataContractSerializer();

                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    return (TList)serializer.Deserialize(fs);
                }
            }
            catch
            {
                return new TList();
            }
        }

        protected virtual void Save(TList list)
        {
            try
            {
                var serializer = new NetDataContractSerializer();

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, list);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi ghi file: " + ex.Message);
            }
            
        }

        public abstract List<TItem> GetData();

        public abstract void SaveData(List<TItem> items);

        public virtual void CreateSampleData() { }
    }

}
