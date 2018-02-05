using DataModel;

namespace Test
{
    [testc]
    public class SqlDatabaseSetup
    {

        //[AssemblyInitialize()]
        //public static void InitializeAssembly(TestContext ctx)
        //{
        //    // Setup the test database based on setting in the
        //    // configuration file
        //    SqlDatabaseTestClass.TestService.DeployDatabaseProject();
        //    SqlDatabaseTestClass.TestService.GenerateData();
        //}
        [testc]
        public void test1()
        {


            using (var db = new PFEDatabase())
            {
                db.Users.Add(new Users()
                {
                    UserEmail = "aaaaa",
                    AspNetUserId = "aaaaaaaa"
                });
                db.SaveChanges();

            }

        }


    }
}
