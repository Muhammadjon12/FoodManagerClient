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
              foreach (var item in foodManager.getFoodsType())
            {
                listView1.Items.Add(item);
            }
        }

        private void BtnLossList_Click(object sender, EventArgs e)
        {
            listView3.CheckBoxes = true;
            foreach (ListViewItem Item in listView3.Items)
            {
                if (Item != null)
                {
                    if (Item.Checked)
                    {
                        listView3.Items.Remove(Item);
                        label3.Text = listView3.Items.Count.ToString();
                        TotalListSum();
                    }
                }
            }
        }

        private void ShowlistFoodsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexList;
            if (listView1.SelectedItems.Count > 0)
            {
                indexList = listView1.Items.IndexOf(listView1.SelectedItems[0]);
                indexList++;
                ShowList(indexList);
            }
        }
        public void ShowList(int index)
        {
            listView2.Clear();

            this.listView2.View = View.LargeIcon;
            this.listView2.LargeImageList = this.imageList1;
            listView2.LargeImageList.ImageSize = new Size(100, 100);

            foreach (var item in foodManager.getFoodsByType(index))
            {
                MemoryStream memStream = new MemoryStream(item.Image);
                this.imageList1.Images.Add(Image.FromStream(memStream));

                ListViewItem itm;

                string[] arr = new string[4];

                arr[0] = item.Name + "\n" + item.Price.ToString() + ".сом";
                arr[1] = item.Id.ToString();

                itm = new ListViewItem(arr);
                itm.ImageIndex = imageList1.Images.Count - 1;

                listView2.Items.Add(itm);
            }
        }

        private void showFoodslistView_Click(object sender, EventArgs e)
        {
            listView3.Columns.Clear();

            int id;

            listView3.View = View.Details;
            listView3.FullRowSelect = true;
            listView3.GridLines = true;

            listView3.Columns.Add("Name", 120);
            listView3.Columns.Add("Price", 50);

            id = int.Parse(listView2.SelectedItems[0].SubItems[1].Text);

          Model.Food hh=  foodManager.getFoodById(id);

           
                string[] mas = new string[2];

            mas[0] = hh.Name;
                mas[1] = hh.Price.ToString();

                ListViewItem listItem = new ListViewItem(mas);

                listView3.Items.Add(listItem);
         
            TotalListSum();
        }
        public void TotalListSum()
        {
            double sum = 0;
            foreach (ListViewItem item in listView3.Items)
            {
                sum += double.Parse(item.SubItems[1].Text);
            }
            label3.Text = listView3.Items.Count.ToString();
            label2.Text = sum.ToString();
        }
    }
}
