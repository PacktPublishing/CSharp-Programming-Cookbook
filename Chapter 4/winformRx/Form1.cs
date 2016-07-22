using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace winformRx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Chapter 4 - Recipe 2 - Using LINQ to perform queries
            //var searchTerm = Observable.FromEventPattern<EventArgs>(textBox1, "TextChanged")
            //.Select(x => ((TextBox)x.Sender).Text)
            //.Where(text => text.EndsWith("."));

            //searchTerm.Subscribe(trm => label1.Text = trm); 
            #endregion

            #region Chapter 4 - Recipe 3 - Using Schedulers in Reactive Extensions
            //var searchTerm = Observable.FromEventPattern<EventArgs>(textBox1, "TextChanged")
            //.Select(x => ((TextBox)x.Sender).Text)
            //.Throttle(TimeSpan.FromMilliseconds(5000));

            ////searchTerm.Subscribe(trm => label1.Text = trm);
            //searchTerm.ObserveOn(new ControlScheduler(this)).Subscribe(trm => label1.Text = trm); 
            #endregion
            
            #region Chapter 4 - Recipe 4 - Debugging Lambda Expressions
            //List<CSharpSix> FavCSharpFeatures = new List<CSharpSix>();
            //CSharpSix feature1 = new CSharpSix();
            //feature1.FavoriteFeature = "String Interpolation";
            //FavCSharpFeatures.Add(feature1);

            //CSharpSix feature2 = new CSharpSix();
            //feature2.FavoriteFeature = "Exception Filters";
            //FavCSharpFeatures.Add(feature2);

            //CSharpSix feature3 = new CSharpSix();
            //feature3.FavoriteFeature = "Nameof Expressions";
            //FavCSharpFeatures.Add(feature3);

            //var filteredFeature = FavCSharpFeatures.Where(feature =>
            //feature.FavoriteFeature.StartsWith("Ex")); 
            #endregion            
        }
    }

    public class CSharpSix
    {
        public string FavoriteFeature { get; set; }
    }
}
