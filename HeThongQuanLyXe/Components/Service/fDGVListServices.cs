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
    public partial class fDGVListServices : Form
    {

        public DataGridView DGVListService
        {
            get { return this.dtgvListServices; }
            set { this.dtgvListServices = value; }
        }
        //Tạo DataGridViewCellEventHandler cho event Cell click của dtgvListServices tại form này, khi được khởi tạo từ parent form, ta có thể 
        //tùy ý set sự kiện cho form này tại parent form
        public event DataGridViewCellEventHandler OnChildDatagridViewCellClick;
        
        public fDGVListServices()
        {
            InitializeComponent();
        }

        private List<Service> listServices = new List<Service>();
        public void fDGVListServices_Load(object sender, EventArgs e)
        {
            loadDGVListServices();
            
        }
        //Khởi tạo dữ liệu cho dtgvListServices
        private void loadDGVListServices()
        {
            listServices = Service_DAO.Instance.ListService();
            dtgvListServices.DataSource = (from e in listServices select new { MaDV = e.ID, TenDV = e.ServiceName }).ToList();
            
            dtgvListServices.ClearSelection();
        }

        private void dtgvListServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if(OnChildDatagridViewCellClick != null)
            {
                OnChildDatagridViewCellClick(this,e);
            }
        }
    }
}
