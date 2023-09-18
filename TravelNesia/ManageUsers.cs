using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TravelNesia;

public class ManageUsers
{
    


    public void LoginUser(string email, string password)
    {
        var pswdLogin = userList.FirstOrDefault(u => u.Email == email && u.Password == password);
        if (pswdLogin != null && pswdLogin.Email ==email && pswdLogin.Password == password)
        {
            Console.WriteLine($"Login successful, you are logged in as {pswdLogin.FirstName} {pswdLogin.LastName}");

            //tampilkan info paket2
        }
        else
        {
            Console.WriteLine("Login Failed guys! Make sure the username or password is correct");
        }
        Console.ReadLine();
    }

    

   

    public bool ValidatePassword(string password)
    {
        string regexPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=]).{8,}$";

        // Cek apakah password cocok dengan pola regex
        if (Regex.IsMatch(password, regexPattern))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ValidateEmail(string emailAdress)
    {
        string regexPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";

        // Cek apakah password cocok dengan pola regex
        if (Regex.IsMatch(emailAdress, regexPattern))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ValidatePhoneNumber(string phoneNumber)
    {
        // Lakukan validasi nomor telepon sesuai format yang diinginkan
        // Misalnya, format XXX-XXXXXXX
        // Di sini dapat menggunakan ekspresi reguler (regex) untuk validasi lebih lanjut.
        if (Regex.IsMatch(phoneNumber, @"^\+?[0-9]{8,15}$"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
