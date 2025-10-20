using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemBanVe
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            // event handler for mnuLogin click
            mnuLogin.Click += MnuLogin_Click;
        }

        private void MnuLogin_Click(object sender, EventArgs e)
        {
            // check if the form is already open
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmLogin)
                {
                    form.BringToFront(); // Bring the existing form to the front
                    return; // Exit the method to avoid opening a new instance
                }
            }

            frmLogin frm = new frmLogin();
            frm.MdiParent = this; // Set the MDI parent
            // center the child form within the parent
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void mnuTicketManagement_Click(object sender, EventArgs e)
        {
            // check if the form is already open
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmTicketManagement)
                {
                    form.BringToFront(); // Bring the existing form to the front
                    return; // Exit the method to avoid opening a new instance
                }
            }

            frmTicketManagement ticketManagementForm = new frmTicketManagement();
            ticketManagementForm.MdiParent = this; // Set the MDI parent
            // center the child form within the parent
            ticketManagementForm.StartPosition = FormStartPosition.CenterScreen;
            ticketManagementForm.Show();
        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
