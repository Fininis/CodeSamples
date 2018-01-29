using System;
using MahApps.Metro.Controls;
using System.Windows;
using System.Collections.Generic;

namespace struct1 {
    public partial class MainWindow : MetroWindow {
        List<Student> students = new List<Student>();
        private int positionIndex = 0;
        private Random random = new Random();
        public double[] sum = new double[3];
        public MainWindow() {
            InitializeComponent();
            registerEvents();
        }
        private void registerEvents() {
            btn1.Click += exe1;
            this.Loaded += load;
        }
        private void load(object sender, RoutedEventArgs e) {
            grade0.Focus();
        }
        private void exe1(object sender, RoutedEventArgs e) {
            var value0 = Convert.ToDouble(grade0.Text);
            var value1 = Convert.ToDouble(grade1.Text);
            var value2 = Convert.ToDouble(grade2.Text);
            var student1 = new Student();
            positionIndex++;
            student1.course0 = value0;
            student1.course1 = value1;
            student1.course2 = value2;
            sum[0] += value0;
            sum[1] += value1;
            sum[2] += value2;
            student1.cAverage = (value0 + value1 + value2) / 3;
            student1.Name = $"Student {positionIndex }";
            students.Add(student1);
            int randomNumber1 = random.Next(0, 101);
            int randomNumber2 = random.Next(0, 101);
            int randomNumber3 = random.Next(0, 101);
            grade0.Text = randomNumber1.ToString();
            grade1.Text = randomNumber2.ToString();
            grade2.Text = randomNumber3.ToString();
            grade0.Focus();
            if (positionIndex == 6) {
                btn1.IsEnabled = false;
                student.Text = ("Grades filled");
                grade0.Text = " ";
                grade1.Text = " ";
                grade2.Text = " ";
                grade0.IsEnabled = false;
                grade1.IsEnabled = false;
                grade2.IsEnabled = false;
                listBox.Visibility = Visibility.Visible;
                txtFill.Visibility = Visibility.Hidden;
                showResults();
            } else {
                student.Text = $"Student {positionIndex + 1}";
            }
        }
        private void showResults() {
            var input1 = new MaxMinGradeOfStudentAndCourseInput();
            input1.studentsLst = students;
            var uc1 = new MaxMinGradeOfStudentAndCourse();
            uc1.Input = input1;
            var output1 = uc1.Execute();

            var input2 = new MaxMinAverageOfStudentsInput();
            input2.studentsLst = students;
            var uc2 = new MaxMinAverageOfStudents();
            uc2.Input = input2;
            var output2 = uc2.Execute();

            var input3 = new MaxMinAverageOfCoursesInput();
            input3.sum = sum;
            var uc3 = new MaxMinAverageOfCourses();
            uc3.Input = input3;
            var output3 = uc3.Execute();

            txt1.Text = output1.maxGradeStudent.ToString();
            txt5.Text = output1.maxGradeCourse.ToString();
            txt2.Text = output1.minGradeStudent.ToString();
            txt6.Text = output1.minGradeCourse.ToString();
            txt3.Text = output2.meanNameHigh.ToString();
            txt4.Text = output2.meanNameLow.ToString();
            txt7.Text = output3.averageNameHigh.ToString();
            txt8.Text = output3.averageNameLow.ToString();
        }
    }
}