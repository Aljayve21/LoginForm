using LoginForm.Deleted;
using LoginForm.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.View
{
    public partial class frmEmployeeView : SampleView
    {
       

        public frmEmployeeView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * From employee where UserID like '%" + txtSearch.Text + "%'  ";
            ListBox lb = new ListBox();
            lb.Items.Add(Column1);
            lb.Items.Add(Column2);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvRole);
            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            //MainClass.BlurBackground(new Model.frmStaffAdd());
            //GetData();
            frmStaffAdd frm = new frmStaffAdd();
            frm.ShowDialog();

        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "Column3")
            {
                frmStaffAdd frm = new frmStaffAdd();

                //frmCategoryAdd frm = new frmCategoryAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvSno"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Column2"].Value);
                frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                frm.cbRole.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value);
                MainClass.BlurBackground(frm);
                frm.ShowDialog();
                GetData();

            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "Column4")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Column1"].Value);
                    
                    string qry = "Delete from employee where employeeID = " + guna2DataGridView1[0, e.RowIndex].Value + "";
                    //string qry = "Delete from employee where employeeID = " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Deleted Successfully");
                    GetData();
                }

            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleted_Click(object sender, EventArgs e)
        {
            frmDeleted dt = new frmDeleted();
            dt.ShowDialog();
            GetData();
        }
    }
}
