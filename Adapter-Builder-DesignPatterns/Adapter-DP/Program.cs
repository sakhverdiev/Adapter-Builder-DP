using System;

// Adapter => Oz sistemimize aid olmayan bir strukturu, Adapter vasitesile sanki oz sistemimize aidmis kimi gostere bilerik.


namespace Adapter_DP;

// Interface (sistemde isledilen struktur)
interface IJsonSerializer
{
    public string SerializeObject(object obj);
}

// Movcud sisteme Impelement edilmek istenilen class
class CustomSerializer
{
    public string Serialize(object obj)
    {
        // Gelen object serialize edilir...

        return "Seialized with CustomSerializer";
    }
}

// Adapter (Movcud sisteme Implement eden class)
class CustomSeializerAdapter : IJsonSerializer
{
    public string SerializeObject(object obj)
    {
        CustomSerializer customSerializer = new CustomSerializer();
        return customSerializer.Serialize(obj);
    }
}

class CustomOperation
{
    private IJsonSerializer _jsonSerializer;

    public CustomOperation(IJsonSerializer jsonSerializer)
    {
        _jsonSerializer = jsonSerializer;
    }

    public string Serialize(object obj)
    {
        return _jsonSerializer.SerializeObject(obj);
    }
}


class Program
{
    public void Main()
    {
        var CustomOperation = new CustomOperation(new CustomSeializerAdapter());

        string serializedObject = CustomOperation.Serialize(new object());
        
        Console.WriteLine(serializedObject);
    }
}