using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using Gizmox.Controls;
using JDataEngine;
using JurisAuthenticator;
using JurisUtilityBase.Properties;
using System.Data.OleDb;

namespace JurisUtilityBase
{
    public partial class UtilityBaseMain : Form
    {
        #region Private  members

        private JurisUtility _jurisUtility;

        #endregion

        #region Public properties

        public string CompanyCode { get; set; }

        public string JurisDbName { get; set; }

        public string JBillsDbName { get; set; }

        private bool includeInactive = false;

        private string venKeep = "";

        private string venDelete = "";

        private string sepChecks = "";

        private List<VendorCodeToID> venList = new List<VendorCodeToID>();

        #endregion

        #region Constructor

        public UtilityBaseMain()
        {
            InitializeComponent();
            _jurisUtility = new JurisUtility();
        }

        #endregion

        #region Public methods

        public void LoadCompanies()
        {
            venKeep = "";
            venDelete = "";
            var companies = _jurisUtility.Companies.Cast<object>().Cast<Instance>().ToList();
//            listBoxCompanies.SelectedIndexChanged -= listBoxCompanies_SelectedIndexChanged;
            listBoxCompanies.ValueMember = "Code";
            listBoxCompanies.DisplayMember = "Key";
            listBoxCompanies.DataSource = companies;
//            listBoxCompanies.SelectedIndexChanged += listBoxCompanies_SelectedIndexChanged;
            var defaultCompany = companies.FirstOrDefault(c => c.Default == Instance.JurisDefaultCompany.jdcJuris);
            if (companies.Count > 0)
            {
                listBoxCompanies.SelectedItem = defaultCompany ?? companies[0];
            }
        }

        #endregion

        #region MainForm events

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listBoxCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_jurisUtility.DbOpen)
            {
                _jurisUtility.CloseDatabase();
            }
            CompanyCode = "Company" + listBoxCompanies.SelectedValue;
            _jurisUtility.SetInstance(CompanyCode);
            JurisDbName = _jurisUtility.Company.DatabaseName;
            JBillsDbName = "JBills" + _jurisUtility.Company.Code;
            _jurisUtility.OpenDatabase();
            if (_jurisUtility.DbOpen)
            {
                ///GetFieldLengths();
            }


