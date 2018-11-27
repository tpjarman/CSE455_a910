using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Web;
using System.Xml.Linq;
using BusinessLogic;
//using Crypt;
namespace AccountControl
{
    public class Service1 : IControl
    {
        //Crypt.Crypt cry = new Crypt.Crypt();
        public bool ValidateStaff(string user, string pass)
        {
            pass = SecurityManager.Decrypt(pass); //2b by Tydin Jarman
            bool result = false; //@"H:\AllCollege\ASU\Fall2018\CSE445\Projects\A9A10\CSE445_A9A10\CSE445_A9A10\App_Data\Staff.xml")
            IEnumerable<string> users = from member in XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Staff.xml")
                                        .Element("StaffMembers").Elements("Staff") select (string)member.Element("Username").Value;
            List<string> list_Users = users.ToList<string>();
            IEnumerable<string> passwords = from member in XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Staff.xml")
                                        .Element("StaffMembers").Elements("Staff") select (string)member.Element("Password").Value;
            List<string> list_Passwords = passwords.ToList<string>();
            for (int i = 0; i < list_Users.Count; i++)
            {
                if (list_Users[i] == user)
                {
                    if (SecurityManager.Decrypt(list_Passwords[i]) == pass) {result = true;}
                }
            }
            return result;
        }
        public bool ValidateUser(string user, string pass)
        {//Validate that the user is in the xml file.
            bool result = false;
            pass = SecurityManager.Decrypt(pass); //2b by Tydin Jarman
            IEnumerable<string> users = from member in XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Member.xml")
                                        .Element("Members").Elements("Member") select (string)member.Element("Username").Value;
            List<string> list_Users = users.ToList<string>();
            IEnumerable<string> passwords = from member in XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Member.xml")
                                        .Element("Members").Elements("Member") select (string)member.Element("Password").Value;
            List<string> list_Passwords = passwords.ToList<string>();
            for (int i = 0; i < list_Users.Count; i++)
            {
                if(list_Users[i] == user)
                {
                    if (SecurityManager.Decrypt(list_Passwords[i]) == pass) { result = true; }
                }
            }
            return result;
        }
        public bool CreateUser(string first, string last, string user, string pass)
        {//Add a user to the xml!
            //pass = SecurityManager.Decrypt(pass); //2b by Tydin Jarman
            bool result = false;
            //Add validation to make sure no repeat first + last or user.
            try
            {
                XDocument xml = XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Member.xml");
                xml.Element("Members").AddFirst(
                    new XElement("Member",
                    new XElement("First", first),
                    new XElement("Last", last),
                    new XElement("Username", user),
                    new XElement("Password", pass)
                ));
                xml.Save(System.AppDomain.CurrentDomain.BaseDirectory + "Member.xml");
                result = true;
            }
            catch { }
            return result;
        }
        public bool RemoveUser(string first, string last)
        {//Remove matching user from xml(without having to know their account info ie: just name).
            bool result = false;
            try
            {
                XDocument xml = XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Member.xml");
                xml.Root.Elements().Where(x => x.Element("First").Value == first && x.Element("Last").Value == last).FirstOrDefault().Remove();
                xml.Save(System.AppDomain.CurrentDomain.BaseDirectory + "Member.xml");
                result = true;
            }
            catch { }
            return result;
        }
        public List<string> ListMembers()
        {//List all members from members.xml and NOT staff!
            List<string> result = new List<string>();
            IEnumerable<string> first = from member in XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Member.xml")
                                        .Element("Members").Elements("Member") //.Descendants("Member")
                                        select (string)member.Element("First").Value;
            List<string> list_First = first.ToList<string>();
            IEnumerable<string> last = from member in XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory + "Member.xml")
                                        .Element("Members").Elements("Member") //.Descendants("Member")
                                            select (string)member.Element("Last").Value;
            List<string> list_Last = last.ToList<string>();
            for (int i = 0; i < list_First.Count; i++)
            {
                result.Add(list_First[i] + " " + list_Last[i]);
            }
            return result;
        }
    }
}
