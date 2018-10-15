using System;
using System.Windows.Forms;

namespace PosChecker
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//hide on load and start timer
		private void Form1_Load(object sender, EventArgs e)
		{
			System.Drawing.Rectangle totalSize = System.Drawing.Rectangle.Empty;
			foreach (System.Windows.Forms.Screen s in System.Windows.Forms.Screen.AllScreens)
				totalSize = System.Drawing.Rectangle.Union(totalSize, s.Bounds);

			this.Width = totalSize.Width;
			this.Left = totalSize.Left;
			this.Top = totalSize.Top;

		    Show();
		    this.WindowState = FormWindowState.Normal;
		    notifyIcon.Visible = false;

            var timer = new Timer();
			timer.Interval = 1200000;
			timer.Tick += timer_Tick;
			timer.Start();
		}

		//reshow
		private void timer_Tick(object sender, EventArgs e)
		{
			Show();  
			this.WindowState = FormWindowState.Normal;  
			notifyIcon.Visible = false;  
		}

		private void Form1_Clicked(object sender, MouseEventArgs e)
		{
			WindowState = FormWindowState.Minimized;
			Hide();
			notifyIcon.Visible = true;
		}

		//back from tray
		private void notifyIcon_MouseClick(object sender, MouseEventArgs e)  
		{  
		     Show();  
		     this.WindowState = FormWindowState.Normal;  
		     notifyIcon.Visible = false;  
		} 
	}
}