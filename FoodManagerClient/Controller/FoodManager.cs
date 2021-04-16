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
        public List<string> getFoodsType()
        {
            List<string> list = database.getFoodsType();
            return list;
        }
        public List<Food> getFoodsByType(int Id)
        {
            List<Food> getListFood = database.GetFoodsByType(Id);
            return getListFood;
        }
        public Food getFoodById(int Id)
        {
            Food getListFood = database.GetFoodByID(Id);
            return getListFood;
        }
    }
}
