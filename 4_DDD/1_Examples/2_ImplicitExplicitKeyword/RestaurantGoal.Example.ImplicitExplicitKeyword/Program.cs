using RestaurantGoal.Example.ImplicitExplicitKeyword.Models;

//https://www.bytehide.com/blog/conversions-implicit-vs-explicit


//Implicit

Celsius celsius = new Celsius(10);

//Valid Conversations
Fahrenheit fahrenheit = celsius;
Celsius celsius2 = fahrenheit;

//Invalid Conversations
//Kelvin kelvin = (Kelvin)celsius;
//Kelvin kelvin = (Kelvin)fahrenheit;


//Explicit

Teacher teacher = new Teacher { Name = "Juan", Class = "Programming", IdContract = 10 };

//Valid Conversations
Pupil student = (Pupil)teacher;
Teacher teacher2 = (Teacher)student;

//Invalid Conversations
//Pupil student2 = teacher;
//Teacher teacher3 = student;