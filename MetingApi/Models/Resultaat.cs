using Project.Models;

namespace MetingApi.Models
{
    public class Resultaat
    {
        #region Properties
        public int Id { get; set; }

        public string Type { get; set; }

        public double? Amount { get; set; }
        #endregion

        #region Constructors
        public Resultaat(string type, double? amount = null)
        {
            Type = type;
            Amount = amount;
        }
        #endregion
    }
}