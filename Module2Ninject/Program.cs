using Module2Ninject.Modules;
using Ninject;
using Module2Ninject.Entities;
using Module2Ninject.Repositories;
using Module2Ninject.Services;
using Module2Ninject.Logger;
using Module2Ninject.Loggers;
using System.Text;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        IKernel kernel = new StandardKernel(new NinjectBindings());
        ILogger consoleLogger = kernel.Get<ConsoleLogger>();
        ILogger fileLogger = kernel.Get<FileLogger>();

        Console.WriteLine("Для продовження необхідно буде натиснути будь-яку клавішу\nТе, що виводиться в консоль також записується у файл log.txt");
        Console.ReadKey();
        Console.Clear();
        Task1Cocktails(kernel, consoleLogger, fileLogger);
        Task2GameCharacters(kernel, consoleLogger, fileLogger);
        Task3Figures(kernel, consoleLogger, fileLogger);
        Task4Devices(kernel, consoleLogger, fileLogger);
    }

    static void Task1Cocktails(IKernel kernel, ILogger consoleLogger, ILogger fileLogger)
    {
        ICocktailsRepository coctailsRepository = kernel.Get<ICocktailsRepository>();
        Cocktail margarita = new Cocktail
        {
            Name = "Маргарита",
            Ingredients = "45 мл текіли\r\n20 мл свіжовичавленого соку лайма\r\n30 мл лікера Куантро",
            CountryOfInvention = "Мексика",
            YearOfInvention = 1938,
        };

        Cocktail mojito = new Cocktail
        {
            Name = "Мохіто",
            Ingredients = "60 мл світлого рому\r\n25 мл свіжовичавленого соку лайма\r\n15 мл простого сиропу\r\n6 листочків м'яти\r\nКлаб сода, до країв",
            CountryOfInvention = "Куба",
            YearOfInvention = 1915,
        };

        Cocktail pinaColada = new Cocktail
        {
            Name = "Піна Колада",
            Ingredients = "60 мл білого рому\r\n90 мл ананасового соку\r\n30 мл кокосового молока\r\n1 ст. ложка цукру",
            CountryOfInvention = "Пуерто-Рико",
            YearOfInvention = 1954,
        };

        coctailsRepository.SaveCocktails(new List<Cocktail> { margarita, mojito, pinaColada, });

        var cocktailsServices = new CocktaisService(coctailsRepository, consoleLogger);
        cocktailsServices.PrintAbbreviatedInfo();
        Console.ReadKey();
        Console.Clear();
        cocktailsServices.PrintFullInfo();
        Console.ReadKey();
        Console.Clear();

        var cocktailsFileServices = new CocktaisService(coctailsRepository, fileLogger);
        cocktailsFileServices.PrintAbbreviatedInfo();
        cocktailsFileServices.PrintFullInfo();
    }

    static void Task2GameCharacters(IKernel kernel, ILogger consoleLogger, ILogger fileLogger)
    {
        IGameCharacterRepositories gameCharacterRepositories = kernel.Get<IGameCharacterRepositories>();
        gameCharacterRepositories.SaveGameCharacters(new List<GameCharacter> { new Swordsman(), new Spearman(), new Bowman(), });

        var gameCharactersServices = new GameCharactersService(gameCharacterRepositories, consoleLogger);
        gameCharactersServices.PrintInfo();

        var gameCharactersFileServices = new GameCharactersService(gameCharacterRepositories, fileLogger);
        gameCharactersFileServices.PrintInfo();
        Console.ReadKey();
        Console.Clear();
    }

    static void Task3Figures(IKernel kernel, ILogger consoleLogger, ILogger fileLogger)
    {
        IFigureRepository figureRepository = kernel.Get<IFigureRepository>();
        Figure circle = new Figure
        {
            Name = "Коло",
            View = "●",
            NumberOfAngles = 0,
            AreaFormula = "S = πr²",
        };

        Figure square = new Figure
        {
            Name = "Квадрат",
            View = "■",
            NumberOfAngles = 4,
            AreaFormula = "S = 4a",
        };

        Figure triangle = new Figure
        {
            Name = "Трикутник",
            View = "▲",
            NumberOfAngles = 3,
            AreaFormula = "S = 1/2 bh",
        };

        figureRepository.SaveFigures(new List<Figure> { circle, square, triangle, });

        var figuresServices = new FiguresService(figureRepository, consoleLogger);
        figuresServices.PrintAbbreviatedInfo();
        Console.ReadKey();
        Console.Clear();
        figuresServices.PrintFullInfo();

        var figuresFileServices = new FiguresService(figureRepository, fileLogger);
        figuresFileServices.PrintAbbreviatedInfo();
        figuresFileServices.PrintFullInfo();
    }

    static void Task4Devices(IKernel kernel, ILogger consoleLogger, ILogger fileLogger)
    {
        IDeviceRepository deviceRepository = kernel.Get<IDeviceRepository>();

        Device mixer = new Device
        {
            Name = "Міксер",
            Purpose = "для механічного перемішування",
            Inventor = "Джозеу Брама",
            Destination = "кухня",
        };

        Device washingMachine = new Device
        {
            Name = "Пральна машина",
            Purpose = "для прання білизни",
            Inventor = "Джеймс Кінг",
            Destination = "ванна",
        };

        Device electricBlanket = new Device
        {
            Name = "Електроковдра",
            Purpose = "заспокоїти суглоби або зігрітися",
            Inventor = "Сідні І. Рассел",
            Destination = "спальня",
        };

        deviceRepository.SaveDevices(new List<Device> { mixer, washingMachine, electricBlanket, });

        var devicesServices = new DevicesService(deviceRepository, consoleLogger);
        devicesServices.PrintAbbreviatedInfo();
        Console.ReadKey();
        Console.Clear();
        devicesServices.PrintFullInfo();

        var devicesFileServices = new DevicesService(deviceRepository, fileLogger);
        devicesFileServices.PrintAbbreviatedInfo();
        devicesFileServices.PrintFullInfo();
    }
}