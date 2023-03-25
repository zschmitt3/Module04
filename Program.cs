using NLog;
using System.Collections;


FileScrubber.ScrubMovies("movies.csv");
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
    bool errored = true;
    bool isNew = true;
    string movieID ="";
    while (errored){
        try{
            dataLine = sr.ReadLine();
            if (dataLine != ""){
                movieID = dataLine.Substring(0,dataLine.IndexOf(","));
            }
            movie = dataLine.Substring(dataLine.IndexOf(",")+1,dataLine.LastIndexOf(",")-7);
            if (movie == newMovie){
                logger.Info("Duplicate movie");
                System.Console.WriteLine("That movie is already in the file.");
                isNew = false;
            }
        }catch{
            errored = false;
        }
    }
    if (isNew){
        System.Console.WriteLine("Enter a genre.");
        List<string> genre = new List<string>();
        string genreOne=Console.ReadLine();
        while(genreOne==""){
            System.Console.WriteLine("A genre must be entered.");
            System.Console.WriteLine("Enter a genre.");
            genreOne = Console.ReadLine();
        }
        genre.Add(genreOne);
        bool go = true;
        bool valid = true;
        bool forLoopWasBeingDumbBool = true;
        string newGenre;
        int forLoopWasBeingDumbInt = 0;
        while (go){
            System.Console.WriteLine("Enter another genre, leave blank to proceed.");
            newGenre = Console.ReadLine();
            if (newGenre == ""){
                go = false;
            }else{
                while(forLoopWasBeingDumbBool){
                    System.Console.WriteLine(genre.ElementAt(forLoopWasBeingDumbInt)+" "+newGenre);
                    if(genre.ElementAt(forLoopWasBeingDumbInt)==newGenre){
                        System.Console.WriteLine("Genre already listed.");
                        valid = false;
                    }
                    forLoopWasBeingDumbInt++;
                    if (forLoopWasBeingDumbInt == genre.Count){
                        forLoopWasBeingDumbBool = false;
                    }
                }
            }
            if (valid){
                genre.Add(newGenre);
                valid = true;
            }
        }
        
        
        string genres = "";
        int genreListLength = genre.Count;
        forLoopWasBeingDumbBool = true;
        forLoopWasBeingDumbInt = 0;
        while(forLoopWasBeingDumbBool){
            genres = genres+genre.ElementAt(forLoopWasBeingDumbInt)+"|";
            forLoopWasBeingDumbInt++;
            if(forLoopWasBeingDumbInt>=genreListLength-1){
                forLoopWasBeingDumbBool=false;
            }
        }
        genres = genres.Substring(0,genres.LastIndexOf("|"));



        sw.WriteLine(movieID+", "+newMovie+", "+genres);
        System.Console.WriteLine("Movie added successfully");
        logger.Info("Movie added");
        sw.Flush();
    }
}
