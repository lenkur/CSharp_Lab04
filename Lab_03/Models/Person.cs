using KMA.CSharp2020.Lab03.Exceptions;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KMA.CSharp2020.Lab03
{
    [Serializable]
    internal class Person
    {
        #region Fields
        private Guid _guid;
        private string _name;
        private string _surname;
        private string _email;
        private int _age;
        private DateTime _birthDate;
        private string _westernZodiac;
        private string _chineseZodiac;
        static readonly string[] _westernZodiacSigns = {
            "Aquarius",            "Pisces",            "Aries",
            "Taurus",              "Gemini",            "Cancer",
            "Leo",                 "Virgo",             "Libra",
            "Scorpio",             "Sagittarius",       "Capricorn"};
        static readonly string[] _chineseZodiacSigns = {
            "Monkey",            "Rooster",            "Dog",
            "Pig",               "Rat",                "Ox",
            "Tiger",             "Rabbit",             "Dragon",
            "Snake",             "Horse",              "Goat"};
        #endregion

        #region Properties
        internal Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            private set { _surname = value; }
        }
        public string Email
        {
            get { return _email; }
            private set
            {
                if (!Regex.IsMatch(value, "[\\w-+']+@[\\w\\.]+\\.\\w{2,3}"))
                    throw new ArgumentInvalidEmailException($"Email address '{value}' is invalid.");
                _email = value;
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            private set
            {
                _birthDate = value;
                if (_birthDate.Year < DateTime.Today.Year - 135)
                    throw new ArgumentExpiredDateException($"{BirthDate.Date:D} is too old date.");
                if (_birthDate > DateTime.Today)
                    throw new ArgumentNonExistingDateException($"{BirthDate.Date:D} does not exist yet.");
                else FillProperties();
            }
        }

        public int Age
        {
            get { return _age; }
            private set
            {
                int res = DateTime.Now.Year - _birthDate.Year;
                _age = DateTime.Now < _birthDate.AddYears(res) ? res - 1 : res;

            }
        }

        public bool IsAdult { get { return Age >= 18; } }
        internal bool IsBirthday { get { return BirthDate.Day == DateTime.Today.Day && BirthDate.Month == DateTime.Today.Month; } }
        public string SunSign
        {
            get { return _westernZodiac; }
            private set { _westernZodiac = value; }
        }
        public string ChineseSign
        {
            get { return _chineseZodiac; }
            private set { _chineseZodiac = value; }
        }
        #endregion

        #region Constructors
        public Person(string name, string surname, DateTime birthDate)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public Person(string name, string surname, string email)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(string name, string surname, string email, DateTime birthDate)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
        }
        #endregion


        private async void FillProperties()
        {
            Age = 0;
            CalcWesternZodiac();
            await Task.Run(() => CalcChineseZodiac());
        }

        private void CalcWesternZodiac()
        {
            int m = BirthDate.Month;
            switch (m)
            {
                case 1:
                    SunSign = BirthDate.Day < 20 ? _westernZodiacSigns[11] : _westernZodiacSigns[m - 1];
                    break;
                case 2:
                    SunSign = BirthDate.Day < 19 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 3:
                    SunSign = BirthDate.Day < 21 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 4:
                    SunSign = BirthDate.Day < 20 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 5:
                    SunSign = BirthDate.Day < 21 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 6:
                    SunSign = BirthDate.Day < 21 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 7:
                    SunSign = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 8:
                    SunSign = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 9:
                    SunSign = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 10:
                    SunSign = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 11:
                    SunSign = BirthDate.Day < 22 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 12:
                    SunSign = BirthDate.Day < 22 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
            }
        }

        private void CalcChineseZodiac() { ChineseSign = _chineseZodiacSigns[_birthDate.Year % 12]; }
    }
}