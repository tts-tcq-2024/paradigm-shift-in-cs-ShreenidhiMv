using System;
namespace paradigm_shift_csharp
{
class BatteryChecker
{
     static bool IsOutOfRange(float value, float min, float max) => value < min || value > max;
     static bool IsBatteryOk(float temperature, float soc, float chargeRate)
     {
         if (IsOutOfRange(temperature, 0, 45))
         {
             Console.WriteLine("Temperature is out of range!");
             return false;
         }
         if (IsOutOfRange(soc, 20, 80))
         {
             Console.WriteLine("State of Charge is out of range!");
             return false;
         }
         if (chargeRate > 0.8)
         {
             Console.WriteLine("Charge Rate is out of range!");
             return false;
         }
         return true;
     }
     static void ExpectTrue(bool expression, string message)
     {
         if (!expression)
         {
             Console.WriteLine("Expected true, but got false - " + message);
             Environment.Exit(1);
         }
     }
     static void ExpectFalse(bool expression, string message)
     {
         if (expression)
         {
             Console.WriteLine("Expected false, but got true - " + message);
             Environment.Exit(1);
         }
     }
     static void Main()
     {
         ExpectTrue(IsBatteryOk(25, 70, 0.7f), "Test 1");
         ExpectFalse(IsBatteryOk(50, 85, 0.0f), "Test 2");
         Console.WriteLine("All tests passed. Battery is ok.");
     }
}
}