            populateDropDowns();



        }



        #endregion

        #region Private methods

        private void DoDaFix()
        {
            // Enter your SQL code here
            // To run a T-SQL statement with no results, int RecordsAffected = _jurisUtility.ExecuteNonQueryCommand(0, SQL);
            // To get an ADODB.Recordset, ADODB.Recordset myRS = _jurisUtility.RecordsetFromSQL(SQL);
            if (!string.IsNullOrEmpty(venKeep) && !string.IsNullOrEmpty(venDelete))
            {
                DialogResult rs = MessageBox.Show("This will merge all transactions and data from vendor: "+ venDelete + " into" + "\r\n" + 
                                "vendor: " + venKeep + ". Vendor: " + venDelete + " will be deleted. Continue?", "Confirmation" ,MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == System.Windows.Forms.DialogResult.Yes)
                {
                    DataSet ds1 = new DataSet();
                    String SQL = "";


                    //we need ot find those ids in the list based on the formatted code
                    var id = venList.First(a => a.code == venKeep);
                    var id1 = venList.First(a => a.code == venDelete);
                    string venKeepID = id.ID;
                    string venDeleteID = id1.ID;

                    if (!radioButtonKeep.Checked) //if they chose to force the separate check setting
                    {
                        if (!string.IsNullOrEmpty(sepChecks))
                        {
                            SQL = "update vendor set " + sepChecks + " where vensysnbr = " + venKeepID;
                            _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                        }

                    }
                        SQL = "update voucher set vchvendor=" + venKeepID + " where vchvendor=" + venDeleteID;

                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                        UpdateStatus("Updated Vouchers.", 1, 9);

                        SQL = "update checkregister set ckregvend=" + venKeepID + " where ckregvend=" + venDeleteID;

                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                        UpdateStatus("Updated Check Register.", 2, 9);

                        SQL = "update voucherbatchdetail set vbdvendor=" + venKeepID + " where vbdvendor=" + venDeleteID;

                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                        UpdateStatus("Updated Voucher Batch Detail.", 3, 9);

                        SQL = "update vennote set vnvendor=" + venKeepID + " where vnvendor=" + venDeleteID;

                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                        UpdateStatus("Updated Vendor Note.", 4, 9);

                        SQL = "update matdisbhistory set mdhvendor=" + venKeepID + "where mdhvendor=" + venDeleteID;

                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                        UpdateStatus("Updated Mat Disb History.", 5, 9);

                        //ven1099
                        SQL = "SELECT  [V99Year] ,cast(sum([V99AmountPaid]) as decimal(20,2)) as paid ,cast(sum(V99SupplementAmount) as decimal(20,2)) as supp FROM [Ven1099] where V99Vendor = " + venDeleteID + " or V99Vendor = " + venKeepID + " group by V99Year";

                        ds1 = _jurisUtility.ExecuteSqlCommand(0, SQL);
                        foreach (DataRow r in ds1.Tables[0].Rows)
                        
                           { SQL = "update Ven1099 set V99AmountPaid = " + r[1].ToString() + ", V99SupplementAmount = " + r[2].ToString() + " where V99Year = " + r[0].ToString() + " and V99Vendor = " + venKeepID;
                            _jurisUtility.ExecuteNonQueryCommand(0, SQL); }
                      

                        //Update ven1099 settings based of selection
                        if (radioButton4.Checked== true)
                    { SQL = "update vendor set ven1099Box=del1099 from (select ven1099Box as del1099, vensysnbr as OldVen from vendor where vensysnbr=" + venDeleteID + ")DV where vensysnbr= " + venKeepID ;
                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                    }
                    

                        //vensumbyprd
                        SQL = "SELECT  [VSPPrdYear],[VSPPrdNbr],cast(sum([VSPVouchers]) as decimal(20,2)) as vouch,cast(sum([VSPPayments]) as decimal(20,2)) as pymt,cast(sum([VSPDiscountsTaken]) as decimal(20,2)) as disc FROM [VenSumByPrd] where VSPVendor = " + venDeleteID + " or vspvendor=" + venKeepID + " group by VSPPrdYear, VSPPrdNbr order by VSPPrdYear, VSPPrdNbr";
                        ds1.Clear();

                        ds1 = _jurisUtility.ExecuteSqlCommand(0, SQL);
                        foreach (DataRow r in ds1.Tables[0].Rows)
                        {
                        SQL = "SELECT vspprdyear, vspprdnbr, vspvendor from VenSumByPrd where VSPPrdYear = " + r["VSPPrdYear"].ToString() + " and VSPVendor = " + venKeepID + " and VSPPrdNbr = " + r["VSPPrdNbr"].ToString();
                          DataSet d2 = _jurisUtility.ExecuteSqlCommand(0, SQL);
                        if (d2.Tables[0].Rows.Count == 0)
                        { SQL = "Insert into VenSumbyPrd(vspvendor, vspprdyear, vspprdnbr, vspvouchers, vsppayments, vspdiscountstaken) values(" + venKeepID + "," + r["VSPPrdYear"].ToString() + "," + r["VSPPrdNbr"].ToString() + "," + r["vouch"].ToString() + "," + r["pymt"].ToString() + "," + r["disc"].ToString() + ")";
                            _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                        }
                        else
                        {
                            SQL = "update VenSumByPrd set VSPVouchers = " + r["vouch"].ToString() + ", VSPPayments = " + r["pymt"].ToString() + ", VSPDiscountsTaken = " + r["disc"].ToString() + " where VSPPrdYear = " + r["VSPPrdYear"].ToString() + " and VSPVendor = " + venKeepID + " and VSPPrdNbr = " + r["VSPPrdNbr"].ToString() ;
                            _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                        }
                        }

                        UpdateStatus("Updated 1099 and Vendor Sum By Period.", 6, 9);

                        ds1.Clear();

                        //delete records
                        SQL = "delete from ven1099 where V99Vendor = " + venDeleteID;

                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);

                        SQL = "delete from VenSumbyprd where VSPVendor = " + venDeleteID;

                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);

                        SQL = "delete from vendor where VenSysNbr = " + venDeleteID;

                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);

                        UpdateStatus("Removing old records.", 7, 9);

                        //updte doctree
                        SQL = "Delete from documenttree where  dtdocclass=7000 and dtkeyl=" + venDeleteID;

                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);

                        UpdateStatus("Updated DocTree.", 8, 9);

                        UpdateStatus("Process Complete.", 9, 9);

                        venDelete = "";
                        venKeep = "";
                        venList.Clear();
                        cbKeep.SelectedIndex = -1;
                        cbDelete.SelectedIndex = -1;

                        MessageBox.Show("The process is complete", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.None);
                        try
                        {
                            System.Environment.Exit(1);
                        }
                        catch (Exception ex11)
                        {
                            this.Close();
                        }
                }
            }
            else
                MessageBox.Show("Please select a vendor from both drop downs","Selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void populateDropDowns()
        {
            string TkprIndex;
            cbKeep.ClearItems();
            string SQLTkpr = "select dbo.jfn_FormatVendorCode(vencode) + ' ' + venname as vendor, dbo.jfn_FormatVendorCode(vencode) as vencode, VenSysNbr as ID from vendor";
            if (!includeInactive)
                SQLTkpr = SQLTkpr + " where VenActive='Y' order by vencode";
            else
                if (includeInactive)
                    SQLTkpr = SQLTkpr + " order by vencode";
            DataSet myRSTkpr = _jurisUtility.RecordsetFromSQL(SQLTkpr);

            if (myRSTkpr.Tables[0].Rows.Count == 0)
                cbKeep.SelectedIndex = 0;
            else
            {
                foreach (DataTable table in myRSTkpr.Tables)
                {

                    foreach (DataRow dr in table.Rows)
                    {
                        TkprIndex = dr["vendor"].ToString();
                        cbKeep.Items.Add(TkprIndex);
                        VendorCodeToID v = new VendorCodeToID(); //keep a list of all formatted codes and their associated ids
                        v.code = dr["vencode"].ToString();
                        v.ID = dr["ID"].ToString();
                        venList.Add(v);
                    }
                }

            }

            string TkprIndex2;
            cbDelete.ClearItems();
            string SQLTkpr2 = "select dbo.jfn_FormatVendorCode(vencode) + ' ' + venname as vendor, dbo.jfn_FormatVendorCode(vencode) as vencode, VenSysNbr as ID from vendor";
            if (!includeInactive)
                SQLTkpr2 = SQLTkpr2 + " where VenActive='Y' order by vencode";
            else
                if (includeInactive)
                    SQLTkpr2 = SQLTkpr2 + " order by vencode";
            DataSet myRSTkpr2 = _jurisUtility.RecordsetFromSQL(SQLTkpr2);


            if (myRSTkpr2.Tables[0].Rows.Count == 0)
                cbDelete.SelectedIndex = 0;
            else
            {
                foreach (DataTable table in myRSTkpr2.Tables)
                {

                    foreach (DataRow dr in table.Rows)
                    {
                        TkprIndex2 = dr["vendor"].ToString();
                        cbDelete.Items.Add(TkprIndex2);
                    }
                }

            }
        }


        private bool VerifyFirmName()
        {
            //    Dim SQL     As String
            //    Dim rsDB    As ADODB.Recordset
            //
            //    SQL = "SELECT CASE WHEN SpTxtValue LIKE '%firm name%' THEN 'Y' ELSE 'N' END AS Firm FROM SysParam WHERE SpName = 'FirmName'"
            //    Cmd.CommandText = SQL
            //    Set rsDB = Cmd.Execute
            //
            //    If rsDB!Firm = "Y" Then
            return true;
            //    Else
            //        VerifyFirmName = False
            //    End If

        }

        private bool FieldExistsInRS(DataSet ds, string fieldName)
        {

            foreach (DataColumn column in ds.Tables[0].Columns)
            {
                if (column.ColumnName.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }


        private static bool IsDate(String date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum; 
        }

        private void WriteLog(string comment)
        {
            var sql =
                string.Format("Insert Into UtilityLog(ULTimeStamp,ULWkStaUser,ULComment) Values('{0}','{1}', '{2}')",
                    DateTime.Now, GetComputerAndUser(), comment);
            _jurisUtility.ExecuteNonQueryCommand(0, sql);
        }

        private string GetComputerAndUser()
        {
            var computerName = Environment.MachineName;
            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var userName = (windowsIdentity != null) ? windowsIdentity.Name : "Unknown";
            return computerName + "/" + userName;
        }

        /// <summary>
        /// Update status bar (text to display and step number of total completed)
        /// </summary>
        /// <param name="status">status text to display</param>
        /// <param name="step">steps completed</param>
        /// <param name="steps">total steps to be done</param>
        private void UpdateStatus(string status, long step, long steps)
        {
            labelCurrentStatus.Text = status;

            if (steps == 0)
            {
                progressBar.Value = 0;
                labelPercentComplete.Text = string.Empty;
            }
            else
            {
                double pctLong = Math.Round(((double)step/steps)*100.0);
                int percentage = (int)Math.Round(pctLong, 0);
                if ((percentage < 0) || (percentage > 100))
                {
                    progressBar.Value = 0;
                    labelPercentComplete.Text = string.Empty;
                }
                else
                {
                    progressBar.Value = percentage;
                    labelPercentComplete.Text = string.Format("{0} percent complete", percentage);
                }
            }
        }

        private void DeleteLog()
        {
            string AppDir = Path.GetDirectoryName(Application.ExecutablePath);
            string filePathName = Path.Combine(AppDir, "VoucherImportLog.txt");
            if (File.Exists(filePathName + ".ark5"))
            {
                File.Delete(filePathName + ".ark5");
            }
            if (File.Exists(filePathName + ".ark4"))
            {
                File.Copy(filePathName + ".ark4", filePathName + ".ark5");
                File.Delete(filePathName + ".ark4");
            }
            if (File.Exists(filePathName + ".ark3"))
            {
                File.Copy(filePathName + ".ark3", filePathName + ".ark4");
                File.Delete(filePathName + ".ark3");
            }
            if (File.Exists(filePathName + ".ark2"))
            {
                File.Copy(filePathName + ".ark2", filePathName + ".ark3");
                File.Delete(filePathName + ".ark2");
            }
            if (File.Exists(filePathName + ".ark1"))
            {
                File.Copy(filePathName + ".ark1", filePathName + ".ark2");
                File.Delete(filePathName + ".ark1");
            }
            if (File.Exists(filePathName ))
            {
                File.Copy(filePathName, filePathName + ".ark1");
                File.Delete(filePathName);
            }

        }

            

        private void LogFile(string LogLine)
        {
            string AppDir = Path.GetDirectoryName(Application.ExecutablePath);
            string filePathName = Path.Combine(AppDir, "VoucherImportLog.txt");
            using (StreamWriter sw = File.AppendText(filePathName))
            {
                sw.WriteLine(LogLine);
            }	
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DoDaFix();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {

            System.Environment.Exit(0);
          
        }


        private void cbKeep_SelectedIndexChanged(object sender, EventArgs e)
        {
            venKeep = cbKeep.Text.Split(' ')[0];
            cbDelete.Enabled = true;
        }

        private void cbDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            venDelete = cbDelete.Text.Split(' ')[0];
            button1.Enabled = true;
        }

        private void radioButtonActiveOnly_CheckedChanged(object sender, EventArgs e)
        {
            includeInactive = false;
            cbKeep.Enabled = true;
            populateDropDowns();
        }

        private void radioButtonInactive_CheckedChanged(object sender, EventArgs e)
        {
            includeInactive = true;
            cbKeep.Enabled = true;
            populateDropDowns();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonSCYes_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSCYes.Checked)
                sepChecks = " VenSeparateCheck = 'Y' ";
        }

        private void radioButtonSCNo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSCNo.Checked)
                sepChecks = " VenSeparateCheck = 'N' ";
        }

        private void radioButtonKeep_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonKeep.Checked)
                sepChecks = "";
        }
    }
}
