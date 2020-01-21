using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Exceptions
{
    public class CustomException
    {
        public void ThrowException()
        {
            try
            {
                try
                {
                    throw new Exception($"forced exception at {nameof(CustomException)}");
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine($"called finally block at {nameof(CustomException)}");
            }
        }
    }
}
