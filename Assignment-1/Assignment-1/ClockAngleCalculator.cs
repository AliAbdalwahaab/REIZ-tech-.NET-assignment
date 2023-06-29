namespace Assignment
{
    class ClockAngleCalculator
    {
        //Verify that the user input falls in expected range.
        static bool verifyUserInput(int hours, int minutes)
        {
            if (hours < 0 || minutes < 0 || hours > 12 || minutes > 59)
            {
                Console.Write("Out of range input. Expected range: 0 <= hours <= 12 | 0 <= minutes <= 59 \n");
                Console.WriteLine("__________________________________________________________________ \n");
                return false;
            }

            return true;
        }

        //Calculate the angle based on user input.
        static String getAngle(int hours, int minutes)
        {
            //If the hours hand is on the 12th hour, it is regarded the same as the 0th hour, angle 360 == 0.
            if (hours == 12) hours = 0;

            // Get the angle of each hand based on how far it traveled from 00:00. read README-1 in repo to checkout the calculation method and assumptions.
                int hours_hand_angle = (int) (( (hours * 60) + minutes) * 0.5);
                Console.Write("\n Hours hand angle from origin: " + hours_hand_angle + " degrees. | ");

                int minutes_hand_angle = (6 * minutes);
                Console.WriteLine("Minutes hand angle from origin: " + minutes_hand_angle + " degrees.");

            // Subtract the two angles to get their absolute difference.
                int difference = Math.Abs(hours_hand_angle - minutes_hand_angle);

            // Get the required lesser angle.
                int angle = (difference > 180) ? 360 - difference : difference;

            return "\n Angle between hours and minutes hands is: " + angle.ToString() + " degrees. \n" +
                "__________________________________________________________________ \n";
        }

        public static void Main()
        {
            Console.WriteLine("Please note that all inputs are assumed to be in 12hr format: min -> 00:00 | max -> 12:59 \n");

            while (true)
            {
                Console.Write("Enter Hours: ");
                int hours = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Minutes: ");
                int minutes = Convert.ToInt32(Console.ReadLine());

                if (!verifyUserInput(hours, minutes)) 
                {
                    Main();
                }

                else
                {
                    Console.WriteLine(getAngle(hours, minutes));
                }
            }
        }
    }

}