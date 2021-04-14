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
        public List<Food> ReaderTypesFoodById(int Id)
        {
            List<Food> getListFood = database.GetTypesFoodById(Id);
            return getListFood;
        }
        public List<Food> ReaderAllFoodById(int Id)
        {
            List<Food> getListFood = database.GetAllFoodByID(Id);
            return getListFood;
        }
    }
}
