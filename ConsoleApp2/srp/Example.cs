using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Example
    {
        public class Course
        {
            public string name;
            public Course(string name)
            {
                this.name = name;
            }
        }


        public class CourseManager
        {
            private List<Course> courses = [];
            public void CreateCourse(string courseName)
            {
                var course = new Course(courseName);
                courses.Add(course);
            }

            public void RemoveCourse(string courseName)
            {
                Course? courseCandidate = null;
                foreach (var course in courses)
                {
                    if (courseName == course.name)
                    {
                        courseCandidate = course;
                        break;
                    }
                }
                if (courseCandidate != null)
                {
                    courses.Remove(courseCandidate);
                }
            }
            public string GenerateReport()
            {
                var report = "";
                for (var i = 0; i < courses.Count; i++)
                {
                    report += $"{i + 1} - {courses[i].name}";
                }


                return report;
            }
        }
    }

    class CoolerExample
    {
        public class Course
        {
            public string name;
            public Course(string name)
            {
                this.name = name;
            }
        }


        public class CourseManager
        {
            private List<Course> courses = [];
            public void CreateCourse(string courseName)
            {
                var course = new Course(courseName);
                courses.Add(course);
            }




            public void RemoveCourse(string courseName)
            {
                Course? courseCandidate = null;
                foreach (var course in courses)
                {
                    if (courseName == course.name)
                    {
                        courseCandidate = course;
                        break;
                    }
                }
                if (courseCandidate != null)
                {
                    courses.Remove(courseCandidate);
                }
            }
        }

        class Report
        {
            public string GeneratePlainReport(List<Course> courses)
            {
                var report = "";
                for (var i = 0; i < courses.Count; i++)
                {
                    report += $"{i + 1} - {courses[i].name}";
                }


                return report;
            }
        }

    }
}
