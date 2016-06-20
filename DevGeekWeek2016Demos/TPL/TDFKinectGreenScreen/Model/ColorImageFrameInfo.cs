using Microsoft.Kinect;

namespace TDFKinectGreenScreen.Model
{
    /// <summary>
    /// The Kinect color sensor information frame
    /// </summary>
    public class ColorImageFrameInfo
    {
        /// <summary>
        /// Initiate the frame fata fields
        /// </summary>
        /// <param name="colorImageFormat">The image map format</param>
        /// <param name="frameData">The raw data</param>
        /// <param name="width">The image width</param>
        /// <param name="height">The image height</param>
        /// <param name="colorToDepthDivisor">The aspect ration of color to depth map</param>
        public ColorImageFrameInfo(ColorImageFormat colorImageFormat, byte[] frameData, int width, int height,
                                   int colorToDepthDivisor)
        {
            Format = colorImageFormat;
            FrameData = frameData;
            Width = width;
            Height = height;
            ColorToDepthDivisor = colorToDepthDivisor;
        }

        /// <summary>
        /// The raw data
        /// </summary>
        public byte[] FrameData { get; }

        /// <summary>
        /// Width of the color image
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Height of the color image
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// The image map format
        /// </summary>
        public ColorImageFormat Format { get; }

        /// <summary>
        /// The aspect ration of color to depth map
        /// </summary>
        public int ColorToDepthDivisor { get; }
    }
}