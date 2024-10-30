using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using api2019;
using start;
using vaultgamesesh;

namespace server;

internal class ImageServer
{
    private readonly HttpListener listener = new HttpListener();

    public static ImageServer instance;

    public ImageServer()
    {
        try
        {
            Console.WriteLine("[ImageServer.cs] has started.");
            new Thread(StartListen).Start();
            instance = this;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An exception occurred while listening!: " + ex.ToString());
        }
    }

    private void StartListen()
    {
        try
        {
            if (Program.admin)
            {
                listener.Prefixes.Add("http://" + Program.GetMyHost() + ":2058/");
            }
            else
            {
                listener.Prefixes.Add("http://localhost:2058/");
            }
            listener.Start();
            while (true)
            {
                Console.WriteLine("[ImageServer.cs] is listening.");
                HttpListenerContext context = listener.GetContext();
                HttpListenerResponse response = context.Response;
                string text = context.Request.RawUrl;
                byte[] array = null;
                Console.WriteLine("Image Requested: " + text);
                if (text.EndsWith("=p1"))
                {
                    text = text.Substring(0, text.Length - 7);
                    response.Headers.Add("Content-Signature", "key-id=KEY:RSA:p1.rec.net;data=Ut0QIw1ap4+3znWKL6h1LnhAQSyXYzgeEwPO9Pc2Edyen6nFV4KBvZQka7GqzoDBUKfSjxhKxNTuZFMtRfsygsFZ3JNgEcqRbY0y1E7izXzOQJep31wL9m9gsijPPBM2KzU+X1yQU/b7mN2vmpiceVuPYSzB6xjR6BRrqthfJDXjOgmzZt1HnuUxIk/y29yEqhJK9Nyx2+9/ERFOvDC08UpCw6PbHMsChcfJSrpFzvSkd9Ij6HIrKrhazhpDMecGuwyQcctIwN/dFSoMMLsAU8Dpz8w4QY0krENMhjWHsixuq/aXx0aaZX9VLqcNJ799izp6AIQmbuaAAKjPE+yMwg==");
                }
                if (!text.StartsWith("/alt/") && !text.StartsWith("/" + File.ReadAllText("SaveData/Profile/username.txt")))
                {
                    if (text.Contains(".ghf"))
                    {
                        array = Program.webClient.DownloadData("https://raw.githubusercontent.com/aqquad/RebornRec/main/data" + text.AsSpan(0, text.LastIndexOf('?')).ToString());
                    }
                    else if (text.Contains("room/"))
                    {
                        array = ((!Directory.Exists("SaveData/Rooms/" + c000041.f000043.Room.Name) || !Directory.Exists("SaveData/Rooms/" + c000041.f000043.Room.Name + "/room")) ? Program.webClient.DownloadData("https://raw.githubusercontent.com/aqquad/RebornRec/main/data/" + c000041.f000043.Scenes[0].DataBlobName) : File.ReadAllBytes(Directory.GetFiles("SaveData/Rooms/" + c000041.f000043.Room.Name + "/room")[0]));
                    }
                    else if (text.Contains("data/"))
                    {
                        array = ((Directory.Exists("SaveData/Rooms/" + c000041.f000043.Room.Name) && Directory.Exists("SaveData/Rooms/" + c000041.f000043.Room.Name + "/data")) ? File.ReadAllBytes(text.StartsWith("//") ? ("SaveData/Rooms/" + c000041.f000043.Room.Name + "/data/" + text.AsSpan(7).ToString()) : ("SaveData/Rooms/" + c000041.f000043.Room.Name + "/data/" + text.AsSpan(6).ToString())) : ((!text.StartsWith("//")) ? Program.webClient.DownloadData("https://cdn.rec.net" + text) : Program.webClient.DownloadData("https://cdn.rec.net" + text.AsSpan(1).ToString())));
                    }
                    else if (text.Contains(".jpg") && !text.StartsWith("/DefaultRoomImage.jpg"))
                    {
                        int num = text.IndexOf('?');
                        if (num != -1)
                        {
                            if (File.Exists("SaveData//Photos/" + text.AsSpan(0, num).ToString()))
                            {
                                array = File.ReadAllBytes("SaveData//Photos/" + text.AsSpan(0, num).ToString());
                            }
                            else
                            {
                                try
                                {
                                    array = Program.webClient.DownloadData("https://img.rec.net" + text);
                                }
                                catch
                                {
                                    Console.WriteLine("[ImageServer.cs] Image not found on img.rec.net.");
                                }
                            }
                        }
                        else if (text.StartsWith("//img/"))
                        {
                            if (File.Exists("SaveData/Photos/" + text.AsSpan(6).ToString()))
                            {
                                array = File.ReadAllBytes("SaveData/Photos/" + text.AsSpan(6).ToString());
                            }
                        }
                        else if (File.Exists("SaveData//Photos/" + text))
                        {
                            array = File.ReadAllBytes("SaveData//Photos/" + text);
                        }
                        else
                        {
                            try
                            {
                                array = Program.webClient.DownloadData("https://img.rec.net" + text);
                            }
                            catch
                            {
                                Console.WriteLine("[ImageServer.cs] Image not found on img.rec.net.");
                            }
                        }
                    }
                    else if (text.Contains(".png"))
                    {
                        int num2 = text.IndexOf('?');
                        if (num2 != -1)
                        {
                            if (File.Exists("SaveData//Photos/" + text.AsSpan(0, num2).ToString()))
                            {
                                array = File.ReadAllBytes("SaveData//Photos/" + text.AsSpan(0, num2).ToString());
                            }
                            else
                            {
                                try
                                {
                                    array = Program.webClient.DownloadData("https://img.rec.net" + text);
                                }
                                catch
                                {
                                    Console.WriteLine("[ImageServer.cs] Image not found on img.rec.net.");
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                array = Program.webClient.DownloadData("https://img.rec.net" + text);
                            }
                            catch
                            {
                                Console.WriteLine("[ImageServer.cs] Image not found on img.rec.net.");
                            }
                        }
                    }
                    else if (text.Contains("img/"))
                    {
                        string path = (text.StartsWith("//") ? ("SaveData/Photos/" + text.AsSpan(6).ToString()) : ("SaveData/Photos/" + text.AsSpan(5).ToString()));
                        if (File.Exists(path))
                        {
                            array = File.ReadAllBytes(path);
                        }
                    }
                    else if (text.StartsWith("//invention/"))
                    {
                        foreach (KeyValuePair<string, Inventions.InventionResponse> item in Inventions.m00003a())
                        {
                            if (item.Value.InventionVersion.BlobName == text.Substring(12))
                            {
                                array = File.ReadAllBytes("SaveData/Inventions/" + item.Key + "/" + item.Value.InventionVersion.BlobName);
                                break;
                            }
                        }
                        if (File.Exists("SaveData/Photos/" + text.AsSpan(6).ToString()))
                        {
                            array = File.ReadAllBytes("SaveData/Photos/" + text.AsSpan(6).ToString());
                        }
                    }
                    else if (text == "/config/LoadingScreenTipData")
                    {
                        array = Encoding.UTF8.GetBytes("[{\"PlatformMask\":-1,\"Title\":\"Welcome to RebornRec!\",\"Message\":\"Have fun! Remember to be respectful and excellent to each other.\",\"RoomNames\":[],\"ImageName\":\"3nyfu8wq1aj1amvi8t8gh1ydx.png\"}]");
                    }
                    else
                    {
                        try
                        {
                            array = Program.webClient.DownloadData("https://img.rec.net" + text);
                        }
                        catch
                        {
                            Console.WriteLine("[ImageServer.cs] Image not found on img.rec.net.");
                        }
                    }
                }
                if (array == null)
                {
                    array = File.ReadAllBytes("SaveData/profileimage.png");
                }
                response.ContentLength64 = array.Length;
                response.OutputStream.Write(array, 0, array.Length);
                response.OutputStream.Flush();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            File.WriteAllText("ImageServerError.txt", ex.ToString());
            listener.Close();
            new ImageServer();
        }
    }
}
