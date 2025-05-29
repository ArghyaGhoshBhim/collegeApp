namespace collegeApp.Model
{
    public static class CollegeRepository
    {
        public static IEnumerable<Student> Students { get; set; } = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    StudentName = "TestName1",
                    Email="TestName1@gmail.com",
                    Address="Test Address1",
                },
                new Student()
                {
                    Id = 2,
                    StudentName = "TestName2",
                    Email="TestName2@gmail.com",
                    Address="Test Address2",
                }
            };
    }
}
