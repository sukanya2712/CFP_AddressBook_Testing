using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookforTesting
{
    public class AddressBook 
    { 
          List<Contact> ContactList = new List<Contact>();
          MethodsforValidation validationMethods = new MethodsforValidation();
    public bool AddContact(string name, string email, string phone, string state, string city, string zipcode)
    {
        if (!validationMethods.IsValidName(name))
        {
            Console.WriteLine(" INVALID NAME \n");
            return false;
        }

        if (!validationMethods.IsValidEmail(email))
        {
            Console.WriteLine(" INVALID EMAIL \n");
            return false;
        }

        if (!validationMethods.IsValidPhoneNumber(phone))
        {
            Console.WriteLine("INVALID PHONE NUMBER!\n");
            return false;
        }

        if (!validationMethods.IsValidZIP(zipcode))
        {
            Console.WriteLine(" INVALID ZIP CODE! \n");
            return false;
        }

        Contact contact = new Contact(name, email, phone, state, city, zipcode);

        foreach (Contact c in ContactList)
        {
            if (c.Phone == phone || c.Name == name)
            {
                throw new ContactAlreadyExistsException("DUPLICATE CONTACT FOUND ");
            }
        }

        ContactList.Add(contact);
        Console.WriteLine("Contact Added...");
        return true;
    }

    public Contact EditContact(string editName, string Data, int editType)
    {
        for (int index = 0; index < ContactList.Count; index++)
        {
            Contact contact = ContactList[index];
            if (editName.Equals(contact.Name))
            {
                switch (editType)
                {
                    case 1:
                        if (!validationMethods.IsValidName(Data))
                        {
                            Console.WriteLine("INVALID NAME!\n");
                            return null;
                        }
                        contact.Name = Data;
                        break;
                    case 2:
                        if (!validationMethods.IsValidEmail(Data))
                        {
                            Console.WriteLine("INVALID EMAIL!!! Enter the valid data...\n");
                            return null;
                        }
                        contact.Email = Data;
                        break;
                    case 3:
                        if (!validationMethods.IsValidPhoneNumber(Data))
                        {
                            Console.WriteLine("INVALID PHONE NUMBER!!! Enter the valid data...\n");
                            return null;
                        }
                        contact.Phone = Data;
                        break;
                    case 4:
                        contact.State = Data;
                        break;
                    case 5:
                        contact.City = Data;
                        break;
                    case 6:
                        if (!validationMethods.IsValidZIP(Data))
                        {
                            Console.WriteLine("INVALID ZIP CODE! .\n");
                            return null; ; ;
                        }
                        contact.ZipCode = Data;
                        break;
                    default:
                        Console.WriteLine("Enter a valid field!!!");
                        break;
                }
                Console.WriteLine("Contact Edited!!!");
                Console.WriteLine("Contact Details AFTER Edit:");
                Console.WriteLine(contact.ToString());
                return contact;
            }
        }
        throw new Exception("CONTACT NOT FOUND!!! Please enter the name of an existing contact.");
    }

    public Contact DeleteContact(string deleteName)
    {
        for (int index = 0; index < ContactList.Count; index++)
        {
            Contact contact = ContactList[index];
            if (deleteName == contact.Name)
            {
                ContactList.Remove(contact);
                Console.WriteLine("Contact Deleted!");
                return contact;
            }
        }
        throw new Exception("CONTACT NOT FOUND!");
    }

    

        public List<Contact> Display()
        {
            if (ContactList.Count == 0)
            {
                throw new EmptyContactListException("Contact list is empty.");
            }
            return ContactList;
        }
    }
}
