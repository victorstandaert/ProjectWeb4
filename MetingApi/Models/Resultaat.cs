using Project.Models;

namespace MetingApi.Models
{
    public class Resultaat
    {
        #region Properties
        public int Id { get; set; }

        public string Vraag { get; set; }

        public double? Amount { get; set; }
        #endregion

        #region Constructors
        public Resultaat(string vraag, double? amount = null)
        {
            Vraag = vraag;
            Amount = amount;
        }
        #endregion
    }
}