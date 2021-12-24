using System;


namespace ClassLibrary
{
    public abstract class Camera : IDevice
    {
        public string Firm {  get;  set; }
        public string Model {  get; set; }
        public double MatrixResolution { get; set; }
        public double MemoryCardSize {  get; set; }

      
        public Camera(string firm, string model, double matrixResolution, double memoryCardSize)
        {
            Firm = firm;
            Model = model;
            MatrixResolution = matrixResolution;
            MemoryCardSize = memoryCardSize;
           
        }
       public  string startWorking()
        {
            return "Camera is on";
        }
      
        public string replaceMemoryCard(double cardSize)
        {
            double oldSize= MemoryCardSize;
            MemoryCardSize = cardSize;
            return $"Old memory card of size {oldSize}Gb is replaced with a new one of size {MemoryCardSize}Gb";
        }
        public string turnOnFlash()
        {
            return "Flash is on";
        }
        public abstract string shootPicture();

        public abstract string getParameters();


    }
}
