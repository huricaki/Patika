using System.Linq;

namespace LinqPRACTİCES.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using(var context=new LinqDbContext())
            {
                if(context.Students.Any())
                {
                    return;
                }
                context.Students.AddRange(
                    new Student(){
                        Name="ayşe",
                        Surname="kılıç",
                        ClassID=1
                        
                    },
                    new Student(){
                        Name="eren",
                        Surname="jeager",
                        ClassID=2
                        
                    },
                    new Student(){
                        Name="mikasa",
                        Surname="ackerman",
                        ClassID=2
                        
                    },
                    new Student(){
                        Name="armin",
                        Surname="alert",
                        ClassID=3
                        
                    },
                    new Student(){
                        Name="jean",
                        Surname="kristein",
                        ClassID=1
                        
                    }
                );
            }
        }
    }
}