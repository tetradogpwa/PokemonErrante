using Blazor.FileReader;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Gabriel.Cat.S.Extension
{
    public static class Extension
    {

        public static async Task MostrarMensajeAsync(this IJSRuntime js, string mensaje)
        {
            await js.InvokeVoidAsync("alert", mensaje);
        }
        public static async Task DownloadFileStringAsync(this IJSRuntime js, string fileName, string data,string fileType,string charset="utf-8")
        {
        
            await js.InvokeVoidAsync("StringSaveAsFile", fileName, data,fileType,charset);
        }
      
        public static async Task DownloadFileBinaryAsync(this IJSRuntime js,string fileName,byte[] data)
        {//no funciona
            await js.InvokeVoidAsync("SaveAsFile", fileName, data);
        }
        public static async Task SaveLocalStorageAsync(this IJSRuntime js, string id, string data)
        {
            await js.InvokeVoidAsync("SaveLocalStorage", id, data);
        }

        public static async Task<string> LoadLocalStorageAsync(this IJSRuntime js, string id)
        {
            return await js.InvokeAsync<string>("LoadLocalStorage", id);
        }
        public static async ValueTask<bool> PreguntaAsync(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<bool>("confirm", mensaje);

        }


        public static T Last<T>(this IList<T> lst)
        {
            return lst.Count>0? lst[lst.Count - 1]:default;
        }

        public static async Task<byte[]> Read(this IFileReference fileReader, int buffer = 4 * 1024)
        {
            MemoryStream ms = null;
            byte[] bytesFile = null;
            try
            {
                ms = await fileReader.CreateMemoryStreamAsync(buffer);

                bytesFile = new byte[ms.Length];
                ms.Read(bytesFile, 0, (int)ms.Length);
            }
            finally
            {
                if (ms != null)
                    ms.Close();

            }
            return bytesFile;
        }
        public static string ToSrcImg(this Bitmap bmp)
        {
           return "data:image/png;base64, " + Convert.ToBase64String(bmp.ToStream(System.Drawing.Imaging.ImageFormat.Png).ToArray());
        }
    }
}
