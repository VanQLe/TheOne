using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrideTek.TheOne.ClientServices;

namespace PrideTek.TheOne.Maintenance.Test
{
    [TestClass]
    public class DataScenarioTest
    {
        [TestMethod]
        public void CanCreateDatabase()
        {
            using (var db = new DataContext())
            {
                db.Database.Create();
            }
        }

        [ClassCleanup]
        public static void classcleanup()
        {
            using (var db = new DataContext())
            {
                if (db.Database.Exists())
                {
                    db.Database.Delete();
                }
            }
        }
    }
}
