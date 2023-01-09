namespace TodoApi
{
    public class SCUserModel
    {
            public int id { get; set; }

            public int? FkmesUserId { get; set; }

            public int? EmployeeNumer { get; set; }

            public string? Ntuser { get; set; }

            public string? FirstName { get; set; }

            public string? LastName { get; set; }

            public string? SecondLastName { get; set; }

            public string? Email { get; set; }

            public int? FkroleId { get; set; }

            public bool? Available { get; set; }
    }
}