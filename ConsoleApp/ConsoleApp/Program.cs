using System;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Directives;
using ConsoleApp.Exceptions;
using ConsoleApp.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TestLineDirectives();
            //TestTryCatchAtCustomeException();
            //await TestTasksExceptions();
            //await TestMultithread();

            //await TestNestedTask();

            await TestGenerateCrc16Code();

            Console.WriteLine();
            Console.WriteLine("ended!!!");
        }

        static void TestLineDirectives()
        {
            new LineDirective().WriteLines();
        }

        static void TestTryCatchAtCustomeException()
        {
            new CustomException().ThrowException();
        }

        static async Task TestTasksExceptions()
        {
            await new TestTasks().RunTasksWithExceptionAsync();
        }

        static async Task TestMultithread()
        {
            await new TestMultithread().RunMultithreadTasksAsync();
        }

        static async Task TestNestedTask()
        {
            await new TestNestedTask().CallTestClassAsync();
        }

        static async Task TestGenerateCrc16Code()
        {
            var code = "00020101021226850014br.gov.bcb.pix2563pix.santander.com.br/qr/v1/1edc73e3-cb6b-420e-a43a-00cfdde3288b520400005303986540520.005802BR5925DANILO NOVAIS DE OLIVEIRA6009SAO PAULO62070503***6304";
            var crcGenerator = new Crc16Ccitt(InitialCrcValue.NonZero1);

            var codeArray = Encoding.ASCII.GetBytes(code);
            var result = crcGenerator.ComputeChecksumBytes(codeArray);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(result);

            var strResult = BitConverter.ToString(result);

            await Task.CompletedTask;
        }
    }
}
