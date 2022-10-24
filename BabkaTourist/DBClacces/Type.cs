using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkaTourist.DBClacces
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Type()
        {

        }
    }
}
