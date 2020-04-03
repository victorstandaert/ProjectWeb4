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
        //public enum Vragen
        //{
        //    Vraag1,
        //    Vraag2,
        //    Vraag3,
        //    Vraag4
        //    //...
        //}

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



        public Resultaat BerekenResultaatVraag1(int antwoord) 
        {
            Resultaat res = new Resultaat(Vragen.Vraag1.ToString());
            //formule..
            double berekening = 0;

            //einde formule
            res.Amount = berekening;
            return res;
        }
        public Resultaat BerekenResultaatVraag2(int antwoord)
        {
            Resultaat res = new Resultaat(Vragen.Vraag2.ToString());
            //formule..
            double berekening = 0;

            //einde formule
            res.Amount = berekening;
            return res;
        }
        public Resultaat BerekenResultaatVraag3(int antwoord)
        {
            Resultaat res = new Resultaat(Vragen.Vraag3.ToString());
            //formule..
            double berekening = 0;

            //einde formule
            res.Amount = berekening;
            return res;
        }
        //...

        public double BerekenEindresultaat(Resultaat res1, Resultaat res2, Resultaat res3)
        {
            //formule..
            double berekening = 0;

            //einde formule
            return berekening;
        }
        #endregion


    }
}