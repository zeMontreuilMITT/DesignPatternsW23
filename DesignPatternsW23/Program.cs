Client clientOne = new Client { Files = new List<string> { "catPictures.png", "morecatpictures.png" } };

Client clientTwo = new Client { Files = new List<string> { "piratemusic.mp3", "piratemusicagain.mp3", "piratepoetry.txt" } };

FileCompressor compressor = new FileCompressor();

compressor.RunFileCompression(clientTwo, "rar");
compressor.RunFileCompression(clientTwo, "zip");
compressor.RunFileCompression(clientTwo, "tar");

public class FileCompressor
{
    // _compressionBehaviour must be an implementation of ICompressionBehaviour
    private ICompressionBehaviour _compressionBehaviour;

    private ICollection<string> strings {  get; set; }
    private void _compressFiles(Client client)
    {
        _compressionBehaviour.DoCompression(client);
        // delegate to the interface to run a method
    }
    private void _setCompressionBehaviour(string type)
    {
        switch(type)
        {
            case "zip":
                _compressionBehaviour = new CompressToZIP();
                break;

            case "rar":
                _compressionBehaviour = new CompressToRAR();
                break;

            case "tar":
                _compressionBehaviour = new CompressToTar();
                break;

            default:
                throw new InvalidOperationException("Unknown compression format");
        }
    }
    public void RunFileCompression(Client client, string type)
    {
        try
        {
            _setCompressionBehaviour(type);
            _compressFiles(client);
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public FileCompressor()
    {
        strings = new List<string>();
        _compressionBehaviour = new CompressToZIP();
    }
}

public interface ICompressionBehaviour
{
    public void DoCompression(Client client);
}
public class CompressToRAR : ICompressionBehaviour
{
    public void DoCompression(Client client)
    {
        List<string> files = client.Files.ToList();
        foreach (string s in files)
        {
            Console.WriteLine($"RAR is consuming the file");
        }
        Console.WriteLine($"RAR file created containing {files.Count} files");
    }
}
public class CompressToZIP: ICompressionBehaviour
{
    public void DoCompression(Client client)
    {
        Console.WriteLine($"Zipping [{client.Files.Count}] files:");
        Console.WriteLine("Done");
    }
}
public class CompressToTar: ICompressionBehaviour
{
    public void DoCompression(Client client)
    {
        Console.WriteLine("All the files went in the TAR, what more do you want from me");
    }
}

public class Client
{
    public List<string> Files { get; set; }
}

