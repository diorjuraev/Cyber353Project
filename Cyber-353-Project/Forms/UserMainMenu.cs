﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO;

namespace Cyber_353_Project
{
    public partial class UserMainMenu : Form
    {
        public UserMainMenu()
        {
            InitializeComponent();
        }

        private void ScanBtn_Click(object sender, EventArgs e)
        {
            ActivityMonitor scan = new ActivityMonitor();
            scan.Show();
        }

        private void NetworkBtn_Click(object sender, EventArgs e)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())  // if no network is connected, then exit
            {
                return;
            }

            StreamWriter NetworkLog = new StreamWriter("NetworkLog.txt");

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface ni in interfaces)
            {
                NetworkLog.WriteLine(" Bytes Sent: {0}", ni.GetIPv4Statistics().BytesSent);
                NetworkLog.WriteLine(" Bytes Received: {0}", ni.GetIPv4Statistics().BytesReceived);
            }
        }

        private void RDBtn_Click(object sender, EventArgs e)
        {
            RemoteDesktopConnection rdp = new RemoteDesktopConnection();
            rdp.Show();
        }
    }
}