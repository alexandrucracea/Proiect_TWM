
using SQLite;

namespace Proiect_TWM.Model
{
    public class PersonalPlantsModel
    {
        public string Name { get; set; }
        public string Img { get; set; } = default;
        public string Family { get; set; }
        public string Description { get; set; }
        public string Climat { get; set; } = default;
    }
}
