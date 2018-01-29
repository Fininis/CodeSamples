using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace struct1 {
    public class MaxMinAverageOfStudentsInput {
        public List<Student> studentsLst { get; set; }

    }
    public class MaxMinAverageOfStudentsOutput {
        public string meanNameHigh = " ", meanNameLow = " ";

    }
    public class MaxMinAverageOfStudents {
        public MaxMinAverageOfStudentsInput Input { get; set; }
        public MaxMinAverageOfStudentsOutput Execute() {
            var output = new MaxMinAverageOfStudentsOutput();
            // Finds the max and min average for students.
            double meanHigh = 0, meanLow = 100;
            for (int i = 0; i < 6; i++) {
                if (meanHigh < Input.studentsLst[i].cAverage) {
                    meanHigh = Input.studentsLst[i].cAverage;
                    output.meanNameHigh = Input.studentsLst[i].Name;
                }
                if (meanLow > Input.studentsLst[i].cAverage) {
                    meanLow = Input.studentsLst[i].cAverage;
                    output.meanNameLow = Input.studentsLst[i].Name;
                }
            }
            return output;
        }

    }
}
