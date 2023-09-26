

using Library;
using System;
using System.Collections.Generic;

namespace AnggotaLibrary;

public class LibraryAppMember
{
    public static void Main(string[] args)
    {
        MenuLibrary();
    }


    public static void MenuLibrary()
    {
        ErrorHandlerMember errorHandler = new ErrorHandlerMember();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("\t KEANGGOTAAN LIBRARY \t");
            Console.WriteLine("==========================");
            Console.WriteLine("\n1. Create Data Member \n2. Delete Member \n3. Update Member \n4. View Member \n5. Exit");
            Console.Write("Inpt : ");
            string inpMenu = Console.ReadLine();
            switch (inpMenu)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t CREATE ANGGOTA \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Nama Member :");
                    string name = Console.ReadLine();
                    Console.Write("Masukkan Alamat   :");
                    string address = Console.ReadLine();
                    ManageAnggota.manageMember.AddMember(new Member (name, address));
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t DELETE ANGGOTA\t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan Nomor Keanggotaan :");
                    string noMember = Console.ReadLine();
                    if (errorHandler.TryParseInt(noMember, out int delMember))
                    {
                        Member memberToDelete = ManageAnggota.manageMember.FindId(delMember);
                        ManageAnggota.manageMember.RemoveBook(memberToDelete);
                    }
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t EDIT BOOK \t");
                    Console.WriteLine("============================================");
                    Console.Write("Masukkan No Keanggotaan yang ingin di Edit :");
                    int searchMember = int.Parse(Console.ReadLine());
                    ManageAnggota.manageMember.UpdateBook(searchMember);
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t VIEW ANGGOTA \t");
                    Console.WriteLine("============================================");
                    ManageAnggota.manageMember.ListMember();
                    Console.ReadLine();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    errorHandler.InvalInputHandler();
                    break;
            }

        }

    }
}
