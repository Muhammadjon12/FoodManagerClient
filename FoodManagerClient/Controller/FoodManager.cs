using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodManagerClient.Model;

namespace FoodManagerClient.Controller
{
    class FoodManager
    {
        private Database.Database database = new Database.Database();

        public List<string> ReaderFoodTypes()

        {
            List<string> list = database.GetFoodTypes();
            return list;
        }
        public List<Food> ReaderAllFood(string name)
        {
            List<Food> getListFood = database.GetAllFood(name);
            return getListFood;
        }
    }
}
