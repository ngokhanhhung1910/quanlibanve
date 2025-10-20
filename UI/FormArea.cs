using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Entities;

namespace PhanMemBanVe
{
    public partial class frmArea : Form
    {
        public frmArea()
        {
            InitializeComponent();
            // event handler for buttons click for btnExit
            btnExitArea.Click += (s, e) => this.Close();
        }

        public Action<object, object> SaveAreaClick { get; internal set; }

        private void btnSaveArea_Click(object sender, EventArgs e)
        {
            // validate if txtAreaName is not empty && txtAreaId is not empty
            if (string.IsNullOrWhiteSpace(txtAreaName.Text) || string.IsNullOrWhiteSpace(txtAreaId.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // create new area object
            var area = new Area
            {
                AreaID = int.TryParse(txtAreaId.Text, out int id) ? id : 0,
                AreaName = txtAreaName.Text
            };
            // notify parent form
            SaveAreaClick?.Invoke(this, area);
            this.Close();
        }

        private void frmArea_Load(object sender, EventArgs e)
        {

        }
    }
}
