using System;
using System.IO;
using System.Collections.Generic;

namespace advent_solutions
{
    public class Solution1
    {
       

        public static void run(FileInfo input_file, int target_sum, bool search_all = false)
        {
            Console.WriteLine($"Solving Day 1: Report Repair using {input_file.Name} with a target of {target_sum}");
            List<int> data = new List<int>(100);

            using (var data_stream = input_file.OpenText())
            {
                string line;
                while ((line = data_stream.ReadLine()) != null)
                {
                    data.Add(int.Parse(line));
                }
            }
            Console.WriteLine($"Loaded {data.Count} values.");


            data.Sort();
            int partner;
            foreach( int num in data ) {
                partner = target_sum - num;
                if(data.Contains(partner)) {
                    Console.WriteLine($"Found {num} and {partner} which equal {target_sum}. Their product is {num*partner}");
                    if(search_all) {
                        continue;
                    } else {
                        break;
                    }
                }
            }
        }
    }
}
