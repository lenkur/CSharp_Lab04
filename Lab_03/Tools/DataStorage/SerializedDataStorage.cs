using KMA.CSharp2020.Lab03.Tools.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace KMA.CSharp2020.Lab03.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _users;

        public List<Person> UsersList { get { return _users; } }

        internal SerializedDataStorage()
        {
            try
            {
                _users = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _users = new List<Person>();
                FillList();
            }
        }

        private void FillList()
        {
            UsersList.Add(new Person("Crystal", "Norris", "crystal.norris@mydomain.com", new DateTime(1962, 02, 08)));
            UsersList.Add(new Person("Mandy", "Munoz", "mandy.munoz@mydomain.com", new DateTime(1968, 05, 23)));
            UsersList.Add(new Person("Fannie", "Hammond", "fannie.hammond@mydomain.com", new DateTime(1983, 08, 28)));
            UsersList.Add(new Person("Mike", "Hogan", "mike.hogan@mydomain.com", new DateTime(1974, 02, 25)));
            UsersList.Add(new Person("Tonya", "Buchanan", "tonya.buchanan@mydomain.com", new DateTime(1995, 09, 21)));
            UsersList.Add(new Person("Emily", "Armstrong", "emily.armstrong@mydomain.com", new DateTime(1989, 02, 15)));
            UsersList.Add(new Person("Jessie", "Murray", "jessie.murray@mydomain.com", new DateTime(2005, 11, 11)));
            UsersList.Add(new Person("Josh", "Brock", "josh.brock@mydomain.com", new DateTime(1994, 09, 03)));
            UsersList.Add(new Person("Vanessa", "Stephens", "vanessa.stephens@mydomain.com", new DateTime(2006, 10, 11)));
            UsersList.Add(new Person("Rosie", "Conner", "rosie.conner@mydomain.com", new DateTime(1952, 05, 03)));
            UsersList.Add(new Person("Doreen", "Allison", "doreen.allison@mydomain.com", new DateTime(1965, 05, 30)));
            UsersList.Add(new Person("Phyllis", "Vega", "phyllis.vega@mydomain.com", new DateTime(2018, 09, 02)));
            UsersList.Add(new Person("Guillermo", "Schmidt", "guillermo.schmidt@mydomain.com", new DateTime(2011, 07, 01)));
            UsersList.Add(new Person("Sandra", "Owen", "sandra.owen@mydomain.com", new DateTime(2001, 01, 29)));
            UsersList.Add(new Person("Lora", "Patterson", "lora.patterson@mydomain.com", new DateTime(1952, 09, 29)));
            UsersList.Add(new Person("Christopher", "Castillo", "christopher.castillo@mydomain.com", new DateTime(1965, 02, 15)));
            UsersList.Add(new Person("Mitchell", "Reeves", "mitchell.reeves@mydomain.com", new DateTime(1968, 03, 07)));
            UsersList.Add(new Person("Cassandra", "Nunez", "cassandra.nunez@mydomain.com", new DateTime(2007, 06, 09)));
            UsersList.Add(new Person("Bob", "Fernandez", "bob.fernandez@mydomain.com", new DateTime(1959, 06, 17)));
            UsersList.Add(new Person("Alison", "Fleming", "alison.fleming@mydomain.com", new DateTime(2011, 03, 16)));
            UsersList.Add(new Person("Devin", "Powers", "devin.powers@mydomain.com", new DateTime(1956, 04, 30)));
            UsersList.Add(new Person("Elizabeth", "Reid", "elizabeth.reid@mydomain.com", new DateTime(1979, 11, 15)));
            UsersList.Add(new Person("Wilson", "Clayton", "wilson.clayton@mydomain.com", new DateTime(1966, 10, 26)));
            UsersList.Add(new Person("Maureen", "Gray", "maureen.gray@mydomain.com", new DateTime(2017, 08, 24)));
            UsersList.Add(new Person("Erika", "Mack", "erika.mack@mydomain.com", new DateTime(2000, 06, 07)));
            UsersList.Add(new Person("Barry", "Gross", "barry.gross@mydomain.com", new DateTime(1985, 03, 26)));
            UsersList.Add(new Person("Dustin", "Gill", "dustin.gill@mydomain.com", new DateTime(2002, 05, 10)));
            UsersList.Add(new Person("Zachary", "Harper", "zachary.harper@mydomain.com", new DateTime(1967, 07, 03)));
            UsersList.Add(new Person("Natasha", "Tucker", "natasha.tucker@mydomain.com", new DateTime(2009, 03, 19)));
            UsersList.Add(new Person("Kara", "Hampton", "kara.hampton@mydomain.com", new DateTime(1973, 08, 03)));
            UsersList.Add(new Person("Vincent", "Freeman", "vincent.freeman@mydomain.com", new DateTime(1983, 08, 02)));
            UsersList.Add(new Person("Marjorie", "Lambert", "marjorie.lambert@mydomain.com", new DateTime(1996, 09, 13)));
            UsersList.Add(new Person("Jesus", "Ray", "jesus.ray@mydomain.com", new DateTime(1966, 08, 17)));
            UsersList.Add(new Person("Geneva", "Richards", "geneva.richards@mydomain.com", new DateTime(2013, 04, 22)));
            UsersList.Add(new Person("John", "Goodwin", "john.goodwin@mydomain.com", new DateTime(1985, 01, 17)));
            UsersList.Add(new Person("Johnny", "Bryant", "johnny.bryant@mydomain.com", new DateTime(1976, 08, 29)));
            UsersList.Add(new Person("Homer", "Campbell", "homer.campbell@mydomain.com", new DateTime(1992, 11, 02)));
            UsersList.Add(new Person("Santiago", "Herrera", "santiago.herrera@mydomain.com", new DateTime(1974, 01, 15)));
            UsersList.Add(new Person("Ivan", "Roberson", "ivan.roberson@mydomain.com", new DateTime(1954, 01, 26)));
            UsersList.Add(new Person("Rudy", "Johnston", "rudy.johnston@mydomain.com", new DateTime(1967, 07, 24)));
            UsersList.Add(new Person("Lynette", "Webb", "lynette.webb@mydomain.com", new DateTime(1995, 04, 04)));
            UsersList.Add(new Person("Boyd", "Burton", "boyd.burton@mydomain.com", new DateTime(1965, 09, 18)));
            UsersList.Add(new Person("Debbie", "Sullivan", "debbie.sullivan@mydomain.com", new DateTime(2001, 12, 29)));
            UsersList.Add(new Person("Elvira", "Barrett", "elvira.barrett@mydomain.com", new DateTime(1960, 04, 24)));
            UsersList.Add(new Person("Kelley", "Schwartz", "kelley.schwartz@mydomain.com", new DateTime(2018, 07, 24)));
            UsersList.Add(new Person("Jana", "Jackson", "jana.jackson@mydomain.com", new DateTime(1965, 08, 03)));
            UsersList.Add(new Person("Celia", "Burgess", "celia.burgess@mydomain.com", new DateTime(1955, 10, 18)));
            UsersList.Add(new Person("Sonia", "Wilson", "sonia.wilson@mydomain.com", new DateTime(1953, 07, 09)));
            UsersList.Add(new Person("Barbara", "Sims", "barbara.sims@mydomain.com", new DateTime(1995, 02, 20)));
            UsersList.Add(new Person("Nichole", "Hubbard", "nichole.hubbard@mydomain.com", new DateTime(1996, 09, 20)));
            SaveChanges();
        }

        internal void SaveChanges()
        {
            SerializationManager.Serialize(_users, FileFolderHelper.StorageFilePath);
        }

        public bool PersonExists(string name, string surname, string email)
        {
            return _users.Exists(u => u.Name == name && u.Surname == surname && u.Email == email);
        }

        public void AddPerson(Person person)
        {
            _users.Add(person);
            SaveChanges();
        }
        public void DeletePerson(Person person)
        {
            _users.Remove(person);
            SaveChanges();
        }
    }
}