using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FoodManagerClient
{
    public partial class Form1 : Form
    {
        Controller.FoodManager foodManager = new Controller.FoodManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in foodManager.ReaderFoodTypes())
            {
                listView1.Items.Add(item);
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int i in listView1.SelectedIndices)
            {
                ShowList(listView1.Items[i].Text);
            }
        }
        public void ShowList(string name)
        {
            double price = 0;

            listView2.Clear();
            this.listView2.View = View.LargeIcon;
            this.listView2.LargeImageList = this.imageList1;
            listView2.LargeImageList.ImageSize = new Size(100, 100);

            listView2.CheckBoxes = true;

            foreach (var item in foodManager.ReaderAllFood(name))
            {
                MemoryStream memStream = new MemoryStream(item.Image);
                this.imageList1.Images.Add(Image.FromStream(memStream));

                ListViewItem liv = new ListViewItem();

                liv.ImageIndex = imageList1.Images.Count - 1;

                liv.Text = "Ном: " + item.Name + "\n Нарх: " + item.Price + ".смн";

                price += item.Price;

                this.listView2.Items.Add(liv);
            }

            label1.Text = price.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
