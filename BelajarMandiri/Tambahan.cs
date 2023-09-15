using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TugasMcc
{
    public class Tambahan
    {
        public void awal()
        {
            Cons tambah = new Cons();

            Console.Write("Masukkan Nama : ");
            string n = Console.ReadLine();
            //n berisi nama anton
            tambah.UserBiasa(n);

        }
    
    }

}
