using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace ConsoleApp2
{


    static class Content {

        public static List<Image> images = new List<Image>();
        public static List<string> imagenames = new List<string>();


       

    }

    class Program
    {
        static void Main(string[] args)
        {

            //load all pngs and store names
            Console.WriteLine("Specify input directory:");
            string path = Console.ReadLine();
            string[] files = System.IO.Directory.GetFiles(path, "*.png");


            System.IO.Directory.CreateDirectory("Output");


            for (int i = 0; i < files.Length; i++)
            {

                Content.images.Add(new Image(files[i]));
                Content.imagenames.Add(files[i]);
            
            }


            //Invert color for each and export as hover
            for (int i = 0; i < Content.images.Count; i++) {

                for (int j = 0; j < Content.images[i].Size.X; j++) {

                    for (int k = 0; k < Content.images[i].Size.Y; k++)
                    {

                        
                         Color tempc = Content.images[i].GetPixel((uint)j, (uint)k);

                        //modify color
                        int colorbase = 255;
                        byte asbyte = Convert.ToByte(colorbase);

                        Color newc = new Color((byte)(asbyte-tempc.R), (byte)(asbyte - tempc.G), (byte)(asbyte - tempc.R), tempc.A);


                        Content.images[i].SetPixel((uint)j,(uint)k,newc);


                    }

                }
                string newpath = Content.imagenames[i].Substring(Content.imagenames[i].LastIndexOf("\\") + 1);
                string newname = newpath.Replace(".png", "");

                Content.images[i].SaveToFile("Output/"+newname + "Hover.png");


            }





            //darken
            for (int i = 0; i < Content.images.Count; i++)
            {

                for (int j = 0; j < Content.images[i].Size.X; j++)
                {

                    for (int k = 0; k < Content.images[i].Size.Y; k++)
                    {


                        Color tempc = Content.images[i].GetPixel((uint)j, (uint)k);

                        //modify color
                        int colorbase = 255;
                        byte asbyte = Convert.ToByte(colorbase);

                        Color newc = new Color((byte)(0.6* tempc.R), (byte)(0.6 * tempc.G), (byte)(0.6 * tempc.R), tempc.A);


                        Content.images[i].SetPixel((uint)j, (uint)k, newc);


                    }

                }

                string newpath = Content.imagenames[i].Substring(Content.imagenames[i].LastIndexOf("\\") + 1);
                string newname = newpath.Replace(".png", "");
                

                Content.images[i].SaveToFile("Output/"+newname + "Down.png");


            }


            //darken and export as down




        }
    }
}
