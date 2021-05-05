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
    public partial class fManageService : Form
    {
        public fManageService()
        {
            InitializeComponent();
        }
        private fDGVListServices childFormDGVListServices = new fDGVListServices();
        private fDGVListPriceOfServices childFormDGVListPriceOfServices = new fDGVListPriceOfServices();


        private void iconPBSort_Click(object sender, EventArgs e)
        {
            if(iconPBSort.IconChar == FontAwesome.Sharp.IconChar.SortAmountUpAlt)
            {
                iconPBSort.IconChar = FontAwesome.Sharp.IconChar.SortAmountDownAlt;
            }    
            else
            {
                iconPBSort.IconChar = FontAwesome.Sharp.IconChar.SortAmountUpAlt;
            }    
            
        }
        
        private Dictionary<int, Service> CurrentListPriceOfServiceAdded = new Dictionary<int, Service>();
        private void fManageService_Load(object sender, EventArgs e)
        {
            
            TypeOfVehicle = TypeOfVehicle_DAO.Instance.listTypeOfVehicle();
            loadChildFormListService(childFormDGVListServices);
            loadChildFormListPriceOfServices(childFormDGVListPriceOfServices);
            //childFormDGVListServices.fDGVListServices_Load(sender, e);
            //childFormDGVListPriceOfServices.fDGVListPriceOfServices_Load(sender, e);
            loadComboBoxTypeOfVehicle();
            loadDGVPriceOfSerivceAdded();
        }
        //Tạo sự kiện Cell Click cho DataGridView, truyền vào Child Form fDGVListServices
        private void dtgvListServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dt = (sender as fDGVListServices).DGVListService;
            if (e.RowIndex >= 0)
            {
                dt.CurrentRow.Selected = true;
                CurrentListPriceOfServiceAdded.Clear();

                txbServiceName.Text = dt.CurrentRow.Cells[1].Value.ToString();
                foreach (Service element in Service_DAO.Instance.GetListPriceOfSpecificService((int)dt.CurrentRow.Cells[0].Value))
                {
                    CurrentListPriceOfServiceAdded.Add(element.IDTypeOfVehicle, element);
                    
                }
                loadDGVPriceOfSerivceAdded();
            }
        }
        
        private Dictionary<int, string> TypeOfVehicle = new Dictionary<int, string>();

        
        //Khởi tạo danh sách Loại Xe cho ComboBox
        private void loadComboBoxTypeOfVehicle()
        {
            
            cbTypeOfVehicle.DataSource = (from element in TypeOfVehicle select element.Value).ToList();
        }
        //Khởi tạo Child Form fDGVListServices 
        private void loadChildFormListService(fDGVListServices childForm)
        {
            
            childForm.OnChildDatagridViewCellClick += new DataGridViewCellEventHandler(dtgvListServices_CellClick);
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Bottom;
            childForm.Size = new Size(579, 270);
            listServicesPanel.Controls.Add(childForm);
            listServicesPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }
        
        private void loadChildFormListPriceOfServices(fDGVListPriceOfServices childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Bottom;
            childForm.Size = new Size(579, 415);
            priceOfServicePanel.Controls.Add(childForm);
            priceOfServicePanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void iconBtnAddPriceOfService_Click(object sender, EventArgs e)
        {
            int IDType = new int();
            foreach (KeyValuePair<int, string> element in TypeOfVehicle)
            {
                if (element.Value == cbTypeOfVehicle.Text.Trim())
                {
                    IDType = element.Key;
                    break;
                }
            }
            if (txbServiceName.Text.Trim() == "")
            {
                MessageBox.Show("Service Name required first", "Add Price Of Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(CurrentListPriceOfServiceAdded.ContainsKey(IDType))
                {
                    CurrentListPriceOfServiceAdded[IDType].PricePerHour = (float)nmPricePerHour.Value;
                }    
                else
                {
                    Service service = new Service(IDType, cbTypeOfVehicle.Text.Trim(), (float)nmPricePerHour.Value);
                    CurrentListPriceOfServiceAdded.Add(IDType, service);
                }
                
            }
            
            
            
            loadDGVPriceOfSerivceAdded();
            dtgvShowPriceOfServiceAdded.Update();
            dtgvShowPriceOfServiceAdded.Refresh();
            
        }
        
        public void loadDGVPriceOfSerivceAdded()
        {
            dtgvShowPriceOfServiceAdded.DataSource = null;
            
            dtgvShowPriceOfServiceAdded.DataSource = (from e in CurrentListPriceOfServiceAdded select e.Value).ToList();
            //dtgvShowPriceOfServiceAdded.DataSource = (from e in CurrentListPriceOfServiceAdded select new { MaLoai = e.Value.IDTypeOfVehicle, LoaiXe = e.Value.TypeOfVehicle, GiaTheoGio = e.Value.PricePerHour }).ToList();
            dtgvShowPriceOfServiceAdded.Columns[0].Visible = false;
            dtgvShowPriceOfServiceAdded.Columns[1].Visible = false;
            dtgvShowPriceOfServiceAdded.Columns[2].HeaderText = "Mã Loại";
            dtgvShowPriceOfServiceAdded.Columns[3].HeaderText = "Loại Xe";
            dtgvShowPriceOfServiceAdded.Columns[4].HeaderText = "Giá Theo Giờ";
            dtgvShowPriceOfServiceAdded.Columns[5].HeaderText = "Giá Theo Ngày";
            dtgvShowPriceOfServiceAdded.Columns[6].HeaderText = "Giá Theo Tuần";
            dtgvShowPriceOfServiceAdded.Columns[7].HeaderText = "Giá Theo Tháng";
        }

        private void dtgvShowPriceOfServiceAdded_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                dtgvShowPriceOfServiceAdded.CurrentRow.Selected = true;
            }
        }

        private void iconBtnRemovePriceOfService_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dtgvShowPriceOfServiceAdded.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if(selectedRowsCount > 0 )
            {
                for(int i = 0; i < selectedRowsCount; i++)
                {
                    DataGridViewRow selectedRow = dtgvShowPriceOfServiceAdded.SelectedRows[i];
                    CurrentListPriceOfServiceAdded.Remove((int)selectedRow.Cells[2].Value);
                }
                loadDGVPriceOfSerivceAdded();
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            
            if(verify(null))
            {
                if (Service_DAO.Instance.AddService(txbServiceName.Text.Trim(), CurrentListPriceOfServiceAdded))
                {
                    MessageBox.Show("Service Inserted Successfully", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    childFormDGVListServices.fDGVListServices_Load(sender, e);
                    childFormDGVListPriceOfServices.fDGVListPriceOfServices_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Service Not Inserted", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void iconBtnEditService_Click(object sender, EventArgs e)
        {

            //Service_DAO.Instance.UpdateService((int)childFormDGVListServices.DGVListService.CurrentRow.Cells[0].Value,null);
            if(verify(childFormDGVListServices.DGVListService.CurrentRow.Cells[0].Value.ToString()))
            {
                if(Service_DAO.Instance.UpdateService((int)childFormDGVListServices.DGVListService.CurrentRow.Cells[0].Value, txbServiceName.Text.Trim(), CurrentListPriceOfServiceAdded))
                {
                    MessageBox.Show("Service Updated Successfully", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    childFormDGVListServices.fDGVListServices_Load(sender, e);
                    childFormDGVListPriceOfServices.fDGVListPriceOfServices_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Service Not Updated", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool verify(string MaDV)
        {
            if (txbServiceName.Text.Trim() == "")
            {
                MessageBox.Show("Service Name required ", "Add Price Of Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Service_DAO.Instance.CheckExistService(txbServiceName.Text.Trim(),MaDV))
            {
                MessageBox.Show("Service Name Already Exists", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CurrentListPriceOfServiceAdded.Clear();
            loadDGVPriceOfSerivceAdded();
            txbServiceName.Text = "";
            childFormDGVListServices.DGVListService.ClearSelection();
        }

        private void iconBtnRemoveService_Click(object sender, EventArgs e)
        {
            int MaDV = (int)childFormDGVListServices.DGVListService.CurrentRow.Cells[0].Value;
            if(Service_DAO.Instance.RemoveSerivce(MaDV,CurrentListPriceOfServiceAdded))
            {
                MessageBox.Show("Service Removed Successfully", "Remove Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                childFormDGVListServices.fDGVListServices_Load(sender, e);
                childFormDGVListPriceOfServices.fDGVListPriceOfServices_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Service Not Removed", "Remove Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
