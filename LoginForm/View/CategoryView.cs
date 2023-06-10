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
    public partial class CategoryView : SampleView
    {
        public CategoryView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * From category where catName like '%"+ txtSearch.Text +"%'  ";
            ListBox lb = new ListBox();
            lb.Items.Add(Column1);
            lb.Items.Add(Column2);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void CategoryView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm = new frmCategoryAdd();
            frm.ShowDialog();
            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "Column3")
            {
                frmCategoryAdd frm = new frmCategoryAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Column1"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["Column2"].Value);
                frm.ShowDialog();
                GetData();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "Column4")
            {
                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Column1"].Value);
                string qry = "Delete from category where category_ID = " + id + "";
                Hashtable ht = new Hashtable();
                MainClass.SQl(qry, ht);

                MessageBox.Show("Deleted Successfully");
                GetData();
            }
        }
    }
}
