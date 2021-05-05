using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyXe.DTO
{
    abstract class Person
    {
        private string id;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private string hoTen;
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        private string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        private string sdt;
        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private Image hinhAnh;
        public Image HinhAnh
        {
            get { return hinhAnh; }
            set { hinhAnh = value; }
        }

    }
}
