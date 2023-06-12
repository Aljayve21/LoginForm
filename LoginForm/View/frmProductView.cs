using LoginForm.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.View
{
    public partial class frmProductView : SampleView
    {
        public frmProductView()
        {
            InitializeComponent();
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            string qry = "select prodID,prod_name, price, size, p.category_ID, c.catName from products p inner join category c on c.category_ID = p.category_ID where prod_name like '%" + txtSearch.Text + "%'  ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvSno);
            lb.Items.Add(Column2);
            lb.Items.Add(size);
            lb.Items.Add(dgvPrice);
            lb.Items.Add(dgvcatID);
            lb.Items.Add(dgvcat);


            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new Model.frmProductAdd());
            GetData();
            //frmStaffAdd frm = new frmStaffAdd();
            //frm.ShowDialog();

        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "edit")
            {
                frmProductAdd frm = new frmProductAdd();
                //frmCategoryAdd frm = new frmCategoryAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvSno"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Column2"].Value);
                frm.cbSize.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["size"].Value);
                frm.txtPrice.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPrice"].Value);
                frm.cbSize.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["size"].Value);
                frm.cbCat.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvcat"].Value);
                MainClass.BlurBackground(frm);
                frm.ShowDialog();
                GetData();

            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "delete")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Column1"].Value);

                    string qry = "Delete from products where prodID = " + id + "";
                    //string qry = "Delete from products where prodID = " + guna2DataGridView1[0, e.RowIndex].Value + "";
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
    }
}
