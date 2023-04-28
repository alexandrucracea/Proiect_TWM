using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_TWM.Model.ApiResponse
{
    public class ApiPlantListResponseModel
    {
        public IEnumerable<ApiPlantInfoResponseModel> Plants { get; set; }
    }
}
