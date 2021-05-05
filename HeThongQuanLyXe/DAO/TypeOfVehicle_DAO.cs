using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.SqlClient;
using HeThongQuanLyXe.DTO;

namespace HeThongQuanLyXe.DAO
{
    class TypeOfVehicle_DAO
    {
        private static TypeOfVehicle_DAO instance;
        public static TypeOfVehicle_DAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TypeOfVehicle_DAO();
                }
                return instance;
            }
        }
        private TypeOfVehicle_DAO()
        { }
        public bool checkTypeExist(string type)
        {
            using (dbHeThongQuanLyXeDataContext db = new dbHeThongQuanLyXeDataContext())
            {
                LOAIXE find = new LOAIXE();
                find = db.LOAIXEs.SingleOrDefault(obj => obj.TenLoai == type);
                if(find == default)
                {
                    return false;
                }
                return true;
            }
        }    
        public bool addTypeOfVehicle(string type)
        {
            using(dbHeThongQuanLyXeDataContext db = new dbHeThongQuanLyXeDataContext())
            {
                LOAIXE obj = new LOAIXE();
                obj.TenLoai = type;
                db.LOAIXEs.InsertOnSubmit(obj);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    db.SubmitChanges();
                    return false;
                }
            }
        }
        public Dictionary<int,string> listTypeOfVehicle()
        {
            using(dbHeThongQuanLyXeDataContext db = new dbHeThongQuanLyXeDataContext())
            {
                Dictionary<int, string> list = (from t in db.LOAIXEs
                                                select new { key = t.MaLoai, value = t.TenLoai }).ToDictionary(type => type.key, type => type.value);

                return list;
            }
        }
    }
}
