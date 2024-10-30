using System.Collections.Generic;
using System.IO;
using System.Text;

namespace api;

internal class PartParser
{
	public static int ContentLength;

	public static bool isFile;

	public static byte[] ParseData(byte[] data, string name)
	{
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(data));
		while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
		{
			bool flag = true;
			while (flag)
			{
				List<byte> list = new List<byte>();
				bool flag2 = true;
				while (flag2)
				{
					byte b = binaryReader.ReadByte();
					if (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
					{
						if (b == 13)
						{
							binaryReader.ReadByte();
							flag2 = false;
						}
						else
						{
							list.Add(b);
						}
					}
					else
					{
						flag2 = false;
					}
				}
				string @string = Encoding.ASCII.GetString(list.ToArray());
				if (@string.StartsWith("Content-Length:"))
				{
					ContentLength = int.Parse(@string.Substring(16));
				}
				if (@string.Contains(name))
				{
					isFile = true;
				}
				if (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
				{
					if (binaryReader.ReadByte() == 13)
					{
						flag = false;
						binaryReader.ReadByte();
					}
					else
					{
						binaryReader.BaseStream.Position--;
					}
				}
				else
				{
					flag = false;
				}
			}
			if (isFile)
			{
				List<byte> list2 = new List<byte>();
				while (true)
				{
					if (binaryReader.ReadByte() == 13)
					{
						if (binaryReader.ReadByte() == 10)
						{
							if (binaryReader.ReadByte() == 45)
							{
								break;
							}
							binaryReader.BaseStream.Position -= 3L;
						}
						else
						{
							binaryReader.BaseStream.Position -= 2L;
						}
					}
					else
					{
						binaryReader.BaseStream.Position--;
					}
					byte item = binaryReader.ReadByte();
					list2.Add(item);
				}
				return list2.ToArray();
			}
			if (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
			{
				binaryReader.ReadBytes(ContentLength);
			}
		}
		return null;
	}
}
