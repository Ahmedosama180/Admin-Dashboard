using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly DemoContext db;

        public DepartmentRep(DemoContext db)
        {
            this.db = db;
        }
        


        public IEnumerable<Department> Get()
        {
            var data = db.Department.Select(a => a);
            return data;
        }

        public Department GetById(int id)
        {
            var data = db.Department.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public void Create(Department obj)
        {
           

            db.Department.Add(obj);
            db.SaveChanges();
        }

        public void Edit(Department obj)
        {
            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }

        public void Delete(Department obj)
        {
            db.Department.Remove(obj);
            db.SaveChanges();
        }









        // ======================= Refactor ========================
        //private IEnumerable<DepartmentVM> GetDepartment()
        //{
        //    return db.Department.Select(a => new DepartmentVM
        //    {
        //        Id = a.Id,
        //        Name = a.Name,
        //        Code = a.Code
        //    });
        //}
    }
}
