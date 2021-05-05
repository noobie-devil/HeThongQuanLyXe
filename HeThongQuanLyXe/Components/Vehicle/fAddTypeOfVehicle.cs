using HeThongQuanLyXe.DAO;
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
    public partial class fAddTypeOfVehicle : Form
    {
        public fAddTypeOfVehicle()
        {
            InitializeComponent();
        }
        private Dictionary<int, string> source = new Dictionary<int, string>();
        private void iconBtnAddTypeOfVehicle_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                if(TypeOfVehicle_DAO.Instance.addTypeOfVehicle(txbTypeOfVehicle.Text.Trim()))
                {
                    MessageBox.Show("New Type Of Vehicle Inserted", "Add Type Of Vehicle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgvTypeOfVehicle.Rows.Clear();
                    dtgvTypeOfVehicle.Refresh();
                    fAddTypeOfVehicle_Load(sender, e);
                    
                }
                else
                {
                    MessageBox.Show("Type Of Vehicle Not Inserted", "Add Type Of Vehicle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private bool verify()
        {
            string text = txbTypeOfVehicle.Text.Trim();
            if (text == "")
            {
                MessageBox.Show("Empty Field","Add Type Of Vehicle" ,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if(TypeOfVehicle_DAO.Instance.checkTypeExist(text))
            {
                MessageBox.Show("This Type Of Vehicle Already Exists","Add Type Of Vehicle",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void fAddTypeOfVehicle_Load(object sender, EventArgs e)
        {
            source = TypeOfVehicle_DAO.Instance.listTypeOfVehicle();
            string[] row = new string[] { };
            foreach(KeyValuePair<int,string> element in source)
            {
                row = new string[] { element.Key.ToString(), element.Value };
                
                dtgvTypeOfVehicle.Rows.Add(row);
            }
        }

    }
}
