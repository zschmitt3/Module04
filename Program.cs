using NLog;

System.Console.WriteLine("Enter 1 to print movies");
System.Console.WriteLine("Enter 2 to add a movie");
System.Console.WriteLine("Enter anything else to quit");
char input = char.Parse(Console.ReadLine());
var logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
FileStream fs = new FileStream("movies.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
StreamReader sr = new StreamReader(fs);
StreamWriter sw = new StreamWriter(fs);


if (input == '1'){
    logger.Info("Print selected.");
    string dataLine = sr.ReadLine();
    string movie = dataLine.Substring(dataLine.IndexOf(",")+1,dataLine.LastIndexOf(",")-7);
    while (dataLine != null){
        try{
            dataLine = sr.ReadLine();
            movie = dataLine.Substring(dataLine.IndexOf(",")+1,dataLine.LastIndexOf(",")-7);
            System.Console.WriteLine(movie);
        }catch{
            dataLine = null;
        }
    }
    logger.Info("Print completed");
}else if (input == '2'){
    logger.Info("Add selected");
    System.Console.WriteLine("Enter a movie name.");
    string newMovie = Console.ReadLine();
    string dataLine = ","+sr.ReadLine()+",FillerTextFilling";
    string movie = dataLine.Substring(dataLine.IndexOf(",")+1,dataLine.LastIndexOf(","));
    bool isNew = true;
    while (dataLine != null){
        try{
            dataLine = ","+sr.ReadLine()+",FillerTextFilling";
            movie = dataLine.Substring(dataLine.IndexOf(",")+1,dataLine.LastIndexOf(",")-7);
            if (movie == newMovie){
                logger.Info("Duplicate movie");
                System.Console.WriteLine("That movie is already in the file.");
                isNew = false;
            }
        }catch{
            dataLine = null;
        }
    }
    if (isNew){
        sw.WriteLine(newMovie);
        System.Console.WriteLine("Movie added successfully");
        logger.Info("Movie added");
    }
}
