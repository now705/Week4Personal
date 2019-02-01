using SQLite;
using System;

namespace MasterDetailsCRUDi.Models
{
    public class Monster 
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public void Update(Monster newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id
            Name = newData.Name;
            Description = newData.Description;
        }
    }
}