using SocketIOClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketIO_impl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sendbtn_Click(object sender, EventArgs e)
        {
            if (msgtxtbox.Text == "")
                return;
            String msg = msgtxtbox.Text.ToString();
            Program.emit(msg);
            msgtxtbox.Text = "";
        }
        public void update(String msg)
        {
            if (rxtxtbox.InvokeRequired)
                rxtxtbox.Invoke(new Action(() => rxtxtbox.Text += msg + Environment.NewLine));
            rxtxtbox.Invoke(new Action(() => rxtxtbox.SelectionStart = rxtxtbox.Text.Length));
            rxtxtbox.Invoke(new Action(() => rxtxtbox.ScrollToCaret()));

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.disco();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://aravindvs.com");
        }

        private void rxtxtbox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}