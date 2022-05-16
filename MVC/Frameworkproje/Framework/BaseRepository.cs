using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Framework
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        string tableName = typeof(T).Name; // T tipine al 

        string key = typeof(T).Name + "Id";  //global tanımlanablir.
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);

        public void Create(T entity, bool isRemove) // entity = model.Unvan        
        {
            var props = GetProperties();

            if(isRemove)
            {
                props.RemoveAt(0);   // Id yi propertylerden sildik
            }
     
            string cols = GetInsertColumns(props);
            string val = GetVal(props);
            string qry = $"insert into {tableName} {cols} {val}";
            con.Execute(qry, entity);

        }

        private string GetVal(List<PropertyInfo> props)
        {
            string val = "Values (";
            foreach (var item in props)
            {

                val += "@" + item.Name + ",";
            }

            val = val.Remove(val.Length - 1, 1);
            val += ")";
            return val;

        }

        // insert into Unvan (UnvanAd) Values (@UnvanAd) Dopperda
        private string GetInsertColumns(List<PropertyInfo> props)
        {
            string col = "(";
            foreach (var item in props)
            {
                col += item.Name + ",";
            }
            col = col.Remove(col.Length - 1, 1); //sondan bir tanesini sil
            col += ")";
            return col;

        }

        public void Delete(dynamic id)
        {
            con.ExecuteScalar<int>($"Delete from {tableName} where {key} = '{id}'");  //sayıyı tırnak içinde de kabul eder .
        }

    

        public T Find(dynamic id)
        {
            return   con.Query<T>($"select * from {tableName} where {key} = '{id}'  ").First();
         
        }


     

        public T Find(dynamic id, string key) //( ,"UnvanId")
        {
            
            return con.Query<T>($"select * from {tableName} where {key} = '{id}'  ").First();

        }

        public List<PropertyInfo> GetProperties()
        {
            var props = typeof(T).GetProperties().ToList(); // ToList() ile çevirdiğimiz için Lİst tipinde , Dizi tipinde değil!
            return props;
        }

        public List<T> List(string tablename)
        {
            var x = con.Query<T>($"Select * from {tablename}").ToList(); // 1.yöntem overloading
            return x;
        }

        public List<T> List()
        {
            return con.Query<T>($"Select * from {tableName}").ToList(); // 2.Yöntem overloading
        }

        public void Update(T entity, dynamic id)
        {
            var props = GetProperties();        
            string key = props[0].Name;
             props.RemoveAt(0);   // Id yi propertylerden sildik
          
     
            string val = GetUpdateColumns(props);
      
            string qry = $"Update  {tableName} {val} where {key} = '{id}'";
            con.Execute(qry, entity);
        }

     

        private string GetUpdateColumns(List<PropertyInfo> props)
        {
            //Update unvan set UnvanAd = @UnvanAd ,@UnvanKod= @UnvanKod where UnvanId = @UnvanId
            string val = "set "; //set ten sonra boşluk koy, koymazsan setUnvanAd olur  

            foreach(var item in props)
            {
                val += item.Name + " " + "=" + "@" + item.Name + " ,";
            }
             val= val.Remove(val.Length - 1, 1);
            return val;
          
        }
    }
}