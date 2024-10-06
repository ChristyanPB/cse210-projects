using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Coopac Cajasol";
        job1._jobTitle = "Credit Analist";
        job1._startYear = 2019;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._company = "Grupo Financiero JMG";
        job2._jobTitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Christyan Bravo";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}