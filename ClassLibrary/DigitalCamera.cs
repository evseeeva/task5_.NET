using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class DigitalCamera : Camera
    {
        public double DisplaySize { get; set; }
        
        public DigitalCamera(string firm, string model, double matrixResolution, double memoryCardSize, double displaySize) 
            : base(firm, model, matrixResolution, memoryCardSize)
        {
            DisplaySize = displaySize;
        }
       
        public override string shootPicture()
        {
            return autofocus()+ "\r\n" +"Picture is done";
        }
        public double getQuality() {
                
            return MatrixResolution + 0.4 * MemoryCardSize;
        }
        public string autofocus()
        {
            return "Camera is auto focused";
        }
        public override string getParameters()
        {
        
            return $"Firm: {Firm}, Model: {Model}, Matrix resolution: {MatrixResolution} MPix, Memory card size: {MemoryCardSize} Gb, Display size: {DisplaySize} iches";
        }
    }
}
