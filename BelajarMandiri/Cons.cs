using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasMcc
{
    public class Cons
    {
        public string Nama { get; set; }

        public Cons() { }
        public Cons(string tambahNama)
        {
            Nama = tambahNama;
        }

        public void UserMetrodata(string tambahNama)
        {
            string namaSpesial = tambahNama + "Metrodata";
        }

        public string UserBiasa(string tambahNama)
        {
            string namaSpesial = tambahNama + "Biasa";
            return namaSpesial;
        }
    }
}
