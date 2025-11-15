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

                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    return (TList)netDataContractSerializer.Deserialize(fs);
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
                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    netDataContractSerializer.Serialize(fs, list);
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
