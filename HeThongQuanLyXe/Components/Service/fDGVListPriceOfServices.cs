using HeThongQuanLyXe.DAO;
using HeThongQuanLyXe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyXe
{
    public partial class fDGVListPriceOfServices : Form
    {
        public fDGVListPriceOfServices()
        {
            InitializeComponent();
        }
        private List<Service> listPrice = new List<Service>();
        public void fDGVListPriceOfServices_Load(object sender, EventArgs e)
        {
            loadDGVListPriceOfServices();
        }
        private void loadDGVListPriceOfServices()
        {
            listPrice = Service_DAO.Instance.ListPriceOfService();
            dtgvPriceOfSevice.DataSource = (from e in listPrice select e).ToList();
            dtgvPriceOfSevice.Columns[0].HeaderText = "Mã DV";
            dtgvPriceOfSevice.Columns[1].HeaderText = "Dịch Vụ";
            dtgvPriceOfSevice.Columns[2].HeaderText = "Mã Loại";
            dtgvPriceOfSevice.Columns[3].HeaderText = "Loại Xe";
            dtgvPriceOfSevice.Columns[4].HeaderText = "Giá Theo Giờ";
            dtgvPriceOfSevice.Columns[5].HeaderText = "Giá Theo Ngày";
            dtgvPriceOfSevice.Columns[6].HeaderText = "Giá Theo Tuần";
            dtgvPriceOfSevice.Columns[7].HeaderText = "Giá Theo Tháng";

            
            dtgvPriceOfSevice.ClearSelection();
        }
    }
}
