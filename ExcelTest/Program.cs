using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;


namespace ExcelTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            List<string> faculty = ReadFile(@"C:\Users\u0457\Desktop\ExcelTest\testl.xlsx");

            foreach (var VARIABLE in faculty)
            {
                Console.WriteLine(VARIABLE);
            }

            using (exceldbContext db = new exceldbContext())
            {
                for (int i = 0; i < faculty.Count; i++)
                {
                    db.University.Add(new University{Faculty = faculty[i]});
                }

                db.SaveChanges();
            }
        }

        public static List<string> ReadFile(string path)
        {
            List<string> faculty = new List<string>();

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    DataTable dt = result.Tables[0];
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        //Console.WriteLine(dt.Rows[i][0]);
                        faculty.Add(dt.Rows[i][0].ToString());

                    }
                }
            }
            return faculty;
        }

    }
}
