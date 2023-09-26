using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Member
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int NomorKeanggotaan { get; set; }

public Member(string name, string address)
    {
        Name = name;
        Address = address;
    }

}


