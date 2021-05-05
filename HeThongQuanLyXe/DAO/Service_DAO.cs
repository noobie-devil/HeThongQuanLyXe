using HeThongQuanLyXe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyXe.DAO
{
    class Service_DAO
    {
        private static Service_DAO instance;
        public static Service_DAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Service_DAO();
                }
                return instance;
            }
        }
        private Service_DAO()
        { }
        public List<Service> ListPriceOfService()
        {
            using(dbHeThongQuanLyXeDataContext db = new dbHeThongQuanLyXeDataContext())
            {
                var query = (from b in db.BANGGIADICHVUs
                             join l in db.LOAIXEs
                             on b.LoaiXe equals l.MaLoai
                             select new { MaDV = b.MaDV, MaLoaiXe = b.LoaiXe, TenLoai = l.TenLoai, GiaTheoGio = b.TheoGio });
                
                List<Service> list = (from d in db.DICHVUs join k in query
                                      on d.MaDV equals k.MaDV
                                      select new Service(d.MaDV,d.Ten,k.MaLoaiXe,k.TenLoai,(float)k.GiaTheoGio)).ToList();

                return list;
            }
        }
        public List<Service> GetListPriceOfSpecificService(int MaDV)
        {
            using(dbHeThongQuanLyXeDataContext db = new dbHeThongQuanLyXeDataContext())
            {
                var query = (from b in db.BANGGIADICHVUs where b.MaDV == MaDV select b);
                
                List<Service> price = (from l in db.LOAIXEs
                                       join q in query
                                       on l.MaLoai equals q.LoaiXe
                                       select new Service(l.MaLoai, l.TenLoai, (float)q.TheoGio)).ToList();
                return price;
            }
        }
        public List<Service> ListService()
        {
            using (dbHeThongQuanLyXeDataContext db = new dbHeThongQuanLyXeDataContext())
            {

                List<Service> list = (from d in db.DICHVUs select new Service(d.MaDV, d.Ten)).ToList();
                return list;
            }
        }
        public bool CheckExistService(string name,string MaDV = null)
        {
            using (dbHeThongQuanLyXeDataContext db = new dbHeThongQuanLyXeDataContext())
            {
                DICHVU d = new DICHVU();
                
                if(MaDV != null)
                {
                    int maDV = int.Parse(MaDV);
                    
                    d = db.DICHVUs.SingleOrDefault(s => s.Ten == name && s.MaDV != maDV);
                }
                else
                {
                    d = db.DICHVUs.SingleOrDefault(s => s.Ten == name);
                }
                
                if(d == default)
                {
                    return false;
                }
                return true;
            }
        }
        public bool UpdateService(int MaDV,string serviceName,Dictionary<int,Service> PriceOfService)
        {
            using(dbHeThongQuanLyXeDataContext db = new dbHeThongQuanLyXeDataContext())
            {
                List<BANGGIADICHVU> price = db.BANGGIADICHVUs.Where(s => s.MaDV == MaDV).ToList();
                db.BANGGIADICHVUs.DeleteAllOnSubmit(price);
                DICHVU d = db.DICHVUs.Single(s => s.MaDV == MaDV);
                d.Ten = serviceName;
                try
                {
                    db.SubmitChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    db.SubmitChanges();
                    return false;
                }
                

                if (PriceOfService.Count > 0)
                {
                    foreach (KeyValuePair<int, Service> element in PriceOfService)
                    {
                        BANGGIADICHVU newPrice = new BANGGIADICHVU();
                        newPrice.MaDV = MaDV;
                        newPrice.LoaiXe = element.Key;
                        newPrice.TheoGio = (decimal)element.Value.PricePerHour;
                        db.BANGGIADICHVUs.InsertOnSubmit(newPrice);
                    }
                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        db.SubmitChanges();
                        return false;
                    }
                }
                return true;
            }
        }
        public bool RemoveSerivce(int MaDV,Dictionary<int,Service> listPriceOfService)
        {
            using (dbHeThongQuanLyXeDataContext db = new dbHeThongQuanLyXeDataContext())
            {
                if(listPriceOfService.Count > 0)
                {
                    List<BANGGIADICHVU> prices = db.BANGGIADICHVUs.Where(p => p.MaDV == MaDV).ToList();
                    db.BANGGIADICHVUs.DeleteAllOnSubmit(prices);
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        db.SubmitChanges();
                        return false;
                    }
                }
                
                DICHVU service = db.DICHVUs.Single(s => s.MaDV == MaDV);
                db.DICHVUs.DeleteOnSubmit(service);
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
        public bool AddService(string serviceName, Dictionary<int,Service> PriceOfService)
        {
            using(dbHeThongQuanLyXeDataContext db = new dbHeThongQuanLyXeDataContext())
            {
                DICHVU dv = new DICHVU();
                dv.Ten = serviceName;
                db.DICHVUs.InsertOnSubmit(dv);
                try
                {
                    db.SubmitChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    db.SubmitChanges();
                    return false;
                }
                if(PriceOfService.Count > 0)
                {
                    DICHVU d = db.DICHVUs.Single(s => s.Ten == serviceName);
                    foreach (KeyValuePair<int, Service> element in PriceOfService)
                    {
                        BANGGIADICHVU price = new BANGGIADICHVU();
                        price.MaDV = d.MaDV;
                        price.LoaiXe = element.Key;
                        price.TheoGio = (decimal)element.Value.PricePerHour;
                        db.BANGGIADICHVUs.InsertOnSubmit(price);
                    }
                    try
                    {
                        db.SubmitChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        db.SubmitChanges();
                        return false;
                    }
                }
                return true;
            }
        }
       
    }
}
