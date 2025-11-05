using System;
using System.Threading.Tasks;

namespace OOP_finalProject
{
    /// <summary>
    /// Test class để kiểm tra Singleton pattern của UserSession
    /// </summary>
    public class SingletonTest
    {
        public static void TestSingletonPattern()
        {
            Console.WriteLine("=== Testing UserSession Singleton Pattern ===");

            // Test 1: Kiểm tra chỉ có một instance duy nhất
            var session1 = UserSession.Instance;
            var session2 = UserSession.Instance;

            Console.WriteLine($"Test 1 - Same instance: {ReferenceEquals(session1, session2)}");

            // Test 2: Kiểm tra thread safety
            Console.WriteLine("Test 2 - Testing thread safety...");
            var tasks = new Task[5];
            var results = new bool[5];

            for (int i = 0; i < 5; i++)
            {
                int index = i;
                tasks[i] = Task.Run(() =>
                {
                    var session = UserSession.Instance;
                    results[index] = ReferenceEquals(session, session1);
                });
            }

            Task.WaitAll(tasks);
            bool allSame = true;
            for (int i = 0; i < 5; i++)
            {
                if (!results[i])
                {
                    allSame = false;
                    break;
                }
            }

            Console.WriteLine($"All threads got same instance: {allSame}");

            // Test 3: Kiểm tra chức năng cơ bản
            Console.WriteLine("Test 3 - Testing basic functionality...");
            session1.SetUserInfo("testuser", "admin", "Test User", "test@example.com");

            Console.WriteLine($"Username: {session1.Username}");
            Console.WriteLine($"Role: {session1.Role}");
            Console.WriteLine($"IsLoggedIn: {session1.IsLoggedIn()}");
            Console.WriteLine($"DisplayName: {session1.GetDisplayName()}");
            Console.WriteLine($"RoleDisplayName: {session1.GetRoleDisplayName()}");

            // Test 4: Kiểm tra clear session
            Console.WriteLine("Test 4 - Testing clear session...");
            session1.ClearUserInfo();
            Console.WriteLine($"After clear - IsLoggedIn: {session1.IsLoggedIn()}");
            Console.WriteLine($"Username after clear: '{session1.Username}'");

            Console.WriteLine("=== Singleton Test Completed ===");
        }
    }
}
