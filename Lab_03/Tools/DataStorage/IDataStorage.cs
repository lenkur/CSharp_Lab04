﻿namespace KMA.CSharp2020.Lab03.Tools.DataStorage
{
    internal interface IDataStorage
    {
        bool PersonExists(string name, string surname, string email);
        void AddPerson(Person person);
    }
}
