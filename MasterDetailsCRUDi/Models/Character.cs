using SQLite;
namespace MasterDetailsCRUDi.Models
{
    public class Character
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Level { get; set; }

        public int Age { get; set; }

        public void Update(Character newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id
            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
        }

    }
}