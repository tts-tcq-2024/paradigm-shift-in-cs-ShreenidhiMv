using System;
using System.Diagnostics;
 
namespace paradigm_shift_csharp
{
class BatteryChecker
{
     static bool IsTemperatureOutOfRange(float temperature)
     {
         return temperature < 0 || temperature > 45;
     }
 
     static bool IsSocOutOfRange(float soc)
     {
         return soc < 20 || soc > 80;
     }
 
     static bool IsChargeRateOutOfRange(float chargeRate)
     {
         return chargeRate > 0.8;
     }
 
     static bool IsBatteryOk(float temperature, float soc, float chargeRate)
     {
         if (IsTemperatureOutOfRange(temperature))
         {
             Console.WriteLine("Temperature is out of range!");
             return false;
         }
         else if (IsSocOutOfRange(soc))
         {
             Console.WriteLine("State of Charge is out of range!");
             return false;
         }
         else if (IsChargeRateOutOfRange(chargeRate))
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
