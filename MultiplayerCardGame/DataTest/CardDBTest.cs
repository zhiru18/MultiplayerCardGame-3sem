using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;
using Server.Model.Model;

namespace Tests.DataTest
{
    [TestClass]
    public class CardDBTest
    {
        CardDB cardDB;
        [TestMethod]
        public void GetAllTest()
        {
            cardDB = new CardDB();
            List<Card> cards = (List<Card>)cardDB.GetAll();
            Assert.IsTrue(cards.Count > 0);
        }
    
    }
}
