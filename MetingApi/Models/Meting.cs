using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MetingApi.Models
{
    public class Meting
    {
        #region Properties
        public enum Type
        {
            Stresstest,
            Gelukkigheidstest,
            Gezondheidstest
        }

        public int Id { get; set; }

        public DateTime Created { get; set; }

        public User User { get; set; }

        public ICollection<Resultaat> Resultaten { get; set; }
        #endregion

        #region Constructors
        public Meting()
        {
            Resultaten = new List<Resultaat>();
            Created = DateTime.Now;
        }

        #endregion

        #region Methods
        public void AddResultaat(Resultaat resultaat) => Resultaten.Add(resultaat);

        public Resultaat GetResultaat(int id) => Resultaten.SingleOrDefault(i => i.Id == id);



        public Resultaat BerekenStresstest(int antwoord1, int antwoord2, int antwoord3)     //de berekening van het resultaat dmv de ingevulde antwoorden
        {
            Resultaat res = new Resultaat(Type.Stresstest.ToString());
            //formule..
            double ber = 0;

            //einde formule
            res.Amount = ber;
            return res;
        }
        public Resultaat BerekenGelukkigheidstest(int antwoord1, int antwoord2, int antwoord3)     //de berekening van het resultaat dmv de ingevulde antwoorden
        {
            Resultaat res = new Resultaat(Type.Gelukkigheidstest.ToString());
            //formule..
            double ber = 0;

            //einde formule
            res.Amount = ber;
            return res;
        }
        public Resultaat BerekenGezondheidstest(int antwoord1, int antwoord2, int antwoord3)     //de berekening van het resultaat dmv de ingevulde antwoorden
        {
            Resultaat res = new Resultaat(Type.Gezondheidstest.ToString());
            //formule..
            double ber = 0;

            //einde formule
            res.Amount = ber;
            return res;
        }
        #endregion


    }
}