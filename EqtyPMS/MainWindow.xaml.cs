using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EqtyPMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            GetTradesData();
            GetTransactionsData();
            GetPositionsData();

            txtSecurityCode.Text = String.Empty;
            txtQuantity.Text = String.Empty;
            cmbOperation.SelectedIndex = -1;
            cmbSide.SelectedIndex = -1;
            txtSecurityCode.Focus();
        }

        private void btnRefreshData_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void GetTradesData()
        {
            try
            {
                var svcClient = new PMSReference.ServiceClient();
                DataSet ds = svcClient.GetSQLData("Select TradeID, SecurityCode, Side From Trades");
                dgTrades.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured while Get Trades Data.\n\n" + ex.ToString());
            }
        }

        private void GetTransactionsData()
        {
            try
            {
                var svcClient = new PMSReference.ServiceClient();
                DataSet ds = svcClient.GetSQLData("SELECT * FROM ViewTransactionsData ORDER BY TransactionID");
                dgTransactions.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured while Get Transactions Data.\n\n" + ex.ToString());
            }
        }

        private void GetPositionsData()
        {
            try
            {
                var svcClient = new PMSReference.ServiceClient();
                DataSet ds = svcClient.GetSQLData("SELECT * FROM ViewPositionsData");
                dgPositions.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured while Get Positions Data.\n\n" + ex.ToString());
            }
        }

        private void btnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputData())
            {
                TransactionData transData = new TransactionData();
                int quantity = 0;
                int.TryParse(txtQuantity.Text, out quantity);
                transData.Quantity = quantity;

                transData.SecurityCode = txtSecurityCode.Text;
                transData.Operation = cmbOperation.SelectionBoxItem.ToString();
                transData.Side = cmbSide.SelectionBoxItem.ToString();

                var svcClient = new PMSReference.ServiceClient();
                bool isSuccess = svcClient.InsertTransactionData("InsertTransactionDetails", quantity, transData.SecurityCode, transData.Operation, transData.Side);

                RefreshData();

            }



        }

        private bool ValidateInputData()
        {
            bool isInValid = false;
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrEmpty(txtSecurityCode.Text))
            {
                isInValid = true;
                errorMessage.AppendLine("Please enter Security Code.");
            }

            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                isInValid = true;
                errorMessage.AppendLine("Please enter Quantity.");
            }
            else
            {
                int quantity = 0;
                if (!int.TryParse(txtQuantity.Text, out quantity))
                {
                    isInValid = true;
                    errorMessage.AppendLine("Please enter valid Quantity.");
                }
            }

            if (cmbOperation.SelectedIndex == -1)
            {
                isInValid = true;
                errorMessage.AppendLine("Please Select Operation.");
            }

            if (cmbSide.SelectedIndex == -1)
            {
                isInValid = true;
                errorMessage.AppendLine("Please Select Side.");
            }

            if (errorMessage.Length > 0)
            {
                MessageBox.Show("*** Validations failed: \n\n" + errorMessage.ToString(), "Position Management System", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            return isInValid;
        }

    }

    public class TransactionData
    {
        public int TransactionID { get; set; }
        public int TradeID { get; set; }
        public int Version { get; set; }
        public string SecurityCode { get; set; }
        public int Quantity { get; set; }
        public string Operation { get; set; }
        public string Side { get; set; }

    }
}
