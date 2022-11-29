using System;
using System.Linq;
using LinqPRACTİCES;
using LinqPRACTİCES.DBOperations;

namespace LinqPracties
{
    class Program
    {
        static void Main(string[] args)
        {
           DataGenerator.Initialize();
            LinqDbContext _context=new LinqDbContext();
            var students =_context.Students.ToList<Student>();
        }
    }
}
