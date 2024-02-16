using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Packaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SystemNodeHelper.Utility
{
    public class ImgHelper
    {
        public static object InvokeStorageRootMethod(StorageInfo storageRoot, string methodName, params object[] methodArgs)
        {
            BindingFlags bindingFlags = BindingFlags.Static |
                                        BindingFlags.Instance |
                                        BindingFlags.Public |
                                        BindingFlags.NonPublic |
                                        BindingFlags.InvokeMethod;

            Type storageRootType = typeof(StorageInfo).Assembly.GetType("System.IO.Packaging.StorageRoot",
                true,
                false);
            object result = storageRootType.InvokeMember(methodName,
                bindingFlags,
                null,
                storageRoot,
                methodArgs);

            return result;
        }

        /// <summary>
        /// 获取缩略图
        /// </summary>
        /// <param name="file"></param>
        /// <param name="savePath"></param>
        public static Bitmap GetImage2(string file)
        {
            StorageInfo storageRoot = (StorageInfo)InvokeStorageRootMethod(null,
                "Open",
                file,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);

            if (storageRoot == null)
            {
                return null;
            }

            byte[] preViewData = null;

            StreamInfo[] streams = storageRoot.GetStreams();
            foreach (StreamInfo stream in streams)
            {
                if (stream.Name.ToUpper().Equals("REVITPREVIEW4.0"))
                {
                    preViewData = ParsePreviewInfo(stream);
                }
            }
            InvokeStorageRootMethod(storageRoot, "Close");

            // 获取不到信息返回一个100x100的空图片
            if (preViewData == null || preViewData.Length <= 0)
            {
                using (Bitmap newBitmap = new Bitmap(100, 100))
                {
                  //  newBitmap.Save(savePath);
                    return newBitmap;
                }
            }

            // 通过Revit元数据读取到PNG图像的开头
            int startingOffset = GetPngStartingOffset(preViewData);
            if (startingOffset == 0)
            {
                using (Bitmap newBitmap = new Bitmap(100, 100))
                {
                    //newBitmap.Save(savePath);
                    return newBitmap;
                }
            }

            byte[] pngDataBuffer = new byte[preViewData.GetUpperBound(0) - startingOffset + 1];
            // 将PNG图像数据读入字节数组
            using (MemoryStream ms = new MemoryStream(preViewData))
            {
                ms.Position = startingOffset;
                ms.Read(pngDataBuffer, 0, pngDataBuffer.Length);
            }

            byte[] decoderData = null;

            // 如果图像数据有效
            if (pngDataBuffer != null)
            {
                // 使用内存流对PNG图像数据进行解码
                // 并将解码后的数据复制到字节数组中
                using (MemoryStream ms = new MemoryStream(pngDataBuffer))
                {
                    PngBitmapDecoder decoder = new PngBitmapDecoder(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    decoderData = BitSourceToArray(decoder.Frames[0]);
                }
            }

            // 如果解码的数据有效
            if ((decoderData != null) && (decoderData.Length > 0))
            {
                // 使用另一个内存流创建Bitmap
                // 然后是一张图片Bitmap
                using (MemoryStream ms = new MemoryStream(decoderData))
                {
                    using (Bitmap newBitmap = new Bitmap((ms)))
                    {
                        //newBitmap.Save(savePath);
                        return newBitmap;
                    }
                }
            }

            using (Bitmap newBitmap = new Bitmap(100, 100))
            {
                //newBitmap.Save(savePath);
                return newBitmap;
            }
        }

        /// <summary>
        /// 获取缩略图
        /// </summary>
        /// <param name="file"></param>
        /// <param name="savePath"></param>
        public static void CreatImg(string file, string savePath)
        {
            StorageInfo storageRoot = (StorageInfo)InvokeStorageRootMethod(null,
                "Open",
                file,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);

            if (storageRoot == null)
            {
                return;
            }
            var size = 200;
            byte[] preViewData = null;

            StreamInfo[] streams = storageRoot.GetStreams();
            foreach (StreamInfo stream in streams)
            {
                if (stream.Name.ToUpper().Equals("REVITPREVIEW4.0"))
                {
                    preViewData = ParsePreviewInfo(stream);
                }
            }
            InvokeStorageRootMethod(storageRoot, "Close");

            // 获取不到信息返回一个100x100的空图片
            if (preViewData == null || preViewData.Length <= 0)
            {
                using (Bitmap newBitmap = new Bitmap(size, size))
                {
                    newBitmap.Save(savePath);
                    return;
                }
            }

            // 通过Revit元数据读取到PNG图像的开头
            int startingOffset = GetPngStartingOffset(preViewData);
            if (startingOffset == 0)
            {
                using (Bitmap newBitmap = new Bitmap(size, size))
                {
                    newBitmap.Save(savePath);
                    return;
                }
            }

            byte[] pngDataBuffer = new byte[preViewData.GetUpperBound(0) - startingOffset + 1];
            // 将PNG图像数据读入字节数组
            using (MemoryStream ms = new MemoryStream(preViewData))
            {
                ms.Position = startingOffset;
                ms.Read(pngDataBuffer, 0, pngDataBuffer.Length);
            }

            byte[] decoderData = null;

            // 如果图像数据有效
            if (pngDataBuffer != null)
            {
                // 使用内存流对PNG图像数据进行解码
                // 并将解码后的数据复制到字节数组中
                using (MemoryStream ms = new MemoryStream(pngDataBuffer))
                {
                    PngBitmapDecoder decoder = new PngBitmapDecoder(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    decoderData = BitSourceToArray(decoder.Frames[0]);
                }
            }

            // 如果解码的数据有效
            if ((decoderData != null) && (decoderData.Length > 0))
            {
                // 使用另一个内存流创建Bitmap
                // 然后是一张图片Bitmap
                using (MemoryStream ms = new MemoryStream(decoderData))
                {
                    using (Bitmap newBitmap = new Bitmap((ms)))
                    {
                        newBitmap.Save(savePath);
                        return;
                    }
                }
            }

            using (Bitmap newBitmap = new Bitmap(size, size))
            {
                newBitmap.Save(savePath);
            }
        }


        private static byte[] ParsePreviewInfo(StreamInfo streamInfo)
        {
            byte[] streamData = null;
            try
            {
                using (Stream streamReader = streamInfo.GetStream(FileMode.Open, FileAccess.Read))
                {
                    streamData = new byte[streamReader.Length];
                    streamReader.Read(streamData, 0, streamData.Length);
                    return streamData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                streamData = null;
            }
        }

        private static byte[] BitSourceToArray(BitmapSource bitmapSource)
        {
            BitmapEncoder encoder = new JpegBitmapEncoder();
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(ms);
                return ms.ToArray();
            }
        }

        private static int GetPngStartingOffset(byte[] previewData)
        {
            bool markerFound = false;
            int startingOffset = 0;
            int previousValue = 0;
            using (MemoryStream ms = new MemoryStream(previewData))
            {
                for (int i = 0; i < previewData.Length; i++)
                {
                    int currentValue = ms.ReadByte();
                    // possible start of PNG file data
                    if (currentValue == 137)   // 0x89
                    {
                        markerFound = true;
                        startingOffset = i;
                        previousValue = currentValue;
                        continue;
                    }

                    switch (currentValue)
                    {
                        case 80:   // 0x50
                            if (markerFound && (previousValue == 137))
                            {
                                previousValue = currentValue;
                                continue;
                            }
                            markerFound = false;
                            break;

                        case 78:   // 0x4E
                            if (markerFound && (previousValue == 80))
                            {
                                previousValue = currentValue;
                                continue;
                            }
                            markerFound = false;
                            break;

                        case 71:   // 0x47
                            if (markerFound && (previousValue == 78))
                            {
                                previousValue = currentValue;
                                continue;
                            }
                            markerFound = false;
                            break;

                        case 13:   // 0x0D
                            if (markerFound && (previousValue == 71))
                            {
                                previousValue = currentValue;
                                continue;
                            }
                            markerFound = false;
                            break;

                        case 10:   // 0x0A
                            if (markerFound && (previousValue == 26))
                            {
                                return startingOffset;
                            }
                            if (markerFound && (previousValue == 13))
                            {
                                previousValue = currentValue;
                                continue;
                            }
                            markerFound = false;
                            break;

                        case 26:   // 0x1A
                            if (markerFound && (previousValue == 10))
                            {
                                previousValue = currentValue;
                                continue;
                            }
                            markerFound = false;
                            break;
                    }
                }
            }
            return 0;
        }

    }
}
