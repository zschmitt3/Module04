using NLog;
using System.Collections;

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
            dataLine = sr.ReadLine();
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
        System.Console.WriteLine("Enter a genre.");
        List<string> genre = new List<string>();
        sr = new StreamReader("movies.csv");
        string genreOne=Console.ReadLine();
        while(genreOne==""){
            System.Console.WriteLine("A genre must be entered.");
            System.Console.WriteLine("Enter a genre.");
            genreOne = Console.ReadLine();
        }
        genre.Add(genreOne);
        dataLine = sr.ReadLine();
        bool go = true;
        bool valid = true;
        string newGenre = Console.ReadLine();
        while (go){
            System.Console.WriteLine("Enter another genre, leave blank to proceed.");
            newGenre = Console.ReadLine();
            if (newGenre == ""){
                go = false;
            }else{
                for(int i = 0; i == genre.Count; i++){
                    if(genre.ElementAt(i)==newGenre){
                        System.Console.WriteLine("Genre already listed.");
                        valid = false;
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
        for(int i = 0; i== genreListLength-1;i++){
            genres = genres+genre.ElementAt(i)+"|";
        }
        genres = genres+genre.ElementAt(genreListLength);

        int movieID = 0;
        while (dataLine != null){
            try{
                dataLine = sr.ReadLine();
                movieID = Int32.Parse(dataLine.Substring(0,dataLine.IndexOf(",")));
            }catch{
                dataLine = null;
            }
        }
        movieID++;

        sw.WriteLine(movieID+", "+newMovie+", "+genres);
        System.Console.WriteLine("Movie added successfully");
        logger.Info("Movie added");
        sw.Flush();
    }
}
