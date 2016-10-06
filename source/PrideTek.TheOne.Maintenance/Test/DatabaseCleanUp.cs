using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrideTek.TheOne.ClientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.TheOne.Maintenance.Test
{

    [TestClass]
    public class FunctionalTest
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            using (var db = new DataContext())
            {
                if (db.Database.Exists())
                    db.Database.Delete();

                db.Database.Create();
            }
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            using (var db = new DataContext())
            {
                if (db.Database.Exists())
                    db.Database.Delete();
            }
        }
    }
}
