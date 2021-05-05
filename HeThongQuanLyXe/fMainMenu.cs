using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyXe
{
    public partial class MainMenuForm : Form
    {
        private IconButton currentBtn;
        public MainMenuForm()
        {
            InitializeComponent();

            //Ẩn phần viền phía trên của p/mềm khi chạy, có thể kéo thả di chuyển, resize khung phần mềm
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            customizeDesing();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void MainMenuForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void customizeDesing()
        {
            manageSystemSubmenuPanel.Visible = false;
            mainServiceSubmenuPanel.Visible = false;
        }
        private void hideSubMenu()
        {
            if (manageSystemSubmenuPanel.Visible == true)
                manageSystemSubmenuPanel.Visible = false;
            if (mainServiceSubmenuPanel.Visible == true)
                mainServiceSubmenuPanel.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
                
        }

        private void btnManageMainService_Click(object sender, EventArgs e)
        {
            showSubMenu(mainServiceSubmenuPanel);
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            ActiveButton(sender,Color.FromArgb(13, 138, 114));
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(13, 138, 114));
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(13, 138, 114));
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(13, 138, 114));
        }

        private void btnParking_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(13, 138, 114));
        }
        // Tạo hiệu ứng khi click vào button
        private void ActiveButton(object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(236, 246, 244);
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;
            }
        }
        // khi click vào button khác thì disable hiệu ứng ở button hiện tại
        private void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.White;
                currentBtn.ForeColor = Color.FromArgb(129, 136, 148);
                currentBtn.IconColor = Color.FromArgb(129, 136, 148);
            }
        }

        private void btnManageSystem_Click(object sender, EventArgs e)
        {
            showSubMenu(manageSystemSubmenuPanel);
        }
        // Khi click vào cái button Quản lý xe ở đề mục Quản lý hệ thống 
        private void btnManageVehicle_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(13, 138, 114));
            // nó chạy hàm openChildForm này, chạy form fAddTypeOfVehicle
            openChildForm(new fAddTypeOfVehicle());
        }

        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(13, 138, 114));
        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(13, 138, 114));
        }
        // Khi click vào cái button Quản lý dịch vụ ở đề mục Quản lý hệ thống  
        private void btnManageService_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(13, 138, 114));
            // nó chạy hàm openChildForm để mở form fManageService
            openChildForm(new fManageService());
        }

        private void btnManageParking_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(13, 138, 114));
        }

        private void btnManageJob_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(13, 138, 114));
        }
        // activeForm là child Form hiện tại đang được show ở childFormPanel(xem trong phần Design của fMainMenu.cs sẽ thấy)
        private Form activeForm = null;

        // hàm khởi chạy child form, nó sẽ được khởi chạy ở childFormPanel
        private void openChildForm(Form childForm)
        {
            //nếu activeForm đg có form khác đang chạy, thì nó sẽ đóng form đó trước khi khởi chạy child form mới
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childFormPanel.Controls.Add(childForm);
            childFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
