namespace collegeApp.Model
{
    public static class CollegeRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    StudentName = "arghya",
                    Email="TestName1@gmail.com",
                    Address="Test Address1",
                },
                new Student()
                {
                    Id = 2,
                    StudentName = "raja",
                    Email="TestName2@gmail.com",
                    Address="Test Address2",
                }
            };
    }
}
