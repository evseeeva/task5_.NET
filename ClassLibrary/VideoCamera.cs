using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
  public class VideoCamera : Camera
    {
        public double VideoResolution { get; set; }

      
        public VideoCamera(string firm, string model, double matrixResolution, double memoryCardSize,  double videoResolution) 
            : base(firm, model, matrixResolution, memoryCardSize)
        {
            VideoResolution = videoResolution;
        }
       
        public override string shootPicture()
        {
           return "Picture is done";
        }
        public string startVideoRecording()
        {
            return "Video recording started";
        }
        public string stopVideoRecording()
        {
            return "Video recording stopped";
        }
       
        public override string getParameters()
        {
        
            return $"Firm: {Firm}, Model: {Model}, Matrix resolution: {MatrixResolution} MPix, Memory card size: {MemoryCardSize} Gb, Video resolution: {VideoResolution}p";
        }
    }
}
