using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Nvidia";
        job1._startYear = 2026;
        job1._endYear = 2030;

        Job job2 = new Job();
        job2._jobTitle = "Backend Developer";
        job2._company = "Google";
        job2._startYear = 2023;
        job2._endYear = 2026;
        
        Resume myResume= new Resume();
        myResume._name="Iwu Christopher";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}