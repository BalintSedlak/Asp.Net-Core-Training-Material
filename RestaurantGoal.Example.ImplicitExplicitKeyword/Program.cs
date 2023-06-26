using RestaurantGoal.Example.ImplicitExplicitKeyword.Models;

//https://www.bytehide.com/blog/conversions-implicit-vs-explicit


//Implicit

Celsius celsius = new Celsius(10);

//Valid Conversation
Fahrenheit fahrenheit = celsius;
Celsius celsius2 = fahrenheit;

//Invalid Conversation
//Kelvin kelvin = celsius;
//Kelvin kelvin = fahrenheit;



//Explicit

Teacher teacher = new Teacher { Name = "Juan", Class = "Programming", IdContract = 10 };

//Valid Conversation
Pupil student = (Pupil)teacher;
Teacher teacher2 = (Teacher)student;

//Invalid Conversation