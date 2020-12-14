using System;

namespace PyramidSlideDown
{
    class Program
    {
        /*
        Lyrics...
        Pyramids are amazing! Both in architectural and mathematical sense.If you have a computer,
        you can mess with pyramids even if you are not in Egypt at the time. For example,
        let's consider the following problem. Imagine that you have a pyramid built of numbers, like this one here:

           /3/
          \7\ 4 
         2 \4\ 6 
        8 5 \9\ 3
        Here comes the task...
        Let's say that the 'slide down' is the maximum sum of consecutive numbers from the top to the bottom of the pyramid.
        As you can see, the longest 'slide down' is 3 + 7 + 4 + 9 = 23

        Your task is to write a function longestSlideDown (in ruby/rust: longest_slide_down) that takes a pyramid representation
        as argument and returns its' largest 'slide down'. For example,

        LongestSlideDown(new[] { new[] {3}, new[] {7, 4}, new[] { 2, 4, 6 }, new[] { 8, 5, 9, 3 } }); => 23
        */


        /*
                                                [75],
                                              [95, 64],
                                            [17, 47, 82],
                                          [18, 35, 87, 10],
                                        [20,  4, 82, 47, 65],
                                      [19,  1, 23, 75,  3, 34],
                                    [88,  2, 77, 73,  7, 63, 67],
                                  [99, 65,  4, 28,  6, 16, 70, 92],
                                [41, 41, 26, 56, 83, 40, 80, 70, 33],
                              [41, 48, 72, 33, 47, 32, 37, 16, 94, 29],
                            [53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14],
                          [70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57],
                        [91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48],
                      [63, 66,  4, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31],
                    [ 4, 62, 98, 27, 23,  9, 70, 98, 73, 93, 38, 53, 60,  4, 23]

        Correct: 75+64+82+87+82+75+73+28+83+32+91+78+58+73+93 = 1074


         */
        static void Main(string[] args)
        {
            //LongestSlideDown(new[] { new[] { 3 }, new[] { 7, 4 }, new[] { 2, 4, 6 }, new[] { 8, 5, 9, 3 } });
            var mediumPyramid = new[]
          {
              new [] {75},
              new [] {95, 64},
              new [] {17, 47, 82},
              new [] {18, 35, 87, 10},
              new [] {20,  4, 82, 47, 65},
              new [] {19,  1, 23, 75,  3, 34},
              new [] {88,  2, 77, 73,  7, 63, 67},
              new [] {99, 65,  4, 28,  6, 16, 70, 92},
              new [] {41, 41, 26, 56, 83, 40, 80, 70, 33},
              new [] {41, 48, 72, 33, 47, 32, 37, 16, 94, 29},
              new [] {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14},
              new [] {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57},
              new [] {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48},
              new [] {63, 66,  4, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31},
              new [] { 4, 62, 98, 27, 23,  9, 70, 98, 73, 93, 38, 53, 60,  4, 23}
          };
            LongestSlideDown(mediumPyramid);
        }
        public static int LongestSlideDown(int[][] pyramid)
        {
            int sum = 0;
            int chosenNumber = 0;
            int LasthighestIndex = 0;
            int CurrenthighestIndex = 0;

          
            
            //for (int t1 = 0; t1 < pyramid[pyramid.Length - 1].Length; t1++)
            //{
            //    int sum2 = 0;
            //    for (int t = 0; t < pyramid.Length; t++)
            //    {
            //       sum2 = pyramid[t][t1] + pyramid[t + 1][t1];
            //        if (sum2 > sum)
            //        {
            //            sum = sum2;
            //        }

            //    }
            //}
            


            for (int y = 0; y < pyramid.Length; y++)
            {
                for (int x = 0; x < pyramid[y].Length; x++)
                {
                    if (chosenNumber < pyramid[y][x] && (x == LasthighestIndex + 1 || x == LasthighestIndex))
                    {
                        chosenNumber = pyramid[y][x];
                        CurrenthighestIndex = x;
                    }

                }
                Console.WriteLine(chosenNumber);

                sum = sum + chosenNumber;
                chosenNumber = 0;
                LasthighestIndex = CurrenthighestIndex;
                //Console.WriteLine("Index: " + LasthighestIndex);

            }
            Console.WriteLine("sum " + sum);
            return sum;

        }
    }
}
