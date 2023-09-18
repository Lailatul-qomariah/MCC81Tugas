using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TravelNesia;

public class TravelAgents : Users
{
    private List<TravelAgents> userList = new List<TravelAgents>();
    private TravelAgents TAgent = new TravelAgents();

    public string PhoneNumber {  get; set; }
public TravelAgents() { }

public TravelAgents(string firstname, string lastname, string phonNumber, string password, string email, int id, List<Users> cekUser) : 
        base(firstname, lastname, password, email, id, cekUser)
    {
        PhoneNumber = phonNumber;
    }

    public override void ShowUser()
    {
        foreach (TravelAgents travelAgents in userList)
        {

            base.ShowUser();
            Console.WriteLine($"No Handphone  : {travelAgents.PhoneNumber}");
        }
    }


    public void CreateUsersAgent(string firstname, string lastname, string phoneNumber, string password, string email)
    {


        // inputan dicek menggunakan menggunakan validasi input 
        if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname) || string.IsNullOrWhiteSpace(password) || 
            string.IsNullOrWhiteSpace(email) || (string.IsNullOrWhiteSpace(phoneNumber)))
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

      /*  TravelAgents agentObj2 = new TravelAgents(firstname, lastname,phoneNumber, password, email, id, userList);
        userList.Add(agentObj2);
        Console.WriteLine("User Account have been created successfully!!");*/

    }

}
