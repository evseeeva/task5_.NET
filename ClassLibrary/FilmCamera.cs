using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
  public class FilmCamera : Camera
    {
        public double Exposure { get; set; }
   
        public FilmCamera(string firm, string model, double matrixResolution, double memoryCardSize,  double exposure) 
            : base(firm, model, matrixResolution, memoryCardSize)
        {
         
            Exposure = exposure;
        }
       
        public override string shootPicture()
        {
            focus();
            return focus()+"\r\n"+"Picture is done"+ "\r\n"+ printPhoto();
            
        }
        
        public string printPhoto()
        {
            return "Photo is printed on film";
        }
        public string focus()
        {
           return $"Camera is focused on {Exposure} sec";
        }
        public override string getParameters()
        {
        
            return $"Firm: {Firm}, Model: {Model}, Matrix resolution: {MatrixResolution} MPix, Memory card size: {MemoryCardSize} Gb,  Exposure : {Exposure}";
        }
    }
}
