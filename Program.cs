using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student uczen1 = new Student();
            Student uczen2 = new Student();

            // metody klasy Student zarzadzajace polami obiektu
            uczen1.setIndex(121215);
            uczen1.setSemester(4);
            uczen1.setName("Dawid");
            uczen1.setSurname("Wielechowski");
            uczen1.printStudentInfo();

            // metody klasy Student zarzadzajace polami obiektu
            uczen2.setIndex(128521);
            uczen2.setSemester(4);
            uczen2.setName("Mariusz");
            uczen2.setSurname("Pudzianowski");
            uczen2.printStudentInfo();

            // metody klasy Uni, zarzadzajace listą studentów oraz ich ocenami.
            Uni pbs = new Uni();
            pbs.addStudent(uczen1);
            pbs.showStudentGrades(uczen1.getIndex());

            pbs.addStudent(uczen2);
            pbs.showStudentGrades(uczen2.getIndex());

            Console.WriteLine($"Average student #{uczen1.getIndex()} grades: {pbs.getStudentAverage(uczen1.getIndex())}");
            Console.WriteLine($"Average student #{uczen2.getIndex()} grades: {pbs.getStudentAverage(uczen2.getIndex())}");
            Console.WriteLine($"Average grade of all students: {pbs.allStudentsAverage()}.");
        }
    }
}
