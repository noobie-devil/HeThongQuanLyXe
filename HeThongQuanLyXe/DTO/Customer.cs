using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyXe.DTO
{
    class Customer: Person
    {
        public Customer()
        {

        }
        public Customer(string maKH, string hoTen, string gender, DateTime birthDate, string sdt, Image hinhAnh)
        {
            this.MaKH = maKH;
            base.HoTen = hoTen;
            base.Gender = gender;
            base.BirthDate = birthDate;
            base.SDT = sdt;
            base.HinhAnh = hinhAnh;
            
        }
        public string MaKH  
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }
        
    }
}
