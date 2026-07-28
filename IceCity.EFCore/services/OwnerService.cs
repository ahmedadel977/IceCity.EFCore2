using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity.EFCore.services
{
    public class OwnerService
    {
        private readonly AppDbContext context;
        public OwnerService(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(Owner owner)
        {
            context.Add<Owner>(owner);
            context.SaveChanges();
        }
        public void Update(Owner owner)
        {
            context.Owners.Update(owner);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var owner = context.Owners.Find(id);
            if (owner != null)
            {
                context.Owners.Remove(owner);
                context.SaveChanges();

            }
        }
        public Owner GetByid(int id)
        {

            return context.Owners.Find( id) as Owner;


        }
        public List<Owner> GetAll()
        {
            return context.Owners.ToList();
        }
    }
}

