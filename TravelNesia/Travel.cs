using System;
using TravelNesia;

namespace TugasMcc;

public class Travel
{
    public static void Main(string[] args)
    {
        UserMenu();
    }


    public static void UserMenu()
    {
        Users mUserObj = new Users();
        TravelAgents TAgent = new TravelAgents();
        while (true)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("\t MENU TRAVELNESI \t");
            Console.WriteLine("==========================");
            Console.WriteLine("Masuk sebagai : \n1. Customers \n2. Agen Travel \n3. Exit");
            Console.Write("Inpt : ");
            string inpMenu = Console.ReadLine();

            switch (inpMenu)
            {
                case "1":
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t MENU CUSTOMERS \t");
                    Console.WriteLine("============================================");
                    Console.WriteLine("1. Create Akun \n2. Info Paket Travel \n3. Login Customers \n4. List Booking \n5. Exit");
                    Console.Write("Inpt : ");
                    string inpMenuCus = Console.ReadLine();
                    switch (inpMenuCus)
                    {
                        case "1":
                            Console.WriteLine("------------- Create Akun Customers -------------");
                            //nanti di dalemnya ini bisa edit cust
                            Console.Write("Masukkan Nama Depan  :");
                            string firstname = Console.ReadLine();
                            Console.Write("Masukkan Nama Belakang  :");
                            string lastname = Console.ReadLine(); 
                            Console.Write("Masukkan Email       :");
                            string email= Console.ReadLine();
                            Console.Write("Masukkan Password    :");
                            string psswd= Console.ReadLine();
                            mUserObj.CreateUsersCust(firstname, lastname, psswd, email);
                            mUserObj.ShowUser();
                            break;
                        case "2":
                            Console.WriteLine("------------- Info Paket Customers -------------");
                            //GABISA DIAPA2IN KALO BELUM PUNYA AKUN
                            break;
                        case "3":
                            Console.WriteLine("------------- Login Costomers -------------");
                            //isinya paket2 dan bisa di pilih booking 
                            //kalo dipilih booking nanti dia statusnya bakalan terbooking dan pindah ke 
                            //pindah ke meu Pesananan
                            // GABISA DIPAKE KALO BELOM PUNYA AKUN 


                            break;
                        case "4":
                            Console.WriteLine("------------- List Booking  -------------");
                            break;
                        case "5":
                            Console.WriteLine("------------- List Booking  -------------");
                            break;
                    }


                    break;

                case "2":
                    Console.WriteLine("============================================");
                    Console.WriteLine("\t MENU AGEN TRAVEL \t");
                    Console.WriteLine("============================================");
                    Console.WriteLine("1. Create Akun \n2. Login \n3. Create Paket Travel \n4. Show Paket Travel \n5. Daftar Booking \n6. Back");
                    Console.Write("Inpt : ");
                    string inpMenuAgent = Console.ReadLine();
                    switch (inpMenuAgent)
                    {
                        case "1":
                            Console.WriteLine("------------- Create Akun Agen -------------");
                            Console.Write("Masukkan Nama Depan      :");
                            string firstname = Console.ReadLine();
                            Console.Write("Masukkan Nama Belakang   :");
                            string lastname = Console.ReadLine();
                            Console.Write("Masukkan No Handpone     :");
                            string phonenumber= Console.ReadLine();
                            Console.Write("Masukkan Email           :");
                            string email = Console.ReadLine();
                            Console.Write("Masukkan Password        :");
                            string psswd = Console.ReadLine();
                            mUserObj.CreateUsersCust(firstname, lastname, psswd, email);
                            mUserObj.ShowUser();
                            break;
                        case "2":
                            Console.WriteLine("------------- Create Paket Travel -------------");
                            //GABISA DIAPA2IN KALO BELUM PUNYA AKUN
                            break;
                        case "3":
                            Console.WriteLine("------------- Show Paket Travel -------------");
                            //isinya paket2 yang sudah di buat, bisa di update dan di delete
                            
                            break;
                        case "4":
                            Console.WriteLine("------------- Daftar Booking -------------"); // daftar pesanan dari customer
                            break;
                        case "5":
                            break;
                    }
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }

        }

    }
}
