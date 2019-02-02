// MIT License
// Copyright (c) 2009 Javier Cañon https://www.javiercanon.com
// https://github.com/JavierCanon/Shark.NET-Error-Reporter 
//
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Presenters.SystemInfo;

namespace WMITest
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
            txtMachine.Text = Environment.MachineName;
            FillCombobox(typeof (QueryArea));
        }

        private void FillCombobox(Type t)
        {
            FieldInfo[] fields = t.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                DescriptionAttribute[] objects =
                    fields[i].GetCustomAttributes(typeof (DescriptionAttribute), true) as DescriptionAttribute[];
                if (objects != null && objects.Length > 0)
                {
                    cbxQuery.Items.Add(new ComboObject(fields[i].Name, objects[0].Description));
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            btnQuery.Enabled = false;
            grdDisplay.SelectedObject = null;

            if (ValidateData())
            {
                try
                {
                    grdDisplay.SelectedObject = GetWmiObject();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnQuery.Enabled = true;
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtMachine.Text))
            {
                MessageBox.Show("Please provide machine name.", Application.ProductName, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtMachine.Focus();
                return false;
            }
            if (cbxQuery.SelectedIndex < 0)
            {
                MessageBox.Show("Please select query area.", Application.ProductName, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                cbxQuery.Focus();
                return false;
            }
            if ((string.Equals(txtMachine.Text.Trim(), ".", StringComparison.CurrentCultureIgnoreCase) ||
                 string.Equals(txtMachine.Text.Trim(), "LOCAL", StringComparison.CurrentCultureIgnoreCase) ||
                 string.Equals(txtMachine.Text.Trim(), Environment.MachineName, StringComparison.CurrentCultureIgnoreCase)) &&
                !(string.IsNullOrEmpty(txtUser.Text) && string.IsNullOrEmpty(txtPass.Text)))
            {
                MessageBox.Show("You cannot provide credential for localmachine.", Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private object GetWmiObject()
        {
            ComboObject item = cbxQuery.SelectedItem as ComboObject;
            if (item == null)
            {
                return null;
            }
            switch (item.DisplayText)
            {
                case "WMI_COMPUTER_INFORMATION":
                    return
                        WMIHelper.FillComputerInformation(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                                          txtPass.Text.Trim(), item.ValueText);
                case "WMI_PROCESSOR_INFORMATION":
                    return WMIHelper.FillProcessorInformation(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                                              txtPass.Text.Trim(), item.ValueText);
                case "WMI_BIOS_INFORMATION":
                    return WMIHelper.FillBiosInformation(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                                         txtPass.Text.Trim(), item.ValueText);
                case "WMI_OS_INFORMATION":
                    return WMIHelper.FillOSInformation(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                                       txtPass.Text.Trim(), item.ValueText);
                case "WMI_HOTFIX_INFORMATION":
                    return WMIHelper.FillHotFixes(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                                  txtPass.Text.Trim(), item.ValueText);
                case "WMI_NETWORK_ADAPTER_INFORMATION":
                    return WMIHelper.FillNetworkAdapter(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                                        txtPass.Text.Trim(), item.ValueText);
                case "WMI_PRINTER_INFORMATION":
                    return WMIHelper.FillPrinters(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                                  txtPass.Text.Trim(), item.ValueText);
                case "WMI_DISK_DRIVE_INFORMATION":
                    return WMIHelper.FillDisks(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                               txtPass.Text.Trim(), item.ValueText);
                case "WMI_LOGICAL_DISK_INFORMATION":
                    return WMIHelper.FillLogicalDisks(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                                      txtPass.Text.Trim(), item.ValueText);
                case "WMI_VIDEO_CONTROLLER_INFORMATION":
                    return WMIHelper.FillVideoController(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                                         txtPass.Text.Trim(), item.ValueText);
                case "WMI_SOUND_CARD_INFORMATION":
                    return WMIHelper.FillSoundCard(txtMachine.Text.Trim(), txtUser.Text.Trim(),
                                                   txtPass.Text.Trim(), item.ValueText);
            }
            return null;
        }
    }

    public class ComboObject
    {
        private string displayText;
        private string valueText;

        public ComboObject(string displayText, string valueText)
        {
            this.displayText = displayText;
            this.valueText = valueText;
        }

        public override string ToString()
        {
            return displayText;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            ComboObject o = obj as ComboObject;
            if (o != null)
            {
                return
                    string.Equals(o.DisplayText, DisplayText, StringComparison.CurrentCultureIgnoreCase) &&
                    string.Equals(o.ValueText, valueText, StringComparison.CurrentCultureIgnoreCase);
            }
            return base.Equals(obj);
        }

        public string DisplayText
        {
            get { return displayText; }
            set { displayText = value; }
        }

        public string ValueText
        {
            get { return valueText; }
            set { valueText = value; }
        }
    }
}