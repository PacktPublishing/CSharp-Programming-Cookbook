using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            #region Recipe 1 - Return Types of Asynchronous Functions
            //Console.WriteLine("Button Clicked");
            //Chapter6.AsyncDemo oAsync = new Chapter6.AsyncDemo();
            //await oAsync.LongTask();
            //Console.WriteLine("Button Click Ended"); 
            #endregion

            #region Recipe 2 - Handling tasks in Asynchronous programming
            //Console.WriteLine("Start file read");
            //Chapter6.AsyncDemo oAsync = new Chapter6.AsyncDemo();
            //int readResult = await oAsync.ReadBigFile();
            //Console.WriteLine("Bytes read = " + readResult); 
            #endregion
            
            #region Recipe 3 - Exception Handling in Asynchronous Programming
            Console.WriteLine("Read backup file");
            Chapter6.AsyncDemo oAsync = new Chapter6.AsyncDemo();
            int readResult = await oAsync.ReadLogFile();
            Console.WriteLine("Bytes read = " + readResult); 
            #endregion

        }        
    }
}
