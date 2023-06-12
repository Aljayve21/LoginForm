using LoginForm.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        static MenuForm _obj;

        public static MenuForm Instance
        {
            get { if (_obj == null) { _obj = new MenuForm(); } return _obj; }
        }

        public void AddControls(Form f)
        {
            ControlPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            ControlPanel.Controls.Add(f);
            f.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
            _obj = this;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AddControls(new frmDashboard());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            AddControls(new CategoryView());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            AddControls(new frmEmployeeView());
        }

        private void ControlPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new frmProductView());
        }
    }
}
