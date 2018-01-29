using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace struct1 {
    public class MaxMinAverageOfCoursesInput {
        public double[] sum = new double[3];
    }
    public class MaxMinAverageOfCoursesOutput {
        public string averageNameHigh = " ", averageNameLow = " ";
    }
    public class MaxMinAverageOfCourses {
        public MaxMinAverageOfCoursesInput Input { get; set; }
        public MaxMinAverageOfCoursesOutput Execute() {
            var output = new MaxMinAverageOfCoursesOutput();
            // Finds the max and min average for courses.
            double[] courseAverage = new double[3];
            double maxAverage = 0, minAverage = 90;
            courseAverage[0] = Input.sum[0] / 6;
            courseAverage[1] = Input.sum[1] / 6;
            courseAverage[2] = Input.sum[2] / 6;
            if (maxAverage < courseAverage[0]) {
                maxAverage = courseAverage[0];
                output.averageNameHigh = "Course 1";
            }
            if (maxAverage < courseAverage[1]) {
                maxAverage = courseAverage[1];
                output.averageNameHigh = "Course 2";
            }
            if (maxAverage < courseAverage[2]) {
                maxAverage = courseAverage[2];
                output.averageNameHigh = "Course 3";
            }
            if (minAverage > courseAverage[0]) {
                minAverage = courseAverage[0];
                output.averageNameLow = "Course 1";
            }
            if (minAverage > courseAverage[1]) {
                minAverage = courseAverage[1];
                output.averageNameLow = "Course 2";
            }
            if (minAverage > courseAverage[2]) {
                minAverage = courseAverage[2];
                output.averageNameLow = "Course 3";
            }
            return output;
        }
    }
}
