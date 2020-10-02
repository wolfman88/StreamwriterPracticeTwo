using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamwriterPracticeTwo
{
  class Program
  {
    static void Main(string[] args)
    {

      string line = "";

      StreamReader reader = new StreamReader(@"EmployeeRecords.csv");
      Dictionary<string, Employee> employeeInfoData = new Dictionary<string, Employee>();

      int i = 1;

      while (line != null)
      {
        line = reader.ReadLine();

        if (line != null)
        {
          if (i > 1)
          {
            string[] employeeInformation = line.Split(',');
            // got stuck here
            Employee emp = new Employee();
            emp.ID = employeeInformation[0];
            emp.NamePrefix = employeeInformation[1];
            emp.FirstName = employeeInformation[2];
            emp.MiddleInitial = employeeInformation[3];
            emp.LastName = employeeInformation[4];
            emp.Gender = employeeInformation[5];
            emp.DrugTestDateLast = Convert.ToDateTime(employeeInformation[6]);
            emp.EMail = employeeInformation[7];
            emp.DateOfBirth = Convert.ToDateTime(employeeInformation[8]);
            emp.DateHired = Convert.ToDateTime(employeeInformation[9]);
            emp.Salary = Convert.ToDecimal(employeeInformation[10]);
            emp.LastPayHike = Convert.ToDecimal(employeeInformation[11]);
            emp.SSN = employeeInformation[12];
            emp.PhoneNumber = employeeInformation[13];
            emp.County = employeeInformation[14];
            emp.City = employeeInformation[15];
            emp.State = employeeInformation[16];
            emp.ZipCode = employeeInformation[17];
            emp.UserName = employeeInformation[18];
            emp.Password = employeeInformation[19];

            employeeInfoData.Add(employeeInformation[0], emp);
          }
          i++;
        }
      }
      //Array arr = employeeInfoData.Select(z => z.Value).ToArray();

      string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

      using (StreamWriter outputCSVFile = new StreamWriter(Path.Combine(docPath, "WriteLines.csv")))
      {
        foreach (KeyValuePair<string, Employee> item in employeeInfoData)
        {
          string[] empValues = new string[]
          {
            item.Value.ID, item.Value.NamePrefix, item.Value.FirstName, item.Value.MiddleInitial
          };
          
          outputCSVFile.WriteLine(string.Join(",", empValues));

        }
      }
    }
  }
}
