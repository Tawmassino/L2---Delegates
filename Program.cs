namespace L2___Delegates
{
    internal class Program
    {

        private static readonly int GlobalNumber = 10;//readonly - tai reiskia jog niekur negalima sito keisti
        private delegate int NumberChanger(int n);//metodas, bet jo neaprasome cionais
        private delegate string PersonData(string firstName, string lastName, int age);//parametrai skliausteliuose yra tai ka paduodame i metoda, seka svarbi, pavadinimai gali skirtis.
                                                                                       //return tipas yra nurodomas pries pavadinima
        private delegate int TwoNumbers(int one, int two);

        static void Main(string[] args)
        {
            //task 1
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
        }
        // ================== methods ================== 

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
    }
}