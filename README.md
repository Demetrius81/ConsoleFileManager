
# Файловый менеджер для командной строки

. Файловый менеджер позволяет комфортно работать в условиях, когда нет возможности работать в другой установленной операционной системе или операционная система отсутствует. 

``` 
C:\Project> NuGet Install CommandLineParser 
``` 

# Рабочая версия 

Рабочую версию файлового менеджера можно загрузить с github [Releases](https://github.com/commandlineparser/commandline/releases).

# Краткий обзор: 

— Предусмотрена возможность 
- Сменить директорию.
- просмотреть . 
- Сопоставление с последовательностями (через `IEnumerable<T>` и т.п.) и скалярными типами, включая Enums и `Nullable<T>`. 
- Вы также можете сопоставить каждый тип с помощью конструктора, который принимает строку (например, `System.Uri`) для ссылочных и значимых типов. 
- Глаголы могут быть массивом типов, собранных из плагинов или контейнера IoC. 
- Определите [глаголы-команды] (https://github.com/commandlineparser/commandline/wiki/Verbs), аналогичные `git commit -a`. 
- Поддержка глагола по умолчанию. 
- Поддержка изменяемых и неизменяемых типов. 
- Поддержка локализации HelpText. 
- Поддержка порядка параметров в HelpText.
- Поддержка [Взаимоисключающих параметров] (https://github.com/commandlineparser/commandline/wiki/Mutually-Exclusive-Options) и групп параметров. 
- Поддержка именованных и стоимостных опций. 
- Поддержка асинхронного программирования с помощью async и await. 
- Поддержка разбора: `CommandLine.Parser.Default.FormatCommandLine<T>(T варианты)`. 
- Пакет CommandLineParser.FSharp совместим с F# и поддерживает `option<'a>`, см. [demo](https://github.com/commandlineparser/commandline/blob/master/demo/fsharp-demo.fsx). _ПРИМЕЧАНИЕ. Это отдельный пакет NuGet._
– Включите вики-документацию с большим количеством примеров, готовых для запуска в Интернете. 
— Поддержка исходной ссылки и символического пакета nuget snupkg. 
- Протестировано в Windows, Linux Ubuntu 18.04 и Mac OS.
- Большинство функций применимо к философии [CoC](http://en.wikipedia.org/wiki/Convention_over_configuration). 
- Демонстрация C#: источник [здесь] (https://github.com/commandlineparser/commandline/tree/master/demo/ReadText.Demo). 

# Начало работы с библиотекой синтаксического анализатора командной строки 

| Архитектура | Решение (Основное) | Решение (стабильное) | Установщик (Основной) |
|-----------------------------|-----------------|---------------- ---|------------------|
| х64 | [![Статус сборки для Main](https://dev.azure.com/ms/PowerToys/_apis/build/status/microsoft.PowerToys?branchName=main)](https://dev.azure.com/ms /PowerToys/_build/latest?definitionId=219&branchName=main) | [![Статус сборки для стабильной версии](https://dev.azure.com/ms/PowerToys/_apis/build/status/microsoft.PowerToys?branchName=stable)](https://dev.azure.com/ms /PowerToys/_build/latest?definitionId=219&branchName=stable) | [![Конвейер установщика состояния сборки](https://dev.azure.com/microsoft/Dart/_apis/build/status/microsoft.PowerToys?branchName=main)](https://dev.azure.com/microsoft /Dart/_build/latest?definitionId=76541&branchName=main) |
| ARM64 | В настоящее время расследование | [Выпуск № 490] (https://github.com/microsoft/PowerToys/issues/490) | |


Вы можете использовать библиотеку синтаксического анализатора несколькими способами: 

- Установка через NuGet/Paket: [https://www.nuget.org/packages/CommandLineParser/](https://www.nuget .org/packages/CommandLineParser/) 
— интегрируйте непосредственно в свой проект, скопировав файлы .cs в свой проект. 
- ILMerge в процессе сборки. 

## Примеры быстрого запуска 

1. Создайте класс для определения допустимых параметров и для получения проанализированных параметров. 
2. Вызовите ParseArguments с массивом строк args.

Краткое руководство по C#: 

cs 
using System; 
с помощью командной строки; 

namespace QuickStart 
{ 
    class Program 
    { 
        public class Options 
        { 
            [Option('v', "verbose", Required = false, HelpText = "Настроить вывод на подробные сообщения.")] 
            public bool Verbose { get; набор; } 
        } 

        static void Main(string[] args) 
        { 
            Parser.Default.ParseArguments<Options>(args) 
                   .WithParsed<Options>(o => 
                   { 
                       if (o.Verbose) 
                       {
                           Console.WriteLine($"Включен подробный вывод. Текущие аргументы: -v {o.Verbose}"); 
                           Console.WriteLine("Пример быстрого запуска! Приложение находится в подробном режиме!"); 
                       } 
                       else 
                       { 
                           Console.WriteLine($"Текущие аргументы: -v {o.Verbose}"); 
                           Console.WriteLine("Пример быстрого запуска!"); 
                       } 
                   }); 
        } 
    } 
} 
``` 

## C# Примеры: 

<details> 
  <summary>Нажмите, чтобы развернуть!</summary>


  [Option('r', "read", Required = true, HelpText = "Входные файлы для обработки")] 
  public IEnumerable<string> InputFiles { get; набор; } 

  // Длинное имя не указывается, по умолчанию используется имя свойства, т.е. "--verbose" 
  [Option( 
	Default = false, 
	HelpText = "Выводит все сообщения на стандартный вывод.")] 
  public bool Verbose { get; набор; } 
  
  [Option("stdin", 
	Default = false, 
	HelpText = "Читать со stdin")] 
  public bool stdin { get; набор; } 

  [Value(0, MetaName = "смещение", HelpText = "Смещение файла")] 
  public long? Смещение { получить; набор;

    .WithParsed(RunOptions) 
    .WithNotParsed(HandleParseError); 
} 
static void RunOptions(Options opts) 
{ 
  //обработка параметров 
} 
static void HandleParseError(IEnumerable<Error> errs) 
{ 
  //обработка ошибок 
} 

``` 

</details> 

Демонстрация, показывающая параметры IEnumerable и другое использование: [Онлайн-демонстрация] (https://dotnetfiddle.net/wrcAxr) 

## F# Примеры: 

<details> 
  <summary>Нажмите, чтобы развернуть!</summary> 

```fsharp 

type options = { 
  [<Option('r', "read", Required = true, HelpText = "Входные файлы.")>] files : seq<string>; 
  [<Опция(Текст справки = "
  [<Option(Default = "русский", HelpText = "Язык контента")>] language : string; 
  [<Value(0, MetaName="offset", HelpText = "Смещение файла")>] offset : опция int64; 
} 

let main argv = 
  let result = CommandLine.Parser.Default.ParseArguments<options>(argv) 
  сопоставить результат с 
  | :? Parsed<options> as parsed -> run parsed.Value 
  | :? NotParsed<options> as notParsed -> fail notParsed.Errors 
``` 
</details> 

## Пример VB.NET: 

<details> 
  <summary>Нажмите, чтобы развернуть!</summary> 

``` 

Параметры класса vb 
	<CommandLine.Option ('r', "читать", обязательно := true,
	Public Property InputFiles As IEnumerable(Of String) 

	' Длинное имя не указывается, по умолчанию используется имя свойства, т.е. "--verbose" 
	<CommandLine.Option( 
	HelpText:="Выводит все сообщения на стандартный вывод.")> 
	Public Property Verbose As Boolean 

	<CommandLine.Option(Default:="中文", 
	HelpText:="Content language.")> 
	Язык общего свойства As String 

	<CommandLine.Value(0, MetaName:="offset", 
	HelpText:="Смещение файла.") > 
	Смещение публичной собственности как долго? 
End Class 

Sub Main(ByVal args As String()) 
    CommandLine.Parser.Default.ParseArguments(Of Options)(args) _ 
        .
        .WithNotParsed(Function(ошибки As IEnumerable(Of [Error])) 1) 
End Sub 
``` 
</details> 

## Для глаголов: 

1. Создайте отдельные классы параметров для каждого глагола. Поддерживается базовый класс параметров.  
2. Вызовите ParseArguments со всеми классами декорированных атрибутов глаголов. 
3. Используйте MapResult, чтобы направить поток программы к проанализированному глаголу. 

### Пример C#: 


<details> 
  <summary>Щелкните, чтобы развернуть!</summary> 

```csharp 
[Глагол("добавить", HelpText = "Добавить содержимое файла в индекс.")] 
class AddOptions { 
  //normal варианты здесь 
} 
[Глагол("зафиксировать", HelpText = "Записать изменения в репозиторий."
  //здесь зафиксировать параметры 
} 
[Verb("clone", HelpText = "Клонировать репозиторий в новый каталог.")] 
class CloneOptions { 
  //здесь клонировать параметры 
} 

int Main(string[] args) { 
  return CommandLine.Parser. Default.ParseArguments<AddOptions, CommitOptions, CloneOptions>(args) 
	.MapResult( 
	  (AddOptions options) => RunAddAndReturnExitCode(opts), 
	  (CommitOptions options) => RunCommitAndReturnExitCode(opts), 
	  (CloneOptions opts) => RunCloneAndReturnExitCode(opts), 
	  errs => 1); 
} 
``` 
</details> 

### Пример VB.NET: 


<details> 
  <summary>Нажмите, чтобы развернуть!</summary> 

```vb
<CommandLine.Verb("добавить", HelpText:="Добавить содержимое файла в индекс.")> 
Public Class AddOptions 
    'Обычные параметры здесь 
End Class 
<CommandLine.Verb("commit", HelpText:="Записать изменения в репозиторий .")> 
Public Class CommitOptions 
    'Обычные параметры здесь 
End Class 
<CommandLine.Verb("clone", HelpText:="Клонировать репозиторий в новый каталог.")> 
Public Class CloneOptions 
    'Здесь обычные параметры 
End Class 

Function Main(ByVal args As String()) As Integer 
    Возврат CommandLine.Parser.Default.ParseArguments(Of AddOptions, CommitOptions, CloneOptions)(args) _ 
          .MapResult(
              (Функция (выбирается как AddOptions) RunAddAndReturnExitCode (выборки)), 
              (Function (выбирается как CommitOptions) RunCommitAndReturnExitCode (выборки)), 
              (Function (выбирается как CloneOptions) RunCloneAndReturnExitCode (выборки)), 
              (Function (ошибки As IEnumerable (Of [Error]) )) 1) 
          ) 
End Function 
``` 
</details> 

### F# Пример: 

<details> 
  <summary>Нажмите, чтобы развернуть!</summary> 

```fs 
open CommandLine 

[<Verb("add", HelpText = "Добавить содержимое файла в индекс.")>] 
type AddOptions = { 
  // здесь обычные параметры 
} 
[<Verb("commit", HelpText = "Запись изменений в репозиторий.")>]
type CommitOptions = { 
  // здесь обычные параметры 
} 
[<Verb("clone", HelpText = "Клонировать репозиторий в новый каталог.")>] 
type CloneOptions = { 
  // здесь обычные параметры 
} 

[<EntryPoint>] 
let main args = 
  let result = Parser.Default.ParseArguments<AddOptions, CommitOptions, CloneOptions> args 
  сопоставляет результат с 
  | :? CommandLine.Parsed<obj> as command -> 
	сопоставить command.Value с 
	| :? AddOptions as opts -> RunAddAndReturnExitCode opts 
	| :? CommitOptions as opts -> RunCommitAndReturnExitCode opts 
	| :? CloneOptions as opts -> RunCloneAndReturnExitCode opts 
  | :? CommandLine.NotParsed<объект> ->
</details> 

# История выпусков 

См. [журнал изменений](CHANGELOG.md) 

# Участники 
Прежде всего, _Спасибо!_ Приветствуются любые вклады.  

Пожалуйста, рассмотрите возможность использования стандарта GNU getopt для синтаксического анализа командной строки.  

Кроме того, для упрощения сравнения различий следуйте настройкам вкладок проекта. Рекомендуется использовать расширение EditorConfig для Visual Studio или вашей любимой IDE. 

__И самое главное, указывайте в своих пулл-реквестах ветку ``develop```!__ 

## Основные участники (в алфавитном порядке): 
- Александр Фаст (@mizipzor) 
- Дэн Немек (@nemec) 
- Эрик Ньютон (@ericnewton76 ) 
- Кевин Мур (@gimmemoore) 
- Мох-Хассан (@moh-hassan)
- Steven Evans 
- Thomas Démoulins (@Thilas) 

## Ресурсы для новичков: 

- [Wiki](https://github.com/commandlineparser/commandline/wiki) 
- [GNU getopt](http://www.gnu.org /software/libc/manual/html_node/Getopt.html) 

# Контакты: 

- Giacomo Stelluti Scala 
  - gsscoder AT gmail DOT com (_используйте это для всего, что недоступно через функции GitHub_) 
  - GitHub: [gsscoder](https:// github.com/gsscoder) 
  – [Блог](http://gsscoder.blogspot.it) 
  – [Twitter](http://twitter.com/gsscoder) 
– Дэн Немек 
– Эрик Ньютон 
  – ericnewton76+commandlineparser AT gmail DOT com 
  - GitHub: [ericnewton76] (https://github.com/ericnewton76) 
  - Блог:
  - Твиттер: [enorl76](http://twitter.com/enorl76) 
- Мох-Хассан