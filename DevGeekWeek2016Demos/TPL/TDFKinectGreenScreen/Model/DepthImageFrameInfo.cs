using Microsoft.Kinect;

namespace TDFKinectGreenScreen.Model
{
    public class DepthImageFrameInfo
    {
        /// <summary>
        /// Initiate the depth frame data
        /// </summary>
        /// <param name="format">The depth map format</param>
        /// <param name="frameData">The raw depth data</param>
        /// <param name="depthWidth">Width of the depth image</param>
        /// <param name="height">Height of the depth image</param>
        /// <param name="colorToDepthDivisor">The aspect ration of color to depth map</param>
        /// <param name="depthStreamFramePixelDataLength">The buffer length</param>
        public DepthImageFrameInfo(DepthImageFormat format, short[] frameData, int depthWidth, int height,
                                   int colorToDepthDivisor, int depthStreamFramePixelDataLength)
        {
            Format = format;
            FrameData = frameData;
            Width = depthWidth;
            Height = height;
            ColorToDepthDivisor = colorToDepthDivisor;
            DepthStreamFramePixelDataLength = depthStreamFramePixelDataLength;
        }

        /// <summary>
        /// The depth map format
        /// </summary>
        public DepthImageFormat Format { get; }

        /// <summary>
        /// The raw depth data
        /// </summary>
        public short[] FrameData { get; }

        /// <summary>
        /// Width of the depth image
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Height of the depth image
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// The aspect ration of color to depth map
        /// </summary>
        public int ColorToDepthDivisor { get; }

        /// <summary>
        /// The buffer length
        /// </summary>
        public int DepthStreamFramePixelDataLength { get; }
    }
}