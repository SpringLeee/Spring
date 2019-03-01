using CoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Service
{
    public class StudentService
    {
        private LocalDBContext DB;
        public StudentService(LocalDBContext dBContext)
        {
            DB = dBContext;
        }

        public async Task<List<Student>> GetList()
        {
           return  await DB.Students.ToAsyncEnumerable().ToList() ;
        }

        public async Task<int> Add(Student student)
        {
            DB.Students.Add(student);

            return await DB.SaveChangesAsync(); 
        }

        public async Task<bool> Delete(int id)
        {
            var student = DB.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student!=null)
            {
                DB.Students.Remove(student);

                return await DB.SaveChangesAsync() > 0; 
            }
            else
            {
                return false;
            } 
        } 

    }
}
