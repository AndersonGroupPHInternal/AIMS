using BaseModel;

namespace AIMS.Models
{
    public class Location : Base
    {
        public int LocationID { get; set; }

        public string LocationAddress { get; set; }
        public string LocationName { get; set; }
    }
}