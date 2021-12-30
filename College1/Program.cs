using System;

namespace College1
{
    internal class Program
    {
        /*The Euclidean Algorithm for finding GCD(A,B) is as follows:
        If A = 0 then GCD(A,B)=B, since the GCD(0,B)=B, and we can stop.  
        If B = 0 then GCD(A,B)=A, since the GCD(A,0)=A, and we can stop.  
        Write A in quotient remainder form (A = B⋅Q + R)
        Find GCD(B,R) using the Euclidean Algorithm since GCD(A,B) = GCD(B,R)*/
        public static int Gcd(int a, int b)
        {
            //intialize temp
            int temp = 0;
            while (a != 0 && b != 0)
            {
                //Make a Temporery copy of a
                temp = a;
                a = b;//assign a to b to put the new greatest number in a again
                if (temp % b == 0)//to prevent b from modification in case its the divisor
                    break;
                b = temp % b;//new value to try as a divisor
            }
            return b;
        }
        // the recursive Method of gcd finding
        /*The Euclidean Algorithm for finding GCD(A,B) is as follows:
        If A = 0 then GCD(A,B)=B, since the GCD(0,B)=B, and we can stop.  
        If B = 0 then GCD(A,B)=A, since the GCD(A,0)=A, and we can stop.  
        Write A in quotient remainder form (A = B⋅Q + R)
        Find GCD(B,R) using the Euclidean Algorithm since GCD(A,B) = GCD(B,R)*/
        public static int gCDRe(int a, int b)
        {
            //my base case that involves finding b = 0 after last reminder operation
            if (b == 0)
            {
                return a;//returning my gcd
            }
            else
            {
                //trying new value as a divisor
                return gCDRe(b, a % b);
            }
        }
        public static void GDRProgram()
        {
            Console.WriteLine("Enter Two Numbers Two Get Their GCD");
            int in1 = 0;
            int in2 = 0;
            bool isValid = false;//become true when you enter valid int
            bool isValid2 = false;//become true when you enter valid int
            //to confirm that the input is an integer
            do
            {
                Console.Write("The first Number : ");
                //return true in case the input is int and assign it to in1
                if (int.TryParse(Console.ReadLine(), out in1))
                {
                    if (in1 != 0)
                        isValid = true;
                    else
                    {
                        Console.WriteLine("Input should be non-zero integer");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("not a valid input -- Please enter an intger");
                    continue;
                }
                Console.Write("The Second Number: ");
                //return true in case the input is int and assign it to in2
                if (int.TryParse(Console.ReadLine(), out in2))
                {
                    if (in2 != 0)
                        isValid2 = true;
                    else
                    {
                        Console.WriteLine("Input should be non-zero integer");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("not a valid input -- Please enter an intger");
                    continue;
                }
            } while (!(isValid && isValid2));
            //runng my method and return ans to my console in iterative way
            Console.WriteLine("Their GCD (by iteration) Is: " + Gcd(in2, in1));
            //runng my method and return ans to my console in recursve
            Console.WriteLine("Their GCD (by recursion) Is: " + gCDRe(in1, in2));
        }
        public static void PerfectNumbCheckProgram()
        {
            while (true)
            {
                // Display a message to the user on the screen to help him enter the right input
                Console.Write("Please enter an inger betwenn 2 and 1000 to check if it is perfect ot not: ");
                // Declarain a local variable and storing the data given by the user as a string to check if it is valid for the programme or not
                var checkValidation = Console.ReadLine();
                // Declaraing a variable as an intger to pass the user data to it if it is valid
                int number;
                // check if the input is an intger and return true in that case else will return a false and store it inf the parseSuccess variable
                bool parseSuccess = int.TryParse(checkValidation, out number);
                /* first if will check the parseSuccess value as a bool valuse true or false
                   then will move to check in the number given by the user is in the range 
                   as in ith task the number must me greater than two and less than thousand
                   *** I user the logical operator and as all expressions must be true */
                if (parseSuccess && number >= 2 && number <= 1000)
                {
                    // declaraing a variable to store the summation of the factors in it
                    int sumOfFactors = 0;
                    // Displaying a message to the user to show him the factors
                    // it is written outside the loop so would be wxcuted juts once 
                    Console.Write("[+] {0} Factors are:", number);
                    // looping for each number less than given number to get all possible factors
                    /*Caution We diveded number by two because a perfect number is a number
                    that is half the sum of all of its positive divisors including itself*/
                    for (int possiableFactors = 1; possiableFactors <= number/2 ; possiableFactors++)
                    {
                        // using the factor definiation to check for all real factors as if we divide the number by its factor there will be no reminder 
                        if (number % possiableFactors == 0)
                        {
                            // displaying the factors
                            Console.Write(" {0} ", possiableFactors);
                            // adding all factors and storing them int the sumOfFactor variable
                            sumOfFactors += possiableFactors;
                        }
                    }
                    // displaying a new line to show the output in a nicer way
                    Console.WriteLine();
                    // displaying the summation of the factors to the user
                    Console.WriteLine("[+] Sum of its factors is {0}", sumOfFactors);
                    // using the definiation of the perfect number by checking if the summation of the factors is equal to the number
                    if (sumOfFactors == number)
                    {
                        // if the number is perfect this message will be displayed to the user
                        Console.WriteLine("[+] so {0} is a perfect number\n", number);
                        // the programme will get out of the while loop and stop
                        break;
                    }
                    else
                    {
                        // if the number is not perfect this message will be displayed to the user
                        Console.WriteLine("[+] This number is not perfect.\n");
                        // the programme will get out of the while loop and stop
                        break;
                    }
                }
                else
                {
                    // these message will be shown to the user if he entered a not valid input so it will help him to enter a valid input
                    Console.WriteLine("that is not a valid input");
                    Console.WriteLine("HINT for a valid input");
                    Console.WriteLine("    [0] Input must be an intger.");
                    Console.WriteLine("    [1] The intger must be between 2 and 1000.");
                    Console.WriteLine(".....PLEASE TRY AGIN.....");
                }
            }
        }
        public static void PerfectNumProgram()
        {
            // looping to get all nummbers in the given domain
            for (int Number = 2; Number <= 1000; Number++)
            {
                // Declaraing a variable to store the sum of factors and resting it in each loop for the outer loop
                int sum = 0;
                // getting the all possible factores to each number in the outer loop
                for (int possibleFactor = 1; possibleFactor < Number; possibleFactor++)
                {
                    // searching for real factors
                    if (Number % possibleFactor == 0)
                    {
                        // adding all real factors together
                        sum += possibleFactor;
                    }
                }
                // checking if the number is perfect or not
                if (Number == sum)
                {
                    // showing the user the perfect number
                    Console.Write("[+] {0} is a perfect Number \n", Number);
                    // printing the factors to screen
                    Console.Write("[+] Factors: ");
                    // getting the factors agin to show the user
                    for (int factor = 1; factor < Number; factor++)
                    {
                        // checking for real factors
                        if (Number % factor == 0)
                        {
                            // printing the real factors
                            Console.Write("{0} ", factor);
                        }
                    }
                    // proving taht the number is perfect to user by printing the sum of the factors and the number
                    Console.WriteLine();
                    Console.WriteLine("[+] Sum of its factors {0} = Number {1}", sum, Number);
                    Console.WriteLine("-------------------------------------");
                }
            }
        }
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Choose Operation From 1-3");
                Console.WriteLine("[1] Printing Perfect Numbers From 2 - 1000");
                Console.WriteLine("[2] Test If A Number Is Perfect Or Not");
                Console.WriteLine("[3] Find Greatest Common Divisor (GCD) Of Two Numbers");
                bool isValid = false;
                int op;
                do
                {
                    Console.Write("Enter A Number: ");
                    if (int.TryParse(Console.ReadLine(), out op))
                        if (op > 0 && op <= 3)
                            isValid = true;
                        else
                            Console.WriteLine("please enter an intger between 1 and 3");
                } while (!isValid);
                switch (op)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Executing the programe [Printing Perfect Numbers From 2 -1000]\n");
                        PerfectNumProgram();
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Executing the programe [Test If A Number Is Perfect Or Not]\n");
                        PerfectNumbCheckProgram();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Executing the programe [Find Greatest Common Divisor (GCD) Of Two Numbers]\n");
                        GDRProgram();
                        break;
                }
                Console.Write("Do You Want To Try Again (y or any other charcter to exit29) ");
                string pass = Console.ReadLine();
                if (!(pass == "y" || pass == "Y"))
                    break;
            } while (true);
            Console.WriteLine(".....Have A Good Day.....");
        }
    }
}
