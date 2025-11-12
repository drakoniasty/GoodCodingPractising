using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Singleton
{
    internal class Vault
    {
        private static string vault;
        
        private static Vault vaultInstance;
        private static object locker = new object();
        private Vault()
        {
            vault = StworzKlucz();
        }
        public static Vault Instance
        {
            get
            {
                lock (locker)
                {
                    if (vaultInstance == null)
                    {
                        vaultInstance = new Vault();
                    }
                    else
                    {
                        vaultInstance = vaultInstance;
                    }
                }

                return vaultInstance;
            }
        }
        private static string StworzKlucz()
        {
            return "n8£AeJU107eX";
        }


    }
}
