using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace struct1 {
    public class MaxMinGradeOfStudentAndCourseInput {
        public List<Student> studentsLst { get; set; }
    }
    public class MaxMinGradeOfStudentAndCourseOutput {
        public string maxGradeStudent = "Student 1", minGradeStudent = "Student 1", maxGradeCourse = "Course 1", minGradeCourse = "Course 1";
    }
    public class MaxMinGradeOfStudentAndCourse {
        public MaxMinGradeOfStudentAndCourseInput Input { get; set; }
        public MaxMinGradeOfStudentAndCourseOutput Execute() {
            var output = new MaxMinGradeOfStudentAndCourseOutput();
            double high = Input.studentsLst[0].course0, low = Input.studentsLst[0].course0; 
            // Finds the max grade for student and the course.
            for (int i = 0; i < 6; i++) {
                if (high < Input.studentsLst[i].course0) {
                    high = Input.studentsLst[i].course0;
                    output.maxGradeStudent = Input.studentsLst[i].Name;
                    output.maxGradeCourse = "Course 1";
                }
                if (high < Input.studentsLst[i].course1) {
                    high = Input.studentsLst[i].course1;
                    output.maxGradeStudent = Input.studentsLst[i].Name;
                    output.maxGradeCourse = "Course 2";
                }
                if (high < Input.studentsLst[i].course2) {
                    high = Input.studentsLst[i].course2;
                    output.maxGradeStudent = Input.studentsLst[i].Name;
                    output.maxGradeCourse = "Course 3";
                }
            }
            // Finds the min grade for student and the course.
            for (int i = 0; i < 6; i++) {
                if (low > Input.studentsLst[i].course0) {
                    low = Input.studentsLst[i].course0;
                    output.minGradeStudent = Input.studentsLst[i].Name;
                    output.minGradeCourse = "Course 1";
                }
                if (low > Input.studentsLst[i].course1) {
                    low = Input.studentsLst[i].course1;
                    output.minGradeStudent = Input.studentsLst[i].Name;
                    output.minGradeCourse = "Course 2";
                }
                if (low > Input.studentsLst[i].course2) {
                    low = Input.studentsLst[i].course2;
                    output.minGradeStudent = Input.studentsLst[i].Name;
                    output.minGradeCourse = "Course 3";
                }
            }
            return output;
        }
    }
}
