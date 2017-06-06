using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CitySearch;

namespace AXACodingEx
{
    public partial class Form1 : Form
    {
        CityFinderImplementation cityFinder = new CityFinderImplementation();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string query = textBox1.Text;
            
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            ICityResult citySearch = cityFinder.Search(query);

            foreach (var letter in citySearch.NextLetters)
                listBox2.Items.Add(letter);
            foreach (var city in citySearch.NextCities)
                listBox1.Items.Add(city);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
