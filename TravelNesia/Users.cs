using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TravelNesia;

public class Users
{
    protected List<Users> userList = new List<Users>();
    protected Stack<Users> userStack = new Stack<Users>();
    protected ManageUsers userObj = new ManageUsers();

    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Id { get; private set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }


    public void UpdateUsers()
    {

    }



    public Users() { }
    public Users(string firstname, string lastname, string password, string email, int id, List<Users> cekUser) {
        UserName = GenerateUser(firstname,lastname, cekUser); 
        Password = password; 
        Email = email;
        firstname = firstname;
        LastName = lastname;
        Id = id;
    }


    public virtual string GenerateUser(string firstname, string lastname, List<Users> cekUser)
    {
        string twoFirstUserName = firstname.Substring(0, Math.Min(2, firstname.Length));
        string twoLastUserName = firstname.Substring(0, Math.Min(2, lastname.Length));
        string UserName = twoFirstUserName + twoLastUserName;
        int incrementUsrnm = 1;
        string newUsrnm = UserName;
        // bikin perulangan untuk ngecek usernamenya
        while (cekUser.Any(u => u.UserName == newUsrnm)) //cek apakah current username sama dengan username oldnya
        {
            newUsrnm = $"{UserName}{incrementUsrnm}"; //jika sama, maka akan diset dengan menambahkan nilai +1 di belakang current username
            incrementUsrnm++;
        }
        return UserName; // harus di return karna non void
    }

    public void CreateUsersCust(string firstname, string lastname, string password, string email)
    {


        // inputan dicek menggunakan menggunakan validasi input 
        if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("data cannot be empty!!!");
            return;
        }
        if ((!userObj.ValidateEmail(email)) || (!userObj.ValidatePassword(password)))
        {
            Console.WriteLine("Invalid Input email or password");
            return;
        }
        if (userList.Any(us => us.Email == email)) // tambin untuk no hp juga nanti
        {
            Console.WriteLine("\nThe phone number or email address is already in use by another contact.");
            return;
        }

        int id = 1;
        if (userList.Count > 0)
        {
            id = userList.Max(us => us.Id) + 1;
        }
        while (userList.Any(us => us.Id == id))
        {
            id = id++;
        }

        Users userObj2 = new Users(firstname, lastname, password, email, id, userList);
        userList.Add(userObj2);
        Console.WriteLine("User Account have been created successfully!!");

    }

    public virtual void ShowUser()
    {
        foreach (Users users in userList) //users = class listnya, user var biasa
        {
            Console.WriteLine(
                $"Nama           : {users.FirstName}{users.LastName}" +
                $"\nPassword     : {users.Password}" +
                $"\nEmail        : {users.Email}" +
                $"\nUsername     : {users.UserName}");
        }
    }


    

}
