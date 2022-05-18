using System;
using System.Reactive;
using ReactiveUI;
using VeloMax.Services;

namespace VeloMax.ViewModels;

public class JsonExportWindowViewModel : ViewModelBase
{
    public JsonExportWindowViewModel()
    {
        ExportJson = ReactiveCommand.Create(() =>
        {
            Console.WriteLine("Exporting...");
        });
    }
    private int _minQty;
    private string _filePath;
    public ReactiveCommand<Unit, Unit> ExportJson;
    private readonly Database _db = new();

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