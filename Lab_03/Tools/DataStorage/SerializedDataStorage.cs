using KMA.CSharp2020.Lab03.Tools.Managers;
using System.Collections.Generic;
using System.IO;

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
            }
        }

        private void SaveChanges()
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
    }
}

