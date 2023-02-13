using NLog;

System.Console.WriteLine("Enter 1 to print movies");
System.Console.WriteLine("Enter 2 to add a movie");
System.Console.WriteLine("Enter anything else to quit");
char input = char.Parse(Console.ReadLine());
var logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
if (input == '1'){
    logger.Info("Print selected.");
    
}else if (input == '2'){

}