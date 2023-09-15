using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasMcc;

public class UserCrud
{
    public static List<User> userList = new List<User>(); //kumpulan list yang berada dalam satu konstruktor
    User user2 = new User(); //membuat objek untuk akses method atau variabel di class user
    public void CreateUser(string firstName, string lastName, string password)
    {
        //cek apakah inputan user berupa spasi atau null
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("\nInvalid input. Make sure the FirstName and LastName columns are filled in!");
            return;
        }
        int idUser = 1; // Menentukan ID berikutnya
        if (userList.Count > 0)
        {
            idUser = userList.Max(u => u.Id) + 1;
        }

        // Mengecek apakah ID sudah ada dalam daftar pengguna
        while (userList.Any(u => u.Id == idUser))
        {
            idUser++; // Menambahkan 1 ke ID jika sudah ada
        }
        //untuk menambah id user secara otomatis
        User newUser = new User(idUser, firstName, lastName, password, userList); //menampung inputan user untuk dimasukkan pada list (userList)
        userList.Add(newUser); // menambahkan inputan user di objek newUser ke list (userList)
        Console.WriteLine("User created successfully!");
    }

    public void ShowUser()
    {
        Console.Clear(); 
        Console.WriteLine("=======SHOW USER=======");
        foreach (User user in userList) //looping list (userList) untuk ditampilkan
        {
            Console.WriteLine("========================");
            Console.WriteLine(
                $"Id User     : {user.Id}" +
                $"\nFirst Name  : {user.FirstName} " +
                $"\nLast Name   : {user.LastName} " +
                $"\nUsername    : {user.Username}" +
                $"\nPassword    : {user.Password}"
                );
            Console.WriteLine("========================");
        }
    }

    public void SearchUser(string checkUser)
    {

        // untuk membandingkan antara inputan dan data yang ada pada userList itu sama atau tidak
        var resultSearch = userList.Where(u => u.FirstName == checkUser || u.LastName == checkUser).ToList();

        if (resultSearch.Count > 0) // untuk cek apakah userlist > 0 
        {
            foreach (var user in resultSearch)
            {
                Console.WriteLine("========================");
                Console.WriteLine($"ID       : {user.Id}");
                Console.WriteLine($"Name     : {user.FirstName} {user.LastName}");
                Console.WriteLine($"Username : {user.Username}");
                Console.WriteLine($"Password : {user.Password}");
                Console.WriteLine("========================");
            }
        }
        else
        {
            Console.WriteLine("User not Found!!");
        }
        Console.ReadLine();
    }

    public void Login(string inpUserName, string inpPsswd)
    {

        var pswdLogin = userList.FirstOrDefault(u => u.Username == inpUserName && u.Password == inpPsswd);
        if (pswdLogin != null && pswdLogin.Password == inpPsswd)
        {
            Console.WriteLine($"Login successful, you are logged in as {pswdLogin.FirstName} {pswdLogin.LastName}");

            TugasMcc.GanjilGenap.MenuGanjilGenap();
        }
        else
        {
            Console.WriteLine("Login Failed guys! Make sure the username or password is correct");
        }
        Console.ReadLine();
    }

    public void EditUser(int inpUpdate)
    {
        User userEdit = userList.FirstOrDefault(u => u.Id == inpUpdate);
        if (userEdit != null)
        {
            Console.Write("New First Name: ");
            userEdit.FirstName = Console.ReadLine();

            Console.Write("New Last Name: ");
            userEdit.LastName = Console.ReadLine();
            userEdit.Username = user2.GenerateUserName(userEdit.FirstName, userEdit.LastName, userList);   
            string passwd;
            bool validPsswd;
            do
            {

                Console.Write("New Password: ");
                userEdit.Password = Console.ReadLine();
                validPsswd = User.ValidatePassword(userEdit.Password);
                if (validPsswd == false)
                {
                    Console.WriteLine("Password must have at least 8 characters with at" +
                    " least one Capital letter, one lower case letter, and one number.");
                }
            } while (validPsswd == false);
              Console.WriteLine("User data has been successfully edited!");
              Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid ID.");
            Console.ReadLine();
        }

    }

    public void DeleteUser(int inpDelete)
    {

        User userDelete = userList.FirstOrDefault(u => u.Id == inpDelete);
        if (userDelete != null)
        {            
            userList.Remove(userDelete);
            Console.WriteLine("User has been successfully deleted!!");
        }
        else
        {
            Console.WriteLine("Invalid ID. User not found");
        }
        Console.ReadLine();
    }

}
