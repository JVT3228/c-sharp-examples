using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.lsp
{
    #region Wrong
    internal class Example
    {
        private class Utka
        {
            public virtual void Kryakat()
            {
                Console.WriteLine("Я крякаю");
            }

            public virtual void Letat()
            {
                Console.WriteLine("Я летаю");
            }
        }

        // ТИМУР ПРОИЗНЕСИ ЭТО КАК "НЫРЯЮЩАЯ"
        private class NyryayuschayaUtka : Utka
        {

            public override void Kryakat()
            {
                Console.WriteLine("КРЯЯЯЯЯ!!!!");
            }
            public override void Letat()
            {
                Console.WriteLine("Как-то летаю, всё ок");
            }
            public virtual void Nyrnut()
            {
                Console.WriteLine("Look at my ass");
            }
        }

        private class KiborgUtka : Utka
        {
            public override void Kryakat()
            {
                Console.WriteLine("BEEP");
            }
            public override void Letat()
            {
                throw new Exception("Я НЕ УМЕЮ ЛЕТАТЬ!!!");
            }
        }
    }
    #endregion

    #region Correct
    internal class CoolerExample
    {
        private interface ILetat
        {
            public void Letat();
        }
        private class Utka
        {
            public virtual void Kryakat()
            {
                Console.WriteLine("Я крякаю");
            }
        }

        private class NyryayuschayaUtka : Utka, ILetat
        {

            public override void Kryakat()
            {
                Console.WriteLine("КРЯЯЯЯЯ!!!!");
            }
            public void Letat()
            {
                Console.WriteLine("Как-то летаю, всё ок");
            }
            public virtual void Nyrnut()
            {
                Console.WriteLine("Look at my ass");
            }
        }

        private class KiborgUtka : Utka
        {
            public override void Kryakat()
            {
                Console.WriteLine("BEEP");
            }
            public void DoLaser()
            {
                Console.WriteLine("вы умерли...");
            }
        }
    }
    #endregion
}
