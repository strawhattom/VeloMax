using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using ReactiveUI;
using VeloMax.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace VeloMax.ViewModels;

public class JsonExportWindowViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> ExportJson { get; set; }
    
    private int _minQty;
    private string _filePath = "Salut";
    
    private readonly Database _db = new();
    public JsonExportWindowViewModel()
    {
        ExportJson = ReactiveCommand.Create(() =>
        {
            JsonPart Parts = new JsonPart(new ObservableCollection<object>(_db.MinQtyParts(_minQty)));
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Parts, options);
            //Console.WriteLine(Parts[0]);
            //Console.WriteLine(jsonString);
            File.WriteAllText(_filePath, jsonString);
            Console.WriteLine("OK");
        });
    }

    public int MinQty
    {
        get => _minQty;
        set => this.RaiseAndSetIfChanged(ref _minQty, value);
    }

    public string FilePath
    {
        get => _filePath;
        set => this.RaiseAndSetIfChanged(ref _filePath, value);
    }
}

public class JsonPart
{
    public ObservableCollection<object> Parts;

    public JsonPart(ObservableCollection<object> Parts)
    {
        Parts = Parts;
    } 
}