namespace DemoApplication.Areas.Admin.ViewModels.Author
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public UpdateViewModel(int id, string name, string lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;
        }
    }
}
