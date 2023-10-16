using System;

namespace DesencriptarMembershipAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
                return;

            var membership = new MembershipPasswordRecovery();
            Console.WriteLine("Password: {0}", membership.GetClearTextPassword(args[0]));
            Console.WriteLine("\nPresione enter para finalizar");
            Console.ReadLine();
        }
    }
}