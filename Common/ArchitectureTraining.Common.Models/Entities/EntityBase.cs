using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectureTraining.Common.Models.Entities
{
    public class EntityBase<T>// where T:class
    {
        public EntityBase()
        {
            CreatedDate = DateTime.Now;
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate => DateTime.Now;

        public string ModifiedBy { get; set; }

        public string Type => typeof(T).Name;
    }
}
