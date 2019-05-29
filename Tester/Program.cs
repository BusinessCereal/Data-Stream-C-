using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Tester
{
    class Program
    {
        private struct Vector3
        {
            public Double x, y, z;

            public Vector3(Double x1, Double y1, Double z1)
            {
                x = x1;
                y = y1;
                z = z1;

            }
        }
        
        static void Main(string[] args)
        {
            String path = "/Users/businesscereal/RiderProjects/DataFileTest/DataNoLabelwsRaw";

            List<Vector3> myList = new List<Vector3>();
            

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    var line = String.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        
                        var parts = line.Split(",");

                        AddVectorsToList(parts, myList, line);

                        

                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
            
            void AddVectorsToList(string[] parts, List<Vector3> mList, string line)
            {
                if (line.Length > 1000)
                {
                    line = Convert.ToString(line.Skip(49).ToArray());
                }

                if (parts.Length != 0)
                {
                    mList.Add(
                        new Vector3(
                            Convert.ToDouble(parts[0]),
                            Convert.ToDouble(parts[1]),
                            Convert.ToDouble(parts[2]))
                    );
                    Console.Out.WriteLine("Added " + parts[0] + ", " + parts[1] + ", " + parts[2]);

                    if (mList.Count > 41)
                    {
                        mList.Clear();
                    }

                    parts = parts.Skip(3).ToArray();
                
                    AddVectorsToList(parts, mList, line);
                }
                
            }
        }
    }
}
