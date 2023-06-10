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
    public partial class Crud : Form
    {
        public Crud()
        {
            InitializeComponent();
        }

        public virtual void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        public virtual void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
