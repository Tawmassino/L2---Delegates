using static L2___Delegates.Program;
using System.Collections.Generic;

namespace L2___Delegates
{
    internal class Program
    {

        private static readonly int GlobalNumber = 10;//readonly - tai reiskia jog niekur negalima sito keisti
        private delegate int NumberChanger(int n);//metodas, bet jo neaprasome cionais
        private delegate string PersonData(string firstName, string lastName, int age);//parametrai skliausteliuose yra tai ka paduodame i metoda, seka svarbi, pavadinimai gali skirtis.
                                                                                       //return tipas yra nurodomas pries pavadinima
        private delegate int TwoNumbers(int one, int two);

        public delegate bool Filter(Person character);

        static void Main(string[] args)
        {

            List<Person> dbzCharacters = new List<Person>();
            //Person person1 = new Person("vardas", 50);//arba taip susikuriam
            //people.Add(person1); //taip pridedam
            dbzCharacters.Add(new Person("Goku", 45));
            dbzCharacters.Add(new Person("Vegeta", 48));
            dbzCharacters.Add(new Person("Gohan", 20));
            dbzCharacters.Add(new Person("Piccolo", 35));
            dbzCharacters.Add(new Person("Goten", 10));
            dbzCharacters.Add(new Person("Trunks", 11));
            dbzCharacters.Add(new Person("Krillin", 40));
            dbzCharacters.Add(new Person("Bulma", 38));
            dbzCharacters.Add(new Person("Chi-Chi", 43));
            dbzCharacters.Add(new Person("Majin Buu", 5));
            dbzCharacters.Add(new Person("Dende", 16));
            dbzCharacters.Add(new Person("Mr. Satan", 42));
            dbzCharacters.Add(new Person("Tien", 35));
            dbzCharacters.Add(new Person("Yamcha", 41));
            dbzCharacters.Add(new Person("Chiaotzu", 34));
            dbzCharacters.Add(new Person("Videl", 19));
            dbzCharacters.Add(new Person("Android 18", 31));
            dbzCharacters.Add(new Person("Android 17", 32));
            dbzCharacters.Add(new Person("Master Roshi", 300));
            dbzCharacters.Add(new Person("Korin", 800));

            //delegates
            //bool isChildBad = new Filter(IsChild(dbzCharacters));             
            //bool isAdultBad = new Filter(IsAdult(dbzCharacters));
            //bool isSeniorBad = new Filter(IsAdult(dbzCharacters));

            var isChild = new Filter(IsChild); //reikia nepamisrsti STATIC metodu padaryt
            var isAdult = new Filter(IsAdult); //reikia cia paduoti ne lista, o viena zmogu
            var isSenior = new Filter(IsSenior);

            //string title = Console.ReadLine(); 
            string title = "children";

            DisplayPeople(title, dbzCharacters, isChild, isAdult, isSenior);

            //var person1 = new PersonData(MakePerson);
            //Console.WriteLine(person1("Homeris", "Simpsonas", 50));


            // ----------------- 
            #region otherTasks


            PersonData personosDuomenys = delegate (string firstName, string lastName, int age)
            {
                return firstName + ", " + lastName + ", " + age;
            };

            TwoNumbers duSkaiciai = delegate (int one, int two)
            {
                return one + two;
            };



            //anonymous method
            Console.WriteLine("anonymous delegate:");

            NumberChanger numberChangerAnonymous = delegate (int number)
            {
                return number + 5;
            };
            int x = 10;
            ExecuteNumberChangerWithValue(x, numberChangerAnonymous);


            Console.WriteLine("====================");


            //================================================
            //task 1
            //paprasto metodo delegatai
            var person1 = new PersonData(MakePerson);
            Console.WriteLine(person1("Homeris", "Simpsonas", 50));


            //task 2
            var namberis = new TwoNumbers(TwoNumberses);
            Console.WriteLine(namberis(4, 3));

            //-----------
            Console.WriteLine(AddNumber(5));
            Console.WriteLine(SubtractNumber(6));

            var numberChanger1 = new NumberChanger(AddNumber);
            var numberChanger2 = new NumberChanger(SubtractNumber);

            Console.WriteLine(numberChanger1(5));
            Console.WriteLine(numberChanger2(6));
            #endregion
        }
        // ==================================== methods ====================================

        public static bool IsChild(Person character)
        {
            if (character.Age < 18)
            {
                return true;
            }

            return false;
        }


        public static bool IsAdult(Person character)
        {
            if (character.Age > 18 && character.Age < 65)
            {
                return true;
            }

            return false;

        }

        public static bool IsSenior(Person character)
        {
            if (character.Age > 65)
            {
                return true;
            }

            return false;

        }

        #region MethodsThatSort2NewLists
        //public List<Person> FilterToChildren(List<Person> characters)
        //{
        //    List<Person> childList = new List<Person>();
        //    for (int i = 0; i < characters.Count; i++)
        //    {
        //        if (characters[i].Age < 18)
        //        {
        //            childList.Add(characters[i]);
        //        }
        //    }
        //    return childList;
        //}

        //public List<Person> FilterToSeniors(List<Person> characters)
        //{
        //    List<Person> seniorList = new List<Person>();
        //    for (int i = 0; i < characters.Count; i++)
        //    {
        //        if (characters[i].Age > 65)
        //        {
        //            seniorList.Add(characters[i]);
        //        }
        //    }
        //    return seniorList;
        //}

        //public List<Person> FilterToAdults(List<Person> characters)
        //{
        //    List<Person> adultList = new List<Person>();
        //    for (int i = 0; i < characters.Count; i++)
        //    {
        //        if (characters[i].Age > 18 && characters[i].Age < 65)
        //        {
        //            adultList.Add(characters[i]);
        //        }
        //    }
        //    return adultList;
        //}
        #endregion

        public static void DisplayPeople(string title, List<Person> people, Filter isChild, Filter isAdult, Filter isSenior)
        {
            switch (title)
            {
                case "children":
                    foreach (Person person in people)
                    {
                        if (isChild(person))
                        {
                            Console.WriteLine($"{person.Name}, {person.Age}");
                        }
                    }
                    break;
                case "adult":
                    foreach (Person person in people)
                    {
                        if (isAdult(person))
                        {
                            Console.WriteLine($"{person.Name}, {person.Age}");
                        }
                    }
                    break;
                case "senior":
                    foreach (Person person in people)
                    {
                        if (isSenior(person))
                        {
                            Console.WriteLine($"{person.Name}, {person.Age}");
                        }
                    }
                    break;
            }

        }

        // =========================
        public static int TwoNumberses(int one, int two)
        {
            return one + two;
        }

        public static string MakePerson(string firstName, string lastName, int age)
        {
            return firstName + ", " + lastName + ", " + age;
        }


        public static int AddNumber(int number)
        {
            return GlobalNumber + number;
        }

        public static int SubtractNumber(int number)
        {
            return GlobalNumber - number;
        }

        private static void ExecuteNumberChangerWithValue(int val, NumberChanger numberChanger)//delegatas ir metodas turi buti tokie patys (public arba private)
        {
            val += 10;
            numberChanger(val); //cia paduodame delegata, kuris darys savo funkcija
        }
    }
}