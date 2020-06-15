namespace Assignment_MVC.Database.Migrations
{
    using Assignment_MVC.Database;
    using Assignment_MVC.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDatabase context)
        {
            #region SEED SCHOOL PROJECT

            //==================== Seeding Courses ===============================
            Course c1 = new Course() { Title = "CBC7-C#", Stream = "C#", StartDate = new DateTime(2019, 10, 25), EndDate = new DateTime(2020, 03, 15) };
            Course c2 = new Course() { Title = "CBJ7-Java", Stream = "Java", StartDate = new DateTime(2019, 11, 05), EndDate = new DateTime(2020, 05, 30) };
            Course c3 = new Course() { Title = "CBP8-Python", Stream = "Python", StartDate = new DateTime(2019, 09, 25), EndDate = new DateTime(2020, 03, 15) };
            Course c4 = new Course() { Title = "CBJS8-JavaSript", Stream = "JavaSript", StartDate = new DateTime(2019, 11, 05), EndDate = new DateTime(2020, 02, 05) };
            Course c5 = new Course() { Title = "CBQ9-RDBMS", Stream = "RDBMS", StartDate = new DateTime(2019, 12, 05), EndDate = new DateTime(2020, 03, 30) };


            //==================== Seeding Trainers ===============================
            Trainer tr1 = new Trainer() { FirstName = "George", LastName = "Pasparakis", PhotoUrl = "https://media-exp1.licdn.com/dms/image/C4E03AQFWuZhYfo-rbg/profile-displayphoto-shrink_200_200/0?e=1586995200&v=beta&t=TCz1Q7XZmTArKTRnGIJGlsVJGR1_Hv6aYFq2kA2NrTE", DateOfBirth = new DateTime(1970, 10, 25), Email = "pasparakis@gmail.com", Telephone = "6985965584", Salary = 2650D, Country = Country.Greece };
            Trainer tr2 = new Trainer() { FirstName = "Konstantinos", LastName = "Zitis", PhotoUrl = "data:image/jpeg;base64,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", DateOfBirth = new DateTime(1972, 01, 05), Email = "zitis@gmail.com", Telephone = "6978458741", Salary = 2100D, Country = Country.Greece };
            Trainer tr3 = new Trainer() { FirstName = "Ektoras", LastName = "Gkatsos", PhotoUrl = "http://www.spoudasefest.gr/sites/default/files/styles/square/public/fotografia_gkatsos_1.jpg?itok=b24D-IUm", DateOfBirth = new DateTime(1987, 04, 07), Email = "gatsos@gmail.com", Telephone = "6944210303", Salary = 2900D, Country = Country.Greece };
            Trainer tr4 = new Trainer() { FirstName = "Kostas", LastName = "Stroggylos", PhotoUrl = "https://agilesummit.gr/wp-content/uploads/2019/09/image.png", DateOfBirth = new DateTime(1975, 03, 14), Email = "stroggylos@gmail.com", Telephone = "6956425063", Salary = 2300D, Country = Country.Greece };
            Trainer tr5 = new Trainer() { FirstName = "Vasilis", LastName = "Tzelepopoulos", PhotoUrl = "https://pbs.twimg.com/profile_images/955488926365569024/GnDMMyGf.jpg", DateOfBirth = new DateTime(1974, 10, 19), Email = "tzelepopoulos@gmail.com", Telephone = "6990265474", Salary = 2100D, Country = Country.Greece };
            Trainer tr6 = new Trainer() { FirstName = "Kostas", LastName = "Minaidis", PhotoUrl = "data:image/jpeg;base64,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", DateOfBirth = new DateTime(1980, 05, 27), Email = "minaidis@gmail.com", Telephone = "6598430624", Salary = 2100D, Country = Country.Greece };
            Trainer tr7 = new Trainer() { FirstName = "Panagiotis", LastName = "Bozas", PhotoUrl = "https://media-exp1.licdn.com/dms/image/C5103AQHapdeJGARTlw/profile-displayphoto-shrink_200_200/0?e=1586995200&v=beta&t=c4441f72qyg31oDrrvaJm7DkVSvbClwJ3KJQor3PeQk", DateOfBirth = new DateTime(1982, 07, 18), Email = "bozas@gmail.com", Telephone = "6978201415", Salary = 1800D, Country = Country.Greece };

            //==================== Seeding Students ===============================
            Student st1 = new Student() { FirstName = "Giorgos", LastName = "Poulakos", PhotoUrl = "https://i1.wp.com/www.eoric.uenr.edu.gh/wp-content/uploads/2019/08/male-profile-blank.jpg?ssl=1", DateOfBirth = new DateTime(1988, 05, 12), Email = "poulakos@gmail.com", Telephone = "6978234015", Country = Country.Greece };
            Student st2 = new Student() { FirstName = "Thanos", LastName = "Christidis", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1987, 03, 25), Email = "christidis@gmail.com", Telephone = "6974152568", Country = Country.Greece };
            Student st3 = new Student() { FirstName = "Kyriakos", LastName = "Zotiadis", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1990, 06, 05), Email = "zotiadis@gmail.com", Telephone = "6944527895", Country = Country.Greece };
            Student st4 = new Student() { FirstName = "Eleni", LastName = "Parisi", PhotoUrl = "https://cdn.clipart.email/7c313c61d9112b29a6631cf6ec0e218c_facebook-silhouette-female_500-476.jpeg", DateOfBirth = new DateTime(1989, 11, 22), Email = "parisi@gmail.com", Telephone = "6945987652", Country = Country.Greece };
            Student st5 = new Student() { FirstName = "Stathis", LastName = "Kanellis", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1981, 04, 12), Email = "kanellis@gmail.com", Telephone = "6975201415", Country = Country.Greece };
            Student st6 = new Student() { FirstName = "Ioannis", LastName = "Manthos", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1979, 09, 20), Email = "manthos@gmail.com", Telephone = "6982525369", Country = Country.Greece };
            Student st7 = new Student() { FirstName = "Zacharias", LastName = "Drimiskianakis", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1989, 07, 30), Email = "drimiskianakis@gmail.com", Telephone = "6988201444", Country = Country.Greece };
            Student st8 = new Student() { FirstName = "Xenofontas", LastName = "Vlachogiannis", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1985, 01, 28), Email = "vlachogiannis@gmail.com", Telephone = "6955415897", Country = Country.Greece };
            Student st9 = new Student() { FirstName = "Panagiotis", LastName = "Rizos", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1987, 06, 11), Email = "rizos@gmail.com", Telephone = "6944141516", Country = Country.Greece };
            Student st10 = new Student() { FirstName = "Alexandros", LastName = "Perikleous", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1990, 07, 10), Email = "perikleous@gmail.com", Telephone = "6978201415", Country = Country.Greece };
            Student st11 = new Student() { FirstName = "Albi", LastName = "Alikaj", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1983, 05, 02), Email = "alikaj@gmail.com", Telephone = "6972201201", Country = Country.Greece };
            Student st12 = new Student() { FirstName = "Alexandros", LastName = "Nomikos", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1988, 03, 05), Email = "nomikos@gmail.com", Telephone = "6973507080", Country = Country.Greece };
            Student st13 = new Student() { FirstName = "Athanasios", LastName = "Kontodimas", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1989, 02, 15), Email = "kontodimas@gmail.com", Telephone = "6944251547", Country = Country.Greece };
            Student st14 = new Student() { FirstName = "Christos", LastName = "Vasilakis", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1991, 10, 22), Email = "vasilakis@gmail.com", Telephone = "6949015311", Country = Country.Greece };
            Student st15 = new Student() { FirstName = "Dionysios", LastName = "Pilikas", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1983, 06, 27), Email = "pilikas@gmail.com", Telephone = "6943241599", Country = Country.Greece };
            Student st16 = new Student() { FirstName = "Thanos", LastName = "Katrakis", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1988, 09, 07), Email = "katrakis@gmail.com", Telephone = "6935415311", Country = Country.Greece };
            Student st17 = new Student() { FirstName = "Evangelos", LastName = "Koutsogiorgos", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1982, 04, 30), Email = "koutsogiorgos@gmail.com", Telephone = "6980200400", Country = Country.Greece };
            Student st18 = new Student() { FirstName = "Kostantinos", LastName = "Argyropoulos", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1986, 11, 21), Email = "argyropoulos@gmail.com", Telephone = "6945987455", Country = Country.Greece };
            Student st19 = new Student() { FirstName = "Karol", LastName = "Koniewicz", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1987, 10, 15), Email = "koniewicz@gmail.com", Telephone = "6972564847", Country = Country.Greece };
            Student st20 = new Student() { FirstName = "Vasileios", LastName = "Theodoropoulos", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1990, 01, 10), Email = "theodoropoulos@gmail.com", Telephone = "6972001414", Country = Country.Greece };
            Student st21 = new Student() { FirstName = "Anastasia", LastName = "Tsiropoulou", PhotoUrl = "https://cdn.clipart.email/7c313c61d9112b29a6631cf6ec0e218c_facebook-silhouette-female_500-476.jpeg", DateOfBirth = new DateTime(1995, 10, 29), Email = "tsiropoulou@gmail.com", Telephone = "6982555777", Country = Country.Greece };
            Student st22 = new Student() { FirstName = "Nikoleta", LastName = "Evaggelou", PhotoUrl = "https://cdn.clipart.email/7c313c61d9112b29a6631cf6ec0e218c_facebook-silhouette-female_500-476.jpeg", DateOfBirth = new DateTime(1983, 12, 22), Email = "evaggelou@gmail.com", Telephone = "6975254110", Country = Country.Greece };
            Student st23 = new Student() { FirstName = "Nikos", LastName = "Nikolakis", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1986, 03, 07), Email = "nikolakis@gmail.com", Telephone = "6944414546", Country = Country.Greece };
            Student st24 = new Student() { FirstName = "Polina", LastName = "Aggelopoulou", PhotoUrl = "https://cdn.clipart.email/7c313c61d9112b29a6631cf6ec0e218c_facebook-silhouette-female_500-476.jpeg", DateOfBirth = new DateTime(1991, 05, 01), Email = "aggelopoulos@gmail.com", Telephone = "6943201900", Country = Country.Greece };
            Student st25 = new Student() { FirstName = "Evaggelia", LastName = "Barella", PhotoUrl = "https://cdn.clipart.email/7c313c61d9112b29a6631cf6ec0e218c_facebook-silhouette-female_500-476.jpeg", DateOfBirth = new DateTime(1990, 06, 20), Email = "barella@gmail.com", Telephone = "6972409015", Country = Country.Greece };
            Student st26 = new Student() { FirstName = "Lefteris", LastName = "Dimitropoulos", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1987, 09, 15), Email = "dimitropoulos@gmail.com", Telephone = "6973010415", Country = Country.Greece };
            Student st27 = new Student() { FirstName = "Giorgos", LastName = "Tzanetos", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1989, 08, 19), Email = "tzanetos@gmail.com", Telephone = "6988014255", Country = Country.Greece };
            Student st28 = new Student() { FirstName = "Katerina", LastName = "Kremastinou", PhotoUrl = "https://cdn.clipart.email/7c313c61d9112b29a6631cf6ec0e218c_facebook-silhouette-female_500-476.jpeg", DateOfBirth = new DateTime(1982, 04, 02), Email = "kremastinou@gmail.com", Telephone = "6975789123", Country = Country.Greece };
            Student st29 = new Student() { FirstName = "Viki", LastName = "Sidiropoulou", PhotoUrl = "https://cdn.clipart.email/7c313c61d9112b29a6631cf6ec0e218c_facebook-silhouette-female_500-476.jpeg", DateOfBirth = new DateTime(1981, 02, 15), Email = "sidiropoulou@gmail.com", Telephone = "6944131588", Country = Country.Greece };
            Student st30 = new Student() { FirstName = "Marios", LastName = "Karras", PhotoUrl = "https://st.depositphotos.com/2218212/2938/i/950/depositphotos_29387653-stock-photo-facebook-profile.jpg", DateOfBirth = new DateTime(1985, 01, 17), Email = "karras@gmail.com", Telephone = "6982447110", Country = Country.Greece };
            //==================== Seeding Assignments ===============================
            Assignment a1 = new Assignment() { Title = "C#Project_A", Description = "Design_School", SubTime = new DateTime(2020, 01, 10) };
            Assignment a2 = new Assignment() { Title = "C#Project_B", Description = "Design_Hospital", SubTime = new DateTime(2020, 02, 10) };
            Assignment a3 = new Assignment() { Title = "C#Project_C", Description = "Design_Library", SubTime = new DateTime(2020, 03, 01) };
            Assignment a4 = new Assignment() { Title = "C#Project_D", Description = "Design_E_Shop", SubTime = new DateTime(2020, 03, 30) };
            Assignment a5 = new Assignment() { Title = "JavaProject_A", Description = "Design_School", SubTime = new DateTime(2020, 01, 10) };
            Assignment a6 = new Assignment() { Title = "JavaProject_B", Description = "Design_Hospital", SubTime = new DateTime(2020, 02, 10) };
            Assignment a7 = new Assignment() { Title = "JavaProject_C", Description = "Design_Library", SubTime = new DateTime(2020, 03, 01) };
            Assignment a8 = new Assignment() { Title = "JavaProject_D", Description = "Design_E_Shop", SubTime = new DateTime(2020, 04, 30) };
            Assignment a9 = new Assignment() { Title = "JSProject_A", Description = "Design_School", SubTime = new DateTime(2020, 01, 10) };
            Assignment a10 = new Assignment() { Title = "JSProject_B", Description = "Design_Hospital", SubTime = new DateTime(2020, 02, 10) };
            Assignment a11 = new Assignment() { Title = "JSProject_C", Description = "Design_Library", SubTime = new DateTime(2020, 03, 01) };
            Assignment a12 = new Assignment() { Title = "JSProject_D", Description = "Design_E_Shop", SubTime = new DateTime(2020, 03, 30) };
            Assignment a13 = new Assignment() { Title = "SqlProject_A", Description = "Design_School", SubTime = new DateTime(2020, 01, 10) };
            Assignment a14 = new Assignment() { Title = "SqlProject_B", Description = "Design_Hospital", SubTime = new DateTime(2020, 02, 10) };
            Assignment a15 = new Assignment() { Title = "SqlProject_C", Description = "Design_Library", SubTime = new DateTime(2020, 03, 01) };
            Assignment a16 = new Assignment() { Title = "SqlProject_D", Description = "Design_E_Shop", SubTime = new DateTime(2020, 03, 01) };
            Assignment a17 = new Assignment() { Title = "PythonProject_A", Description = "Design_School", SubTime = new DateTime(2020, 03, 01) };
            Assignment a18 = new Assignment() { Title = "PythonProject_C", Description = "Design_Hospital", SubTime = new DateTime(2020, 03, 01) };
            Assignment a19 = new Assignment() { Title = "PythonProject_B", Description = "Design_Library", SubTime = new DateTime(2020, 03, 01) };
            Assignment a20 = new Assignment() { Title = "PythonProject_D", Description = "Design_E_Shop", SubTime = new DateTime(2020, 03, 01) };

            //==================== Seeding TutionFees ===============================
            TutionFees f1 = new TutionFees() { CodeCourse = "C#9Oct", Cost = 2700D };
            TutionFees f2 = new TutionFees() { CodeCourse = "Java19Nov", Cost = 2500D };
            TutionFees f3 = new TutionFees() { CodeCourse = "Python19Sep", Cost = 1500D };
            TutionFees f4 = new TutionFees() { CodeCourse = "JavaScript19Nov", Cost = 2100D };
            TutionFees f5 = new TutionFees() { CodeCourse = "Sql19Dec", Cost = 1900D };

            //==================== Seeding MarkAssignments ===============================
            MarkAssignment m1 = new MarkAssignment() { MarkCode = "ProjASt1", TotalMark = 85, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m2 = new MarkAssignment() { MarkCode = "ProjBSt1", TotalMark = 87, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m3 = new MarkAssignment() { MarkCode = "ProjCSt2", TotalMark = 78, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m4 = new MarkAssignment() { MarkCode = "ProjDSt2", TotalMark = 89, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m5 = new MarkAssignment() { MarkCode = "ProjASt3", TotalMark = 86, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m6 = new MarkAssignment() { MarkCode = "ProjBSt3", TotalMark = 81, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m7 = new MarkAssignment() { MarkCode = "ProjASt4", TotalMark = 80, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m8 = new MarkAssignment() { MarkCode = "ProjDSt4", TotalMark = 79, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m9 = new MarkAssignment() { MarkCode = "ProjBSt4", TotalMark = 94, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m10 = new MarkAssignment() { MarkCode = "ProjCSt5", TotalMark = 91, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m11 = new MarkAssignment() { MarkCode = "ProjDSt5", TotalMark = 89, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m12 = new MarkAssignment() { MarkCode = "ProjCSt6", TotalMark = 76, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m13 = new MarkAssignment() { MarkCode = "ProjBSt6", TotalMark = 80, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m14 = new MarkAssignment() { MarkCode = "ProjASt7", TotalMark = 81, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m15 = new MarkAssignment() { MarkCode = "ProjBSt7", TotalMark = 89, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m16 = new MarkAssignment() { MarkCode = "ProjBSt8", TotalMark = 88, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m17 = new MarkAssignment() { MarkCode = "ProjCSt8", TotalMark = 87, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m18 = new MarkAssignment() { MarkCode = "ProjDSt8", TotalMark = 92, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m19 = new MarkAssignment() { MarkCode = "ProjASt9", TotalMark = 94, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m20 = new MarkAssignment() { MarkCode = "ProjCSt9", TotalMark = 80, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m21 = new MarkAssignment() { MarkCode = "ProjCSt10", TotalMark = 90, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m22 = new MarkAssignment() { MarkCode = "ProjDSt10", TotalMark = 73, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m23 = new MarkAssignment() { MarkCode = "ProjCSt11", TotalMark = 82, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m24 = new MarkAssignment() { MarkCode = "ProjDSt11", TotalMark = 74, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m25 = new MarkAssignment() { MarkCode = "ProjASt12", TotalMark = 72, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m26 = new MarkAssignment() { MarkCode = "ProjDSt12", TotalMark = 71, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m27 = new MarkAssignment() { MarkCode = "ProjASt13", TotalMark = 75, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m28 = new MarkAssignment() { MarkCode = "ProjBSt13", TotalMark = 85, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m29 = new MarkAssignment() { MarkCode = "ProjCSt13", TotalMark = 81, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m30 = new MarkAssignment() { MarkCode = "ProjDSt14", TotalMark = 80, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m31 = new MarkAssignment() { MarkCode = "ProjASt14", TotalMark = 89, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m32 = new MarkAssignment() { MarkCode = "ProjDSt15", TotalMark = 88, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m33 = new MarkAssignment() { MarkCode = "ProjASt15", TotalMark = 87, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m34 = new MarkAssignment() { MarkCode = "ProjASt16", TotalMark = 90, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m35 = new MarkAssignment() { MarkCode = "ProjBSt16", TotalMark = 92, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m36 = new MarkAssignment() { MarkCode = "ProjCSt17", TotalMark = 79, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m37 = new MarkAssignment() { MarkCode = "ProjBSt17", TotalMark = 80, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m38 = new MarkAssignment() { MarkCode = "ProjCSt18", TotalMark = 81, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m39 = new MarkAssignment() { MarkCode = "ProjASt18", TotalMark = 82, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m40 = new MarkAssignment() { MarkCode = "ProjASt19", TotalMark = 83, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m41 = new MarkAssignment() { MarkCode = "ProjBSt19", TotalMark = 84, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m42 = new MarkAssignment() { MarkCode = "ProjDSt19", TotalMark = 90, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m43 = new MarkAssignment() { MarkCode = "ProjCSt20", TotalMark = 79, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m44 = new MarkAssignment() { MarkCode = "ProjASt20", TotalMark = 78, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m45 = new MarkAssignment() { MarkCode = "ProjASt21", TotalMark = 77, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m46 = new MarkAssignment() { MarkCode = "ProjBSt21", TotalMark = 76, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m47 = new MarkAssignment() { MarkCode = "ProjBSt22", TotalMark = 75, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m48 = new MarkAssignment() { MarkCode = "ProjDSt22", TotalMark = 89, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m49 = new MarkAssignment() { MarkCode = "ProjBSt23", TotalMark = 88, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m50 = new MarkAssignment() { MarkCode = "ProjASt23", TotalMark = 87, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m51 = new MarkAssignment() { MarkCode = "ProjASt24", TotalMark = 89, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m52 = new MarkAssignment() { MarkCode = "ProjDSt24", TotalMark = 88, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m53 = new MarkAssignment() { MarkCode = "ProjASt25", TotalMark = 90, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m54 = new MarkAssignment() { MarkCode = "ProjCSt25", TotalMark = 91, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m55 = new MarkAssignment() { MarkCode = "ProjBSt26", TotalMark = 92, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m56 = new MarkAssignment() { MarkCode = "ProjCSt26", TotalMark = 90, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m57 = new MarkAssignment() { MarkCode = "ProjCSt27", TotalMark = 89, EndTime = new DateTime(2020, 03, 12) };
            MarkAssignment m58 = new MarkAssignment() { MarkCode = "ProjASt28", TotalMark = 87, EndTime = new DateTime(2019, 05, 02) };
            MarkAssignment m59 = new MarkAssignment() { MarkCode = "ProjASt29", TotalMark = 88, EndTime = new DateTime(2020, 05, 09) };
            MarkAssignment m60 = new MarkAssignment() { MarkCode = "ProjDSt29", TotalMark = 82, EndTime = new DateTime(2020, 08, 10) };
            MarkAssignment m61 = new MarkAssignment() { MarkCode = "ProjDSt30", TotalMark = 80, EndTime = new DateTime(2019, 05, 20) };
            MarkAssignment m62 = new MarkAssignment() { MarkCode = "ProjBSt30", TotalMark = 81, EndTime = new DateTime(2020, 03, 12) };




            //================= Add TutionFees to Course =======================                                                            

            c1.TutionFees = f1;
            c2.TutionFees = f2;
            c3.TutionFees = f3;
            c4.TutionFees = f4;
            c5.TutionFees = f5;

            //================= Add Mark to Student Assignments =======================


            st1.MarkAssignments = new List<MarkAssignment>() { m1, m2 };
            st2.MarkAssignments = new List<MarkAssignment>() { m3, m4 };
            st3.MarkAssignments = new List<MarkAssignment>() { m5, m6 };
            st4.MarkAssignments = new List<MarkAssignment>() { m7, m8, m9 };
            st5.MarkAssignments = new List<MarkAssignment>() { m10, m11 };
            st6.MarkAssignments = new List<MarkAssignment>() { m12, m13 };
            st7.MarkAssignments = new List<MarkAssignment>() { m14, m15 };
            st8.MarkAssignments = new List<MarkAssignment>() { m16, m17, m18 };
            st9.MarkAssignments = new List<MarkAssignment>() { m19, m20 };
            st10.MarkAssignments = new List<MarkAssignment>() { m21, m22 };
            st11.MarkAssignments = new List<MarkAssignment>() { m23, m24 };
            st12.MarkAssignments = new List<MarkAssignment>() { m25, m26 };
            st13.MarkAssignments = new List<MarkAssignment>() { m27, m28, m29 };
            st14.MarkAssignments = new List<MarkAssignment>() { m30, m31 };
            st15.MarkAssignments = new List<MarkAssignment>() { m32, m33 };
            st16.MarkAssignments = new List<MarkAssignment>() { m34, m35 };
            st17.MarkAssignments = new List<MarkAssignment>() { m36, m37 };
            st18.MarkAssignments = new List<MarkAssignment>() { m38, m39 };
            st19.MarkAssignments = new List<MarkAssignment>() { m40, m41, m42 };
            st20.MarkAssignments = new List<MarkAssignment>() { m43, m44 };
            st21.MarkAssignments = new List<MarkAssignment>() { m45, m46 };
            st22.MarkAssignments = new List<MarkAssignment>() { m47, m48 };
            st23.MarkAssignments = new List<MarkAssignment>() { m49, m50 };
            st24.MarkAssignments = new List<MarkAssignment>() { m51, m52 };
            st25.MarkAssignments = new List<MarkAssignment>() { m53, m54 };
            st26.MarkAssignments = new List<MarkAssignment>() { m55, m56 };
            st27.MarkAssignments = new List<MarkAssignment>() { m57 };
            st28.MarkAssignments = new List<MarkAssignment>() { m58 };
            st29.MarkAssignments = new List<MarkAssignment>() { m59, m60 };
            st30.MarkAssignments = new List<MarkAssignment>() { m61, m62 };

            a1.MarkAssignments = new List<MarkAssignment>() { m1, m5, m7 };
            a2.MarkAssignments = new List<MarkAssignment>() { m2, m6, m9, m13 };
            a3.MarkAssignments = new List<MarkAssignment>() { m3, m10, m12 };
            a4.MarkAssignments = new List<MarkAssignment>() { m4, m8, m11 };
            a5.MarkAssignments = new List<MarkAssignment>() { m14, m19, m25 };
            a6.MarkAssignments = new List<MarkAssignment>() { m15, m16 };
            a7.MarkAssignments = new List<MarkAssignment>() { m17, m20, m21, m23 };
            a8.MarkAssignments = new List<MarkAssignment>() { m18, m22, m24, m26 };
            a9.MarkAssignments = new List<MarkAssignment>() { m27, m31, m33, m34, m39 };
            a10.MarkAssignments = new List<MarkAssignment>() { m28, m35, m37 };
            a11.MarkAssignments = new List<MarkAssignment>() { m29, m38 };
            a12.MarkAssignments = new List<MarkAssignment>() { m30, m32, m36 };
            a13.MarkAssignments = new List<MarkAssignment>() { m40, m44, m45, m50, m51 };
            a14.MarkAssignments = new List<MarkAssignment>() { m41, m46, m47, m49 };
            a15.MarkAssignments = new List<MarkAssignment>() { m43 };
            a16.MarkAssignments = new List<MarkAssignment>() { m42, m48, m52 };
            a17.MarkAssignments = new List<MarkAssignment>() { m53, m58, m59 };
            a18.MarkAssignments = new List<MarkAssignment>() { m55, m60, m62 };
            a19.MarkAssignments = new List<MarkAssignment>() { m54, m56, m57 };
            a20.MarkAssignments = new List<MarkAssignment>() { m61 };


            //================= Add Students to Course =====================
            c1.Students = new List<Student>() { st1, st2, st3, st4, st5, st6 };
            c2.Students = new List<Student>() { st7, st8, st9, st10, st11, st12 };
            c3.Students = new List<Student>() { st13, st14, st15, st16, st17, st18 };
            c4.Students = new List<Student>() { st19, st20, st21, st22, st23, st24 };
            c5.Students = new List<Student>() { st25, st26, st27, st28, st29, st30 };

            //================= Add Assignment to Course ===================
            c1.Assignments = new List<Assignment>() { a1, a2, a3, a4 };
            c2.Assignments = new List<Assignment>() { a5, a6, a7, a8 };
            c3.Assignments = new List<Assignment>() { a17, a18, a19, a20 };
            c4.Assignments = new List<Assignment>() { a9, a10, a11, a12 };
            c5.Assignments = new List<Assignment>() { a13, a14, a15, a16 };


            //================= Add Trainers to Courses ====================
            tr1.Courses = new List<Course>() { c2, c5 };
            tr2.Courses = new List<Course>() { c1, c3 };
            tr3.Courses = new List<Course>() { c1, c4, c5 };
            tr4.Courses = new List<Course>() { c2, c5 };
            tr5.Courses = new List<Course>() { c1, c4 };
            tr6.Courses = new List<Course>() { c4 };
            tr7.Courses = new List<Course>() { c3 };


            //=================Upsert Tables (Course,Trainer,Student,Assignment,TutionFees -- Automatic creation of Movies)
            context.Trainers.AddOrUpdate(x => new { x.FirstName, x.LastName }, tr1, tr2, tr3, tr4, tr5, tr6, tr7);
            context.Courses.AddOrUpdate(x => x.Title, c1, c2, c3, c4, c5);
            context.MarkAssignments.AddOrUpdate(x => x.MarkCode, m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14,
                m15, m16, m17, m18, m19, m20, m21, m22, m23, m24, m25, m26, m27, m28, m29, m30, m31, m32, m33, m34, m35, m36,
                m37, m38, m39, m40, m41, m42, m43, m44, m45, m46, m47, m48, m49, m50, m51, m52, m53, m54, m55, m56, m57, m58,
                m59, m60, m61, m62);

            context.SaveChanges();

            #endregion

        }
    }
}
