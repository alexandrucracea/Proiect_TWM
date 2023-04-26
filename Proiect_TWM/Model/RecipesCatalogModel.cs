using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_TWM.Model
{
    public class RecipesCatalogModel
    {
        public int Count { get; set; }
        public IEnumerable<RecipeInfoModel> Recipes { get; set; }
    }
}
