using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Model
{
    public partial class frmProductAdd : Crud
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int catID = 0;
        public int stock = 0;


        
        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {
            string qry = "Select category_ID 'id' , catName 'name' from category ";
            MainClass.CBFill(qry, cbCat);

            if (catID > 0)
            {
                cbCat.SelectedValue = catID;
            }

            if(id > 0)
            {
                ForUpdateLoadData();
            }
        }

        string filePath;
        Byte[] imageByteArray;
        private object RM;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtImage.Image = new Bitmap(filePath);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";


            if (id == 0)
            {
                qry = "Insert into products Values (@Name, @price, @catID, @size, @img, @stock)";
            }
            else
            {
                qry = "Update products Set prod_name = @Name, price = @price, category_ID = @catID, size = @size, stockID = @stock, pImage = @img where prodID = @id ";
            }

            //Image
            Image temp = new Bitmap(txtImage.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@price", txtPrice.Text);
            ht.Add("@catID", Convert.ToInt32(cbCat.SelectedValue));
            ht.Add("@size", Convert.ToChar(cbSize.SelectedValue));
            ht.Add("@stock", stock);
            ht.Add("@img", imageByteArray);



            if (MainClass.SQl(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Saved Successfully..");
                id = 0;
                catID = 0;
                stock = 1;
                txtName.Text = "";
                txtPrice.Text = "";
                cbSize.SelectedIndex = -1;
                cbCat.SelectedIndex = 0;

                txtImage.Image = RM.Properties.Resources.
                
                txtName.Focus();

            }
        }

        private void ForUpdateLoadData()
        {
            string qry = @"Selet * from products where pid = " + id + "";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >0)
            {
                txtName.Text = dt.Rows[0]["prod_name"].ToString();
                txtName.Text = dt.Rows[0]["price"].ToString();

                Byte[] imageArray = (byte[])(dt.Rows[0]["pImage"]);
                byte[] imageByteArray = imageArray;
                txtImage.Image = Image.FromStream(new MemoryStream(imageArray));
            }
        }
    }
}
