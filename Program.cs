namespace OperatorOverloadingExcercise3
{
    internal class Cooking
    {
        public string ThingToCook { get; set; }
        public int NumberOfIngredients { get; set; }
        public double MinutesToComplete { get; set; }
        public int TotalThingsToCook { get; set; }
        public int TotalIngredients { get; set; }
        public double TotalMinutes { get; set; }

        public static Cooking operator ++(Cooking thingToCook)
        {
            thingToCook.TotalThingsToCook++;
            return thingToCook;
        }
        public static Cooking operator +(Cooking thingToCook, int num)
        {
            thingToCook.TotalIngredients += num;
            return thingToCook;
        }
        public static Cooking operator +(Cooking thingToCook, double num)
        {
            thingToCook.TotalIngredients += (int)num;
            return thingToCook;
        }
        public static bool operator >(Cooking thingToCook1, Cooking thingToCook2)
        {
            bool result = false;
            if (thingToCook1.TotalIngredients > thingToCook2.TotalIngredients)
            {
                result = true;
            }
            return result;
        }
        public static bool operator <(Cooking thingToCook1, Cooking thingToCook2)
        {
            bool result = false;
            if (thingToCook1.TotalIngredients < thingToCook2.TotalIngredients)
            {
                result = true;
            }
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Cooking[] day1Meals = new Cooking[10];
            Cooking[] day2Meals = new Cooking[10];

            //create objects
            for (int i = 0; i < day1Meals.Length; i++)
            {
                day1Meals[i] = new Cooking();
                day2Meals[i] = new Cooking();
            }

            //day1's data
            bool moreFood = true;
            int day1Counter = 0;
            Console.WriteLine("Meal Information for Day 1");
            while (moreFood)
            {
                day1Counter++;
                Console.WriteLine("Enter the name of thing you want to cook: ");
                day1Meals[day1Counter].ThingToCook = Console.ReadLine();
                Console.WriteLine("Enter the number of ingredients needed: ");
                day1Meals[day1Counter].NumberOfIngredients = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of minutes to complete cooking: ");
                day1Meals[day1Counter].MinutesToComplete = double.Parse(Console.ReadLine());
                //Accumulate totals in element 0
                day1Meals[0]++; //unary
                day1Meals[0]+= day1Meals[day1Counter].NumberOfIngredients; //binary
                day1Meals[0]+= day1Meals[day1Counter].MinutesToComplete; //binary
                Console.WriteLine("Do you want to continue adding things you want to cook? (any key for yes, Q to quit)");
                string evenMoreFood = Console.ReadLine();
                if (evenMoreFood.ToLower() == "q" || day1Counter >= 10)
                    moreFood = false;
            }

            //day2's data
            moreFood = true;
            int day2Counter = 0;
            Console.WriteLine("Meal Information for Day 2");
            while (moreFood)
            {
                day2Counter++;
                Console.WriteLine("Enter the name of thing you want to cook: ");
                day2Meals[day2Counter].ThingToCook = Console.ReadLine();
                Console.WriteLine("Enter the number of ingredients needed: ");
                day2Meals[day2Counter].NumberOfIngredients = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of minutes to complete cooking: ");
                day2Meals[day2Counter].MinutesToComplete = double.Parse(Console.ReadLine());
                //Accumulate totals in element 0
                day2Meals[0]++; //unary
                day2Meals[0]+= day2Meals[day2Counter].NumberOfIngredients; //binary
                day2Meals[0]+= day2Meals[day2Counter].MinutesToComplete; //binary
                Console.WriteLine("Do you want to continue adding things you want to cook? (any key for yes, Q to quit)");
                string evenMoreFood = Console.ReadLine();
                if (evenMoreFood.ToLower() == "q" || day2Counter >= 10)
                    moreFood = false;
            }

            //Printing information
            Console.WriteLine("***********************************************");
            Console.WriteLine("Day 1 Cooking List");
            Console.WriteLine($"Number of things to cook: {day1Meals[0].TotalThingsToCook}");
            Console.WriteLine("***********************************************");
            foreach (var day1 in day1Meals)
            {
                if (day1.MinutesToComplete != 0)
                {
                    Console.WriteLine($"Thing to Cook: {day1.ThingToCook}");
                    Console.WriteLine($"Number of Ingredients: {day1.NumberOfIngredients}");
                    Console.WriteLine($"Time to Complete: {day1.MinutesToComplete}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("***********************************************");
            Console.WriteLine("Day 2 Cooking List");
            Console.WriteLine($"Number of things to cook: {day2Meals[0].TotalThingsToCook}");
            Console.WriteLine("***********************************************");
            foreach (var day2 in day2Meals)
            {
                if (day2.MinutesToComplete != 0)
                {
                    Console.WriteLine($"Thing to Cook: {day2.ThingToCook}");
                    Console.WriteLine($"Number of Ingredients: {day2.NumberOfIngredients}");
                    Console.WriteLine($"Time to Complete: {day2.MinutesToComplete}");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***********************************************");
            //using overloaded >
            if (day1Meals[0] > day2Meals[0])
            {
                double difference = day1Meals[0].TotalMinutes - day2Meals[0].TotalMinutes;
                Console.WriteLine($"It took {difference} more minutes to cook food yesterday than it did today!");
            }
            else
            {
                double difference = day2Meals[0].TotalMinutes - day1Meals[0].TotalMinutes;
                Console.WriteLine($"It took {difference} more minutes to cook food today than it did yesterday!");
            }

            //Console.WriteLine();
            Console.WriteLine("***********************************************");
            //using overloaded >
            if (day1Meals[0].TotalIngredients > day2Meals[0].TotalIngredients)
            {
                double difference = day1Meals[0].TotalIngredients - day2Meals[0].TotalIngredients;
                Console.WriteLine($"It took {difference} more ingredients to cook food yesterday than it did today!");
            }
            else
            {
                double difference = day2Meals[0].TotalIngredients - day1Meals[0].TotalIngredients;
                Console.WriteLine($"It took {difference} more ingredients to cook food today than it did yesterday!");
            }
        }
    }
}
