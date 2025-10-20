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
    public partial class frmTicketManagement : Form
    {
        // define totalprice variable
        private decimal totalPrice = 0;

        public frmTicketManagement()
        {
            InitializeComponent();
            // event handler for buttons click for btnExit
            btnExit.Click += (s, e) => this.Close();
            // event handler for buttons click for btnCancel
            btnCancel.Click += BtnCancel_Click;
            // disable txtTotal textbox
            txtTotal.Enabled = false;
            // event handler for buttons click for btnBuyTicket
            btnBuyTicket.Click += BtnBuyTicket_Click;
            // event handler for btnAddArea click
            btnAddArea.Click += BtnAddArea_Click;

            // set value member && display member for cboArea combobox
            cboArea.ValueMember = "AreaId";
            cboArea.DisplayMember = "AreaName";
        }

        private void BtnAddArea_Click(object sender, EventArgs e)
        {
            // open new form frmAddArea
            frmArea addAreaForm = new frmArea();
            //center the form in the middle of the screen
            addAreaForm.StartPosition = FormStartPosition.CenterParent;

            // event handler for addAreaForm btnSaveArea click
            addAreaForm.SaveAreaClick += (s, area) =>
            {
                // add area to cboArea combobox
                cboArea.Items.Add(area);
            };

            addAreaForm.ShowDialog();
        }

        private void BtnBuyTicket_Click(object sender, EventArgs e)
        {
            // validate if totalPrice is greater than 0
            if (totalPrice > 0)
            {
                // validate txtCustomerName is not empty && txtCustomerPhone is not empty && rdbMale or rdbFemale is checked && cboCustomerType is selected
                if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) || (!radFemale.Checked && !radMale.Checked) || cboArea.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill in all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //MessageBox.Show($"You have successfully purchased tickets. Total amount: {totalPrice.ToString("C")}", "Purchase Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // reset all buttons in grbManHinh groupbox to white color
                foreach (Control control in grbManHinh.Controls.OfType<Button>().Where(s => s.BackColor == Color.Blue))
                {
                    control.BackColor = Color.Yellow;
                    control.Enabled = false;
                }
               
                // add customer information && ticket information to datagridview dgvBill
                dgvBill.Rows.Add(txtFullName.Text, txtPhone.Text, totalPrice.ToString("C"));

                totalPrice = 0;
                txtTotal.Text = totalPrice.ToString("C");
                //reset all input fields
                txtFullName.Clear();
                txtPhone.Clear();
                radMale.Checked = false;
                radFemale.Checked = false;
                cboArea.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Please select at least one seat to purchase.", "No Seats Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // loop through all buttons in the grbManHinh groupbox and reset their color to white
            foreach (Control control in grbManHinh.Controls.OfType<Button>().Where(s => s.BackColor == Color.Blue))
            {
                control.BackColor = Color.White;
            }
            totalPrice = 0;
            txtTotal.Text = totalPrice.ToString("C");
        }

        private void btnChooseSeats_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            // get button text as seat number
            int seatNumber = int.Parse(clickedButton.Text);

            if (clickedButton != null)
            {
                if (clickedButton.BackColor != Color.Blue)
                {
                    clickedButton.BackColor = Color.Blue;
                    totalPrice += GetServicePrice(seatNumber);
                }
                else
                {
                    clickedButton.BackColor = Color.White;
                    totalPrice -= GetServicePrice(seatNumber);
                }
            }
            txtTotal.Text = totalPrice.ToString("C");
        }

        private decimal GetServicePrice(int seatNumber)
        {
            // Example logic: Different seat numbers have different prices
            if (seatNumber >= 1 && seatNumber <= 5)
            {
                return 80000; // regular seats
            }
            else if (seatNumber >= 6 && seatNumber <= 10)
            {
                return 90000; // Deluxe seats
            }
            else if (seatNumber >= 11 && seatNumber <= 15)
            {
                return 100000; // Prinium seats
            }
            else
            {
                return 110000; // VIP seats
            }
        }

        
    }
}
