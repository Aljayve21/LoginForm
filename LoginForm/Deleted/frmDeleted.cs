using Guna.UI2.WinForms;
using LoginForm.Model;
using LoginForm.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Deleted
{
    public partial class frmDeleted : SampleView
    {
       // public static readonly string con_string = "Data Source=ALJAYVE;Initial Catalog=POS1;Integrated Security=True";
      //  public static SqlConnection con = new SqlConnection(con_string);

        public frmDeleted()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "Column4")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvSno"].Value);
                    string qry = "Delete from employee where employeeID = " + guna2DataGridView1[1, e.RowIndex].Value.ToString() + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                    guna2MessageDialog1.Show("Deleted Successfully");

                }

            }

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* private void datagridCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             string columnCategory = guna2DataGridView1.Columns[e.ColumnIndex].Name;

             if (columnCategory == "Delete")
             {
                 if (MessageBox.Show("Do you want to delete this category?", "Delete the record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     con.Open();
                     cmd = new SqlCommand("Delete from employee where employeeID like '" + guna2DataGridView1[1, e.RowIndex].Value.ToString() + "'", con);
                     cmd.ExecuteNonQuery();
                     con.Close();
                     MessageBox.Show("The selected category have been successfully deleted.", "Tea Hara", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     frmEmployeeView();

                 }

             }
         } */
    }
}
