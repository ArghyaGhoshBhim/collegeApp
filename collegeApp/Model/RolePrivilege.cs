namespace collegeApp.Model
{
    public class RolePrivilege
    {
        public int Id { get; set; }
        public string RolePrivilegeName { get; set; }
        public string Description { get; set;}
        public bool IsActive { get; set; }
        public bool IsDeleted {  get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
        public int RoleId { get; set; }

    }
}
