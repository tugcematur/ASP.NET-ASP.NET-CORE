using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    interface IBaseRepository<T> where T : class //Type'ın Tsi,sadece kendi yoluşturduğumuz classları kullanabiilriz,  string primitive değişkenleri kullanamayız.
    {
        void Delete(dynamic id);
        void Update(T entity,dynamic id); //Tablo güncellenecek manasında

        void Create(T entity,bool isRemove);

        T Find(dynamic id);   //Geri dönüş tipi T

        List<T> List();

        List<PropertyInfo> GetProperties(); //
    }
}
