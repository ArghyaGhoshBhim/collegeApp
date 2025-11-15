namespace collegeApp.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActived { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}
