using IceCity.EFCore.Entities.contrac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity.EFCore.Entities
{
    public class Owner:IsSoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public  string Phone { get; set; }
        public List <House> Houses { get; set; } = new List<House>();
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DateDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
