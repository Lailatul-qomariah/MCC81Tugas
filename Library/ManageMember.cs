using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library
{
    public class ManageMember
    {
        List<Member> members = new List<Member>();
        public static ManageMember manageMember  = new ManageMember();
        ErrorHandlerMember errorHandler = new ErrorHandlerMember();


        public void AddMember(Member member)
        {
            if (!errorHandler.HandleMemberError(member.Name, member.Address))
            {
                return;
            }

            int idMember = 1; // Menentukan ID berikutnya
            if (members.Count > 0)
            {
                idMember = members.Max(m => m.NomorKeanggotaan) + 1;
            }

            // Mengecek apakah ID sudah ada dalam daftar pengguna
            while (members.Any(m => m.NomorKeanggotaan == idMember))
            {
                idMember++; // Menambahkan 1 ke ID jika sudah ada
            }

            member.NomorKeanggotaan = idMember;
            members.Add(member);
            Console.WriteLine("Book data has been successfully added!!");

        }

        public Member FindId(int id)
        {
            return members.FirstOrDefault(b => b.NomorKeanggotaan == id);
        }


        public void UpdateBook(int inpUpdate)
        {
            Member idUpdate = FindId(inpUpdate);
            if (idUpdate == null)
            {

                errorHandler.HandlerMemberNotFound();
                
            }
            else
            {
                Console.Write("New Name    : ");
                idUpdate.Name = Console.ReadLine();

                Console.Write("New Address : ");
                idUpdate.Address = Console.ReadLine();
            }

        }

        public void RemoveBook(Member member)
        {
            
            if (members.Contains(member))
            {
                members.Remove(member);
                Console.WriteLine("Book data has been successfully deleted!!");
            }
            else
            {
                errorHandler.HandlerMemberNotFound();
            }
        }
        public void ListMember()
        {
            ShowListMember(members);
        }
       
        public void ShowListMember(List<Member> members) //parameter menggunakan list 
        {

            foreach (var listMember in members)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"" +
                    $"\nNama                : {listMember.Name} " +
                    $"\nAlamat              : {listMember.Address} " +
                    $"\nNomor Keanggotaan   : {listMember.NomorKeanggotaan}");
                Console.WriteLine("--------------------------------------------");

            }
        }

    }
}
